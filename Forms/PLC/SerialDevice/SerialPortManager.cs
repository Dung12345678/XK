using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace InControls.SerialDevice
{

	/// <summary>
	/// ´®ĞĞ¿Ú¹ÜÀúÜE	/// 
	/// ¹ÜÀúä«¾ÖĞÔ¶Ë¿ÚµÄÀEÓÃÓÚ´®¿ÚµÄ´ò¿ª¡¢¹Ø±Õ¡¢IO(ÊäÈEÊä³EµÄ¹ÜÀE	/// Ã¿¸ö´®¿ÚÉè±¸Ò»µ©´ò¿ª£¬Ôò±£³ÖÈ«¾ÖÎ¨Ò»£¬ÒÔ±£³Ö¹²ÏúèØĞÔ
	/// </summary>
	public sealed class SerialPortManager
	{
		private static SerialPortManager _Instance;

		public static SerialPortManager Instance
		{
			get
			{
				if (_Instance == null) {
					lock (typeof(SerialPortManager)) {
						if (_Instance == null) {
							_Instance = new SerialPortManager();
						}
					}
				}
				return SerialPortManager._Instance;
			}
		}

		private List<System.IO.Ports.SerialPort> _PortList;
		private int _PortCount = 0;

		private SerialPortManager()
		{
			string[] names;
			names = System.IO.Ports.SerialPort.GetPortNames();

			_PortCount = 2;				// Ä¬ÈÏÖÁÉÙ2¸E			
            foreach (string s in names) {
				int ct = Convert.ToInt16(s.Substring(3));
				if (ct > _PortCount) _PortCount = ct;
			}

			_PortList = new List<SerialPort>(Math.Max(8, _PortCount + 1));			// ÔİÊ±Ö§³Ö×ûåÙ 8 ¸ö¶Ë¿Ú
			for (int i = 0; i < _PortList.Capacity; i++) {
				_PortList.Add(null);
			}
		}

		public int ComPortCount()
		{
			return (_PortCount);
		}

		/// <summary>
		/// µÃµ½Ö¸¶¨ĞòºÅµÄ¶Ë¿ÚµÄÃû³Æ
		/// </summary>
		/// <param name="PortNo">´®¿ÚºÅ£¬´Ó1..Max</param>
		/// <returns>¶Ë¿ÚÃû³Æ</returns>
		public string GetPortName(int portNo)
		{
			string[] names;
			names = System.IO.Ports.SerialPort.GetPortNames();

			foreach (string s in names) {
				if (int.Parse(s.Substring(3, 1)) == portNo) {
					return (s);
				}
			}
			return (null);
		}

		/// <summary>
		/// ¸ù¾İ´®¿ÚÃû³Æ£¬µÃµ½Æä¶ÔÓ¦µÄĞòºÅ
		/// </summary>
		/// <param name="PortNo">¶Ë¿ÚÃû³Æ£¬ÀıÈç¡°COM1¡±¡¢¡°COM2¡±</param>
		/// <returns>´®¿ÚĞòºÅ£¬ÀıÈç¡°1¡±¡¢¡°2¡±£¬ÈçÃû³Æ²»´æÔÚ·µ»Ø0</returns>
		public int GetPortNo(string portName)
		{
			string[] names;
			names = System.IO.Ports.SerialPort.GetPortNames();

			foreach (string s in names) {
				if (s == portName) {
					return (int.Parse(s.Substring(3, 1)));
				}
			}
			return (0);
		}

		/// <summary>
		/// µÃµ½Ö¸¶¨¶Ë¿ÚºÅÂEÄÊµÀı
		/// ¸ÃÊµÀı¿ÉÓÃÓÚºóĞøµÄ²Ù×÷¡£¿ÉÄÜĞèÒª´ò¿ª¹ØÁªµÄ¶Ë¿Ú
		/// </summary>
		/// <param name="PortNo">´®ĞĞ¶Ë¿ÚºÅ£¬·¶Î§ 1..Max </param>
		/// <returns></returns>
		public System.IO.Ports.SerialPort GetComPortInstance(int portNo)
		{
			return (GetComPortInstance("COM" + portNo.ToString()));
		}

		/// <summary>
		/// µÃµ½Ö¸¶¨¶Ë¿ÚÃû³ÆµÄÊµÀı
		/// ¸ÃÊµÀı¿ÉÓÃÓÚºóĞøµÄIO²Ù×÷¡£¿ÉÄÜĞèÒª´ò¿ª¹ØÁªµÄ¶Ë¿Ú
		/// </summary>
		/// <param name="PortNo">´®ĞĞ¶Ë¿ÚÃû£¬ÀıÈE¡°COM1¡± £¬·¶Î§ 1..Max </param>
		/// <returns></returns>
		public System.IO.Ports.SerialPort GetComPortInstance(string portName)
		{
			int nPortNo;

			nPortNo = GetPortNo(portName);
			if (nPortNo <= 0) return (null);

			System.IO.Ports.SerialPort sp = _PortList[nPortNo];

			if (sp == null) {							// Ò»°ã²»¿ÉÄÜ³öÏÖÕÒ²»µ½Éè±¸µÄÇé¿E				sp = new SerialPort(portName);
				sp.BaudRate = 9600;						// Ä¬ÈÏËÙÂÊ¡¢Êı¾İÎ»¡¢Í£Ö¹Î»¡¢Ğ£ÑéÎ»µÈ²ÎÊı
				sp.DataBits = 8;
				sp.StopBits = StopBits.One;
				sp.Parity = Parity.None;
				sp.Handshake = Handshake.RequestToSendXOnXOff;
				_PortList[nPortNo] = sp;
				return (sp);
			}
			return (sp);
		}


	}
}
