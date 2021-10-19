using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace InControls.SerialDevice
{
	/// <summary>
	/// ¶Ô .Net µÄ SerialPort ½øĞĞ¼òµ¥·â×°£¬ĞÎ³ÉÍ¬²½ÊÕ·¢µÄ×¨ÓÃ°æ±¾
	/// Èç¹ûĞèÒªÔÚÏµÍ³ÄÚ²¿Ê¹ÓÃ´®¿Ú£¬±ØĞE¹ÓÃÕâ¸öÀà£¨SerialPortSync£©
	/// </summary>
	public class SerialPortSync : IDisposable
	{
		private System.IO.Ports.SerialPort _PortObj;					// ÓÃÓÚÊÕ·¢Êı¾İµÄ´®¿Ú
		private int _PortNo;											// ¶Ë¿ÚºÅ£¬ÀıÈç¡°COM1:¡±ÓÃ 1 ±úæ¾

		private int _BaudRate;
		private int _DataBits;
		private StopBits _StopBites;
		private Parity _Parity;

		private TimeSpan _MaxTimeout;									// ×ûĞó³¬Ê±¼ä¸ô£¨¶Á/Ğ´£©£¬Ä¬ÈÏ1ÃE
		#region ÊôĞÔ´úÂEE		
        public int PortNo
		{
			get { return _PortNo; }
			set { _PortNo = value; }
		}

		public int DataBits
		{
			get { return _DataBits; }
		}

		public int BytesToRead
		{
			get { return (_PortObj == null ? 0 : _PortObj.BytesToRead); }
		}

		public int BytesToWrite
		{
			get { return (_PortObj == null ? 0 : _PortObj.BytesToWrite); }
		}

		public string NewLine
		{
			get { return (_PortObj == null ? String.Empty : _PortObj.NewLine); }
			set { if (_PortObj != null)_PortObj.NewLine = value; }
		}

		public bool IsOpen
		{
			get
			{
				return (_PortObj == null ? false : _PortObj.IsOpen);
			}
		}

		public TimeSpan MaxTimeout
		{
			get { return _MaxTimeout; }
			set { _MaxTimeout = value; }
		}

		#endregion

		public SerialPortSync()
		{
			_PortNo = 0;
			_PortObj = null;
			_BaudRate = 9600;
			_DataBits = 8;
			_StopBites = StopBits.One;
			_Parity = Parity.None;

			_MaxTimeout = TimeSpan.FromSeconds(1);
		}

		public SerialPortSync(System.IO.Ports.SerialPort existedPort)
		{
			_PortNo = Convert.ToInt16(existedPort.PortName.Substring(3));
			_PortObj = existedPort;
			_BaudRate = existedPort.BaudRate;
			_DataBits = existedPort.DataBits;
			_StopBites = existedPort.StopBits;
			_Parity = existedPort.Parity;

			_PortObj.ReadTimeout = 100;
			_MaxTimeout = TimeSpan.FromSeconds(1);
		}

		/// <summary>
		/// Ä¬ÈÏ²ÉÓÃÔ¤Éè²¨ÌØÂÊ´ò¿ª COM1.
		/// </summary>
		public bool OpenPort()
		{
			try {
				OpenPort(_PortNo, 9600);
			} catch (Exception e) {
				Trace.WriteLine(e.ToString());
			}
			return (IsOpen);
		}

		public bool OpenPort(int portNo, int baudRate)
		{
			return OpenPort(portNo, baudRate, 8, _StopBites, _Parity, Handshake.None);
		}

		/// <summary>
		/// Ê¹ÓÃÖ¸¶¨²ÎÊı´ò¿ª´®¿Ú
		/// </summary>
		/// <param name="portNo"></param>
		/// <param name="openParamString">´ò¿ª´®¿ÚµÄ²ÎÊı£¬ĞÎÈç¡°9600,n,8,1¡±</param>
		/// <returns></returns>
		public bool OpenPort(int portNo, string openParamString)
		{
			SerialParam sp = new SerialParam(openParamString);
			return (OpenPort(portNo, sp.BaudRate, sp.DataBits, sp.StopBits, sp.Parity, Handshake.None));
		}

		public bool OpenPort(int portNo, int baudRate, int dataBits, StopBits stopBites, Parity parity, Handshake handshake)
		{

			_PortNo = portNo;

			if (_PortNo == 0) {
				Debug.Assert(false, "±ØĞE×ÏÈÉè¶¨´®¿ÚºÅ£¬·ñÔòÎŞ·¨´ò¿ª£¡");
				return (false);										// Ã»ÓĞÉè¶¨¶Ë¿ÚºÅ
			}

			if (_PortObj == null) 
            {
				_PortObj = SerialPortManager.Instance.GetComPortInstance(_PortNo);
			}
			if (_PortObj == null) {
				Debug.Print("´®¿Ú COM{0}: ²»´æÔÚ.ÇEEéÅäÖÃ»ò³ÌĞE", portNo);
				return (false);
			} else {

				try {
					if (!_PortObj.IsOpen) {
						_PortObj.BaudRate = baudRate;							// Ä¬ÈÏËÙÂÊ¡¢Êı¾İÎ»¡¢Í£Ö¹Î»¡¢Ğ£ÑéÎ»µÈ²ÎÊı
						_PortObj.DataBits = dataBits;
						_PortObj.StopBits = stopBites;
						_PortObj.Parity = parity;
						_PortObj.Handshake = handshake;
						_PortObj.DtrEnable = true;
						_PortObj.ReceivedBytesThreshold = 256;
						//m_PortObj.RtsEnable = false;
						//m_PortObj.DiscardNull = false;
						//m_PortObj.ReadBufferSize = 20480;
						//m_PortObj.WriteBufferSize = 10240;
						//m_PortObj.NewLine = string.Empty;
						_PortObj.ReadTimeout = 10000;
						_PortObj.WriteTimeout = Timeout.Infinite;
						_PortObj.Open();

						_PortObj.ErrorReceived += new SerialErrorReceivedEventHandler(this.OnSerialErrorReceivedEvent);

					} else {
						Debug.Print("³¢ÊÔ´ò¿ª´®¿Ú {0}: Ê±£¬·¢ÏÖÆäÔçÒÑ´ò¿ª£¬¿ÉÄÜÊÇÏµÍ³ÖĞµÄ¶à¸öÉè±¸Ê¹ÓÃÁËÏàÍ¬µÄ´®¿ÚºÅ£¡ÇEĞÏ¸¼Eé¡£Èç¹ûÏµÍ³Ê¹ÓÃ¹²ÏúÑÄ´®ĞĞÉè±¸£¬Ôò²»ÔÙ´ËÏŞ¡£", _PortObj.PortName);
					}
				} catch (UnauthorizedAccessException e) {						// ´®¿Ú²»´æÔÚ»òÒÑ¾­±»ÆäËû³ÌĞò´ò¿ª
					Debug.Print("´®¿Ú {0}: ²»´æÔÚ»òÒÑ¾­±»ÆäËû³ÌĞò´ò¿ª", _PortObj.PortName, e.ToString());
					_PortObj.Dispose();
					_PortObj = null;
				} catch (Exception e) {
					Debug.Print("´®¿Ú {0}: ´ò¿ªÊ§°Ü", _PortObj.PortName, e.ToString());
				}
			}
			return (true);
		}

		public void ClosePort()
		{
			if (_PortObj != null) {
				if (_PortObj.IsOpen) {
					_PortObj.Close();
				}
				_PortObj.Dispose();
				_PortObj = null;
			}
		}

		public void Write(string s)
		{
			_PortObj.Write(s);
		}

		public void Write(byte[] buff)
		{
			Write(buff, 0, buff.Length);
		}

		public void Write(byte[] buff, int offset, int count)
		{
			_PortObj.Write(buff, offset, count);
		}

		public string ReadExisting()
		{
			return (_PortObj.ReadExisting());
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			int bytesToRead = _PortObj.BytesToRead;

			try {
				if (bytesToRead > 0) {
					return (_PortObj.Read(buffer, offset, Math.Min(buffer.Length - offset, count)));
				}
			} catch (IOException e) {
				int errno = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
				if (errno != 997) {
					Debug.Print("{0}\tÍ¬²½¶Á·¢ÏÖÒE££¡ COM{1}, Read(buffer size={2},offset={3},count={4}),BytesToRead={5},Win32Error={6} \r\n\t {7}",
								DateTime.Now,
								_PortNo, buffer.Length, offset, count, bytesToRead, errno, e.ToString());
				}

			}
			return (0);
		}

		/// <summary>
		/// Í¬²½¶ÁÊı¾İ¡£Ö±µ½ÒòÎª£º»º³åÇøÂú¡¢³¬Ê±
		/// </summary>
		/// <param name="buffer">·µ»ØµÄ»º³åÇE/param>
		/// <param name="offset">´æ·Åµ½»º³åÇøµÄÆğÊ¼Æ«ÒÆÁ¿</param>
		/// <param name="count">×ûĞó×Ö½ÚÊı</param>
		/// <param name="timeout">³¬Ê±</param>
		/// <returns></returns>
		public int ReadSync(byte[] buffer, int offset, int count, TimeSpan timeout)
		{
			return ReadSync(buffer, offset, count, timeout, null);
		}

		/// <summary>
		/// Í¬²½¶ÁÊı¾İ¡£Ö±µ½ÒòÎª£º»º³åÇøÂú¡¢³¬Ê±¡¢³öÏÖÈÎÒ»½áÊø±EÇ
		/// ×¢Òâ£ºÊÕµ½½áÊø±EÇÊ±£¬²»ÄÜ¼Ù¶¨»òÈ·±£ËE¡ºÃ´¦ÓÚ»º³åÇøµÄÎ²²¿
		/// </summary>
		/// <param name="buffer">·µ»ØµÄ»º³åÇE/param>
		/// <param name="offset">´æ·Åµ½»º³åÇøµÄÆğÊ¼Æ«ÒÆÁ¿</param>
		/// <param name="count">×ûĞó×Ö½ÚÊı</param>
		/// <param name="timeout">³¬Ê±</param>
		/// <param name="endFlags">½áÊø±EÇ×é£¬Ò»µ©½ÓÊÕ»º³åÇøÖĞ·¢ÏÖÈÎÒ»½áÊø±EÇ,Ôò²»ÔÙ¼ÌĞø¶ÁÈ¡</param>
		/// <returns></returns>
		public int ReadSync(byte[] buffer, int offset, int count, TimeSpan timeout, List<byte[]> endFlags)
		{
			DateTime start = DateTime.Now;
			int len = offset;

			while (DateTime.Now.Subtract(start).TotalMilliseconds < timeout.TotalMilliseconds) {                  // Á¬Ğø³¬Ê±Ö¸¶¨´ÎÊı£¬Ôò²»ÔÙµÈ´ı

				if (_PortObj.BytesToRead == 0) System.Threading.Thread.Sleep(1);
				len = len + _PortObj.Read(buffer, len, count - len);

				// ²éÑ¯½ÓÊÕµ½µÄ»º³åÇøÖĞÊÇ·ñ³öÏÖÌØÕ÷×Ö
				if (endFlags != null) {
					foreach (byte[] bytsMark in endFlags) {
						for (int i = 0; i < (len - bytsMark.Length); i++) {
							bool found = true;

							for (int k = 0; k < bytsMark.Length; k++) {
								if (buffer[i + k] != bytsMark[k]) {
									found = false;
									break;
								}
							}

							if (found) goto LBL_EXIT;
						}
					}
				}
			}

		LBL_EXIT:
			return (len);
		}

		public void DiscardInBuffer()
		{
			_PortObj.DiscardInBuffer();
		}

		public void DiscardOutBuffer()
		{
			_PortObj.DiscardOutBuffer();
		}

		private void OnSerialErrorReceivedEvent(Object sender, SerialErrorReceivedEventArgs e)
		{
			//Debug.Assert( false, e.ToString( ) );
		}

		#region IDisposable ³ÉÔ±
		public void Dispose()
		{
			if (_PortObj != null) {
				ClosePort();
			}
			_PortObj = null;
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
