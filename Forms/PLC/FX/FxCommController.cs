using System;
using System.Threading;
using Vila.Threading.Queue;

using InControls.Common;

namespace InControls.PLC.FX
{
	public sealed class FxCommController
	{

		#region ¶ÁÈ¡ÊµÊ±Êı¾İµÄ¼ä¸EÖÜÆÚ£¨µ¥Î»£ºÃE©
		private readonly int READ_REAL_DATA_INTERNAL = 5;
		#endregion

		#region Í¨Ñ¶¿ØÖÆÆ÷¾²Ì¬ÊµÀı Instance ¼°ÊôĞÔÊµÏÖ´úÂE		
        private static FxCommController _Instance;

		public static FxCommController Instance
		{
			get
			{
				if (_Instance == null) {
					lock (typeof(FxCommController)) {
						_Instance = new FxCommController(true);
					}
				}
				return FxCommController._Instance;
			}
		}
		#endregion


		private FxSerialDeamon _SerialDeamon;

		private DataBlockQueue<FxCommandArgs> _DataBlockQueue;

		private System.Threading.Timer _Timer;
		private Thread _Thead;
		private bool _StopTheadFlag;							// ÓÃÓÚÍ£Ö¹Ïß³ÌµÄ±E¾

		private DateTime _FirstFailtTime;						// Ê×´ÎÍ¨Ñ¶Ê§°ÜÊ±¿Ì

		private EventWaitHandle _WaitHandle;                     // ÁÙÊ±Í¬²½¶ÔÏó¡£Èç¹ûÊÇÍ¬²½µ÷ÓÃ£¬ÔòÊ¹ÓÃ±¾µÈ´ı¶ÔÏE
		/// <summary>
		/// ´ÓÄ¬ÈÏ´®¿ÚÆô¶¯±¾¿ØÖÆÆE		/// ÀıÈç´Ó COM1 ×Ô¶¯Æô¶¯
		/// </summary>
		/// <param name="autoStartFromDefaultSerialPort"></param>
		private FxCommController(bool autoStartFromDefaultSerialPort)
		{
			_WaitHandle = null;

			_DataBlockQueue = new DataBlockQueue<FxCommandArgs>(64, true);

			_SerialDeamon = null;
			_Thead = null;
			_Timer = null;
			_FirstFailtTime = DateTime.MaxValue;
			_StopTheadFlag = false;

			if (autoStartFromDefaultSerialPort) Start(1);
		}

		/// <summary>
		/// Æô¶¯ÓES232µÄÍ¨Ñ¶Ïß³Ì
		/// </summary>
		public void Start(int portNo)
		{
			_SerialDeamon = new FxSerialDeamon();
			_SerialDeamon.Start(portNo);

			_Thead = new Thread(new ThreadStart(this.DealwithCommunicationRoute));
			_Thead.Name = "FxCommController";
			_Thead.IsBackground = true;
			_Thead.Start();

			_Timer = new Timer(new TimerCallback(TimerRoute));
			_Timer.Change(TimeSpan.FromSeconds(10), TimeSpan.FromDays(1));
		}

		/// <summary>
		/// ¹Ø±ÕÏß³Ì
		/// </summary>
		public void Stop()
		{
			_SerialDeamon.Dispose();
			_SerialDeamon = null;

			_Timer.Dispose();
			_Timer = null;

			_Thead.Abort();
			_Thead.Join();
			_Thead = null;
		}

		/// <summary>
		/// ÒE½·¢ËÍÃEû¿¬²¢Á¢¿Ì·µ»Ø
		/// º¯ÊıÄÚ²¿ÊµÏÖ·¢ËÍ¶ÓÁĞ¡¢ÒÔ¼°³¬Ê±»úÖÆ
		/// </summary>
		/// <param name="response">ÃEûóÖ</param>
		/// <param name="cmdData">ÃEûàÚÈİ£¬ÒÔ 0xAA,0xCC,0x83 ¿ªÍ·µÄbyte[] </param>
		public void PostCall(short cmd, byte[] cmdData)
		{
			FxCommandArgs cmdArgs = new FxCommandArgs(cmd, cmdData);
			_DataBlockQueue.Add(cmdArgs);
		}

		/// <summary>
		/// ÒE½·¢ËÍÃEE		/// ÓÃÓÚ·¢ËÍºó¾Í²»¹ÜµÄ¡°ÒE½ÃEû½±
		/// </summary>
		/// <param name="cmdArgs">²ÎÊıµÄOnSendHandle³ÉÔ±Ó¦¸ÃÎª¿Õ°×</param>
		public void PostCall(FxCommandArgs cmdArgs)
		{
			_DataBlockQueue.Add(cmdArgs);
		}

		/// <summary>
		/// ÒE½·¢ËÍÃEE		/// ·¢ËÍÕßÓ¦¸ÃÊµÏÖÁË IDataPackageEvent£¬ÇÒĞèÌá¹©ÒıÓÃ
		/// </summary>
		/// <param name="cmdArgs">²ÎÊıµÄOnSendHandle³ÉÔ±Ó¦¸ÃÎª¿Õ°×</param>
		/// <param name="onSendHandle">¸ù¾İĞèÒª£¬ÓÃ»§¿ÉÌá¹©»Øµ÷µE/param>
		//public void PostCall(CommandEventArgs cmdArgs, IDataPackageEvent onSendHandle)
		//{
		//    System.Diagnostics.Debug.Assert(onSendHandle != null, "µ÷ÓÃÕß±ØĞEµÏÖIDataPackageEvent£¬ÇÒ½«ÒıÓÃ´«ÈE¾º¯Êı");

		//    if (cmdArgs.OnSendHandle == null) cmdArgs.OnSendHandle = onSendHandle;
		//    _DataBlockQueue.Add(cmdArgs);
		//}

		/// <summary>
		/// Í¬²½·¢ËÍÃEE		/// </summary>
		/// <param name="cmdArgs">²ÎÊıµÄOnSendHandle³ÉÔ±±ØĞE³ÖµÎªµ÷ÓÃÕßÒıÓÃ</param>
		public FxCommandResponse SendCall(FxCommandArgs cmdArgs, TimeSpan timeout)
		{
			if (cmdArgs == null) return (null);

			if (_WaitHandle == null) {
				_WaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
			}

			_DataBlockQueue.Add(cmdArgs);

			_WaitHandle.WaitOne(timeout, true);
			_WaitHandle.Close();
			_WaitHandle = null;

			return (cmdArgs.Result);
		}

		/// <summary>
		/// Í¬²½·¢ËÍÃEû¿¬²¢µÈ´ı·µ»Ø
		/// º¯ÊıÄÚ²¿ÊµÏÖ·¢ËÍ¶ÓÁĞ¡¢ÒÔ¼°³¬Ê±»úÖÆ
		/// </summary>
		/// <param name="response">ÃEûóÖ</param>
		/// <param name="channelNo">Í¨µÀºÅ£¬Ä¬ÈÏ0</param>
		/// <param name="cmdData">ÃEûàÚÈİ£¬ÒÔ 0xAA,0xCC,0x83 ¿ªÍ·µÄbyte[] </param>
		/// <param name="timeout">×ûĞó³¬Ê±Éè¶¨</param>
		public FxCommandResponse SendCall(short cmd, byte channelNo, byte[] cmdData, TimeSpan timeout)
		{
			if (cmdData == null) {              // Èç¹ûÃEûß»ÓĞ¹¹ÔE¬ÔòÄ¬ÈÏ¹¹ÔEŞ²ÎÊıµÄÃEE				FxCommandResponse prm = new FxCommandResponse(ResultCodeConst.rcNotSettting, cmdData);
				//cmdData = _CommanderHelper.MakeSmart(response, targetPort, prm);
			}

			FxCommandArgs arg = new FxCommandArgs(cmd, cmdData, channelNo);

			return (SendCall(arg, timeout));
		}


		/// <summary>
		/// ÖÜÆÚĞÔ·¢ËÍ¶ÁÊµÊ±Êı¾İÃEE		/// ²ßÂÔ£º
		///     1¡¢½ö½öÔÚ¿ÕÏĞÊ±²úÉE		///     2¡¢Èç¹û·¢ËÍ¶ÓÁĞÖĞÓĞÄÚÈİ£¬Ôò²»ÔÙ²úÉE		/// </summary>
		private void TimerRoute(Object state)
		{
			if (_DataBlockQueue.QueueLength == 0) {
				// Èç¹û´ı·¢ËÍ¶ÓÁĞÖĞÃ»ÓĞÄÚÈİ£¬²ÅÔÊĞE1:¶ÁÈ¡ÊµÊ±Êı¾İ
				byte[] cmdbuff = new byte[11];
				_DataBlockQueue.Add(new FxCommandArgs(0, cmdbuff, 0));

				// Èç¹û´ı·¢ËÍ¶ÓÁĞÖĞÃ»ÓĞÄÚÈİ£¬²ÅÔÊĞE2:ÓÃÁª»úÃEû×ñÈ¡Ê±¿Ì¡¢×´Ì¬ĞÅÏ¢
				_DataBlockQueue.Add(new FxCommandArgs(0, cmdbuff, 0));
			}
			_Timer.Change(TimeSpan.FromSeconds(READ_REAL_DATA_INTERNAL), TimeSpan.FromDays(1));
		}

		/// <summary>
		/// ÄÚ²¿ÓÃÓÚ´¦ÀúæÕ·¢µÄ¶ÀÁ¢Ïß³Ì
		/// ÓÃÓÚÄÚ²¿ÊµÏÖÍ¬²½ÊÕ·¢
		/// </summary>
		private void DealwithCommunicationRoute()
		{
			while (!_StopTheadFlag) {
				if (_DataBlockQueue.QueueLength == 0) {
					Thread.Sleep(20);
					continue;
				}

				FxCommandArgs arg = _DataBlockQueue.Pick();
				if (arg == null) continue;

				FxCommandResponse result = _SerialDeamon.Send(arg.ChannelNo, arg.Data, arg.Data.Length);

				if (result.ResultCode == ResultCodeConst.rcFailt) {
					// Èç¹û·µ»ØÊ§°Ü£¬ÔòÀÛ¼Æ×ÜÊ§°ÜÊ±¼ä£¬µ½´E¬Ê±Öµºó£¬ĞèÒªÔÚUI½çÃæÉÏÓĞ·´À¡
					if (DateTime.Now.Subtract(_FirstFailtTime).TotalSeconds > 30) {
						_FirstFailtTime = DateTime.Now;
					} else if (_FirstFailtTime == DateTime.MaxValue) {
						_FirstFailtTime = DateTime.Now;
					}

				} else if (result != null) {
					_FirstFailtTime = DateTime.MaxValue;

					switch (arg.Cmd) {
					case 1:                             // Èç¹ûÊÇ...
						break;
					default:
						break;
					}
				} else {
				}

				if (_WaitHandle != null) {
					arg.Result = result;
					_WaitHandle.Set();
				}

				//if (arg.OnSendHandle != null) {
				//    arg.OnSendHandle.OnPackageRecived(result);
				//}

			}
			System.Diagnostics.Debug.Assert(false, "ÍË³öÏß³ÌÁË£¡£¡");
			_Thead = null;
		}
	}
}
