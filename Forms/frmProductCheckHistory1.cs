using BMS.Business;
using BMS.Model;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using BMS.Utils;
using System.IO;
using System.Threading.Tasks;

namespace BMS
{
	public partial class frmProductCheckHistory1 : _Forms
	{
		public long _WorkerID = 0;
		string _order = "";
		string _productCode = "";
		string _tienTo = "";
		string _stt = "";
		int _stepIndex = 0;
		Color _colorEmpty;
		string _GroupCode;

		int oldHeight = 0;
		int oldHeightGrid = 0;
		//DateTime _sTimeDelay;


		int _productID = 0;
		//Thread _threadDelay;
		Thread _threadRisk;
		Thread _threadFreeze;
		Thread _threadCheckColorCD;
		Thread _threadResetSocket;
		Thread _threadGetAndonDetailsByCD;
		private Thread _threadLoadAndon;

		string _socketIPAddress = "192.168.1.46";
		int _socketPort = 3000;
		Socket _socket;
		ASCIIEncoding _encoding = new ASCIIEncoding();

		int _currentIndex = 0;
		int _totalTimeDelay = 0;
		int _taktTime = 10;
		string _step;

		int _status = 0;
		bool _isStart = false;
		bool _isLogin = false;
		DateTime _startMakeTime;
		DateTime _endMakeTime;

		DateTime _sTimeRisk;
		DateTime _eTimeRisk;
		DataTable _dtData = new DataTable();
		AndonModel _oAndonModel;

		string _pathFileConfigUpdate = Path.Combine(Application.StartupPath, "ConfigUpdate.txt");
		string _pathFolderUpdate = "";
		string _pathUpdateServer = "";
		string _pathFileVersion = "";
		string _pathError = Path.Combine(Application.StartupPath, "Errors");

		public frmProductCheckHistory1()
		{
			InitializeComponent();
		}
		private void frmProductCheckHistory1_Load(object sender, EventArgs e)
		{
			DocUtils.InitFTPQLSX();
			if (File.Exists(_pathFileConfigUpdate))
			{
				//Check update version
				updateVersion();
			}
			else
			{
				MessageBox.Show("File ConfigUpdate.txt is not exist!");
			}

			_oAndonModel = new AndonModel();
			try
			{
				//Load ra config trong database lấy takt time, địa chỉ tcp, port
				DataTable dtConfig = TextUtils.Select("SELECT TOP 1 * FROM dbo.AndonConfig with (nolock)");
				_taktTime = TextUtils.ToInt(dtConfig.Rows[0]["Takt"]);
				_socketIPAddress = TextUtils.ToString(dtConfig.Rows[0]["TcpIp"]);
				_socketPort = TextUtils.ToInt(dtConfig.Rows[0]["SocketPort"]);

				IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
				IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
				_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				_socket.Connect(endPoint);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Can't connect to Andon!");
				_socket = null;
			}

			ToolTip toolTip1 = new ToolTip();
			toolTip1.ShowAlways = true;
			toolTip1.SetToolTip(this.btnSave, "F12");

			_colorEmpty = Color.FromArgb(255, 192, 255);
			initBackColor();
			oldHeight = this.Height;
			oldHeightGrid = grdData.Height;

			//Thread hiển thị giá trị delay
			_threadGetAndonDetailsByCD = new Thread(new ThreadStart(threadShowAndonDetails));
			_threadGetAndonDetailsByCD.IsBackground = true;
			_threadGetAndonDetailsByCD.Start();

			// Chạy thread load Andon theo thời gian hiện tại
			_threadLoadAndon = new Thread(new ThreadStart(threadLoadAndon));
			_threadLoadAndon.IsBackground = true;
			_threadLoadAndon.Start();

			//startThreadDelay();
			startThreadFreeze();
			startThreadCheckColorCD();
			startThreadResetSocket();
		}
		void updateVersion()
		{
			try
			{
				string[] lines = File.ReadAllLines(_pathFileConfigUpdate);
				string[] stringSeparators = new string[] { "||" };
				string[] arr = lines[1].Split(stringSeparators, 4, StringSplitOptions.RemoveEmptyEntries);
				_pathFolderUpdate = Path.Combine(Application.StartupPath, arr[1].Trim());
				_pathUpdateServer = arr[2].Trim();
				_pathFileVersion = Path.Combine(Application.StartupPath, arr[3].Trim());

				if (!Directory.Exists(_pathError))
				{
					Directory.CreateDirectory(_pathError);
				}
				if (!Directory.Exists(_pathFolderUpdate))
				{
					Directory.CreateDirectory(_pathFolderUpdate);
				}
				if (!File.Exists(_pathFileVersion))
				{
					File.Create(_pathFileVersion);
					File.WriteAllText(_pathFileVersion, "1");
				}
				int currentVerion = TextUtils.ToInt(File.ReadAllText(_pathFileVersion).Trim());
				string[] listFileSv = DocUtils.GetFilesList(_pathUpdateServer);

				if (listFileSv == null)
				{
					MessageBox.Show("Can't connect to server!");
					return;
				}
				else
				{
					listFileSv = listFileSv.ToList().Where(o => o.Contains(".zip")).ToArray();
					Array.Reverse(listFileSv);
				}

				string fileName = listFileSv[0];
				if (!fileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
				int newVersion = TextUtils.ToInt(fileName.Split('.')[0]);
				if (newVersion > currentVerion)
				{
					Process.Start(Path.Combine(Application.StartupPath, "UpdateVersion.exe"));
				}
			}
			catch
			{
				MessageBox.Show("Can't connect to server!");
				return;
			}
		}
		void checkColorCD()
		{
			while (true)
			{
				Thread.Sleep(300);
				try
				{
					DataTable dt = TextUtils.Select("select top 1 * from StatusColorCD with (nolock)");
					if (dt.Rows.Count == 0) continue;
					for (int i = 1; i <= 10; i++)
					{
						string step = "";

						if (i == 10)
						{
							step = "CD81";
						}
						else
						{
							step = "CD" + i;

						}
						_status = TextUtils.ToInt(dt.Rows[0][step]);
						this.Invoke((MethodInvoker)delegate
						{
							Control control = pannelBot.Controls.Find("lbl" + step, true)[0];
							switch (_status)
							{
								case 1:
									control.BackColor = Color.White;
									if (!_isStart)
									{
										_isStart = true;
										_startMakeTime = DateTime.Now;
									}
									break;
								case 2:
									control.BackColor = Color.Yellow;
									break;
								case 3:

									control.BackColor = Color.Red;
									break;
								case 4:
									control.BackColor = Color.Lime;
									break;
								case 5:
									control.BackColor = Color.FromArgb(192, 192, 255);
									break;
								default:
									break;
							}
						});
					}

				}
				catch (Exception)
				{

				}
			}
		}
		void startThreadFreeze()
		{
			_threadFreeze = new Thread(checkFreeze);
			_threadFreeze.IsBackground = true;
			_threadFreeze.Start();
		}
		void threadShowAndonDetails()
		{
			while (true)
			{
				Thread.Sleep(1000);
				if (string.IsNullOrWhiteSpace(_step)) continue;
				try
				{
					DataSet dts = TextUtils.GetListDataFromSP("spGetAndonDetailsByCD"
						, new string[1] { "@CD" }
						   , new object[1] { _step });
					DataTable data = dts.Tables[0];

					this.Invoke((MethodInvoker)delegate
					{
						txtNumDelay.Text = TextUtils.ToString(data.Rows[0]["TotalDelayNum"]);
						txtTimeDelay.Text = TextUtils.ToString(data.Rows[0]["TotalDelayTime"]);
					});
				}
				catch (Exception ex)
				{
					File.AppendAllText(_pathError + "/Error_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt",
							 DateTime.Now.ToString("HH:mm:ss") + ":threadShowAndonDetails(): " + ex.ToString() + Environment.NewLine);
				}
			}
		}
		void threadLoadAndon()
		{
			while (true)
			{
				Thread.Sleep(500);
				try
				{
					// Store load Andon theo ngày giờ hiện tại
					ArrayList arr = AndonBO.Instance.GetListObject("spGetAndonByDateTimeNow", new string[] { }, new object[] { });
					if (arr.Count > 0)
					{
						_oAndonModel = (AndonModel)arr[0];
					}
					else
					{
						_isStart = false;
						_oAndonModel = new AndonModel();
					}
				}
				catch (Exception ex)
				{
					_oAndonModel = new AndonModel();

					File.AppendAllText(_pathError + "/Error_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt",
						DateTime.Now.ToString("HH:mm:ss") + ":LoadAndon(): " + ex.ToString() + Environment.NewLine);
				}
			}
		}
		void startThreadResetSocket()
		{
			_threadResetSocket = new Thread(resetSocket);
			_threadResetSocket.IsBackground = true;
			_threadResetSocket.Start();
		}
		void startThreadCheckColorCD()
		{
			_threadCheckColorCD = new Thread(checkColorCD);
			_threadCheckColorCD.IsBackground = true;
			_threadCheckColorCD.Start();
		}
		void resetSocket()
		{
			while (true)
			{
				Thread.Sleep(1000);

				if (_socket == null)
				{
					try
					{
						IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
						IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
						_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						_socket.Connect(endPoint);
					}
					catch
					{
						_socket = null;
					}
				}
			}
		}

		/// <summary>
		/// Kiểm tra xem có công đoạn khác nào bị delay, và công đoạn này ko bị delay
		/// Thì sẽ đóng băng form lại ko cho thao tác
		/// </summary>
		/// 
		void checkFreeze()
		{
			while (true)
			{
				Thread.Sleep(1000);
				try
				{

					if (_oAndonModel == null || _isLogin)
					{
						this.Invoke((MethodInvoker)delegate
						{
							textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = true;
						});
						continue;
					}

					string stepCode = "";
					bool enable = true;
					this.Invoke((MethodInvoker)delegate
					{
						stepCode = cboWorkingStep.Text.ToString().Trim();
					});

					if (stepCode == "") continue;
					if (stepCode == "CD8-1") stepCode = "CD81";

					DataTable dt = TextUtils.Select("select top 1 * from StatusColorCD");
					if (dt.Rows.Count == 0) continue;
					int currentStatus = TextUtils.ToInt(dt.Rows[0][stepCode]);
					if (currentStatus == 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = enable;
						});
						continue;
					}

					for (int i = 1; i <= 10; i++)
					{
						string step = "";
						int status = 0;
						if (i == 10)
						{
							step = "CD81";
							status = TextUtils.ToInt(dt.Rows[0]["CD81"]);
							step = "CD8-1";
						}
						else
						{
							step = "CD" + i;
							status = TextUtils.ToInt(dt.Rows[0][step]);
						}

						if (step == stepCode) continue;

						if (status == 2)
						{
							enable = false;
							break;
						}
					}

					this.Invoke((MethodInvoker)delegate
					{
						textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = enable;
					});
					/*if (currentStatus == 1 || currentStatus == 2 || currentStatus == 5 && enable == false)
					{
						enable = true;
					}
					else
					{
						enable = false;
					}
					this.Invoke((MethodInvoker)delegate
					{
						textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = enable;
					});*/
				}
				catch (Exception)
				{
				}
			}
		}

		/// <summary>
		/// Gửi thông điệp lên andon
		/// </summary>
		/// <param name="value">Giá trị, trạng thái</param>
		/// <param name="type">1:sự cố, 2: đã hoàn thành, 3: cập nhật SL thực tế, 4: khởi động ca</param>
		void sendDataTCP(string value, string type)
		{
			try
			{
				//Gửi tín hiệu delay xuống server Andon qua TCP/IP
				if (_socket != null && _socket.Connected)
				{
					this.Invoke((MethodInvoker)delegate
					{
						string sendData = string.Format("{0};{1};{2}", cboWorkingStep.Text.Trim(), value, type);
						byte[] data = _encoding.GetBytes(sendData);
						_socket.Send(data);
					});
				}
			}
			catch (Exception ex)
			{
				//Ghi log vào 
				_socket = null;
			}
		}

		/// <summary>
		/// Set focus vào cell trên grid
		/// </summary>
		/// <param name="indexRow"></param>
		/// <param name="indexColum"></param>
		/// 
		void resetControl()
		{
			/*
             * reset lại tiêu đề cột, các kết quả check
             */
			for (int i = 3; i < 9; i++)
			{
				grvData.Columns["RealValue" + (i - 2)].Caption = "#";

				Control control = pannelBot.Controls.Find("textbox" + (i - 2), false)[0];
				control.Text = "";
			}
		}

		void initBackColor()
		{
			if (cboWorkingStep.SelectedIndex > 0)
			{
				cboWorkingStep.BackColor = Color.White;
			}
			else
			{
				cboWorkingStep.BackColor = _colorEmpty;
			}

			if (string.IsNullOrWhiteSpace(txtQRCode.Text))
			{
				txtQRCode.BackColor = _colorEmpty;
			}
			else
			{
				txtQRCode.BackColor = Color.White;
			}

			if (string.IsNullOrWhiteSpace(txtWorker.Text))
			{
				txtWorker.BackColor = _colorEmpty;
			}
			else
			{
				txtWorker.BackColor = Color.White;
			}

			if (string.IsNullOrWhiteSpace(txtOrder.Text))
			{
				txtOrder.BackColor = _colorEmpty;
			}
			else
			{
				txtOrder.BackColor = Color.White;
			}
		}

		void loadComboStep(string productCode)
		{
			DataTable dt = TextUtils.LoadDataFromSP("spGetProductStep_ByProductCode", "A"
				, new string[1] { "@ProductCode" }
				, new object[1] { productCode });
			DataRow dr = dt.NewRow();
			dr["ID"] = 0;
			dr["ProductStepCode"] = "";
			dt.Rows.InsertAt(dr, 0);

			cboWorkingStep.DataSource = dt;
			cboWorkingStep.DisplayMember = "ProductStepCode";
			cboWorkingStep.ValueMember = "ID";

			if (_stepIndex > 0 && _stepIndex < dt.Rows.Count)
			{
				cboWorkingStep.SelectedIndex = _stepIndex;
			}
		}

		/// <summary>
		/// Load danh sách công đoạn kiểm tra
		/// </summary>
		void loadDataWorkingStep()
		{
			if (!string.IsNullOrWhiteSpace(txtQRCode.Text.Trim()))
			{
				string orderCode = txtQRCode.Text.Trim();
				string[] arr = orderCode.Split(' ');
				if (arr.Length > 1)
				{
					loadComboStep(arr[1]);
				}
				else
				{
					cboWorkingStep.DataSource = null;
				}
			}
			else
			{
				cboWorkingStep.DataSource = null;
			}
		}

		int getSumHeightRows()
		{
			int total = 0;
			GridViewInfo vi = grvData.GetViewInfo() as GridViewInfo;
			for (int i = 0; i < grvData.RowCount; i++)
			{
				GridRowInfo ri = vi.RowsInfo.FindRow(i);
				if (ri != null)
					total += ri.Bounds.Height;
			}

			return total;
		}

		int getRowIndex(int columnIndex)
		{
			int rowIndex = -1;
			for (int i = 0; i < _dtData.Rows.Count; i++)
			{
				DataRow r = _dtData.Rows[i];
				string value = TextUtils.ToString(r["RealValue" + (columnIndex - 2)]);
				int type = TextUtils.ToInt(r["ValueType"]);
				int checkValueType = TextUtils.ToInt(r["CheckValueType"]);
				string standardValue = TextUtils.ToString(r["StandardValue"]);
				if ((string.IsNullOrWhiteSpace(value) && type > 0) || (checkValueType == 2 && string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(standardValue)))
				{
					rowIndex = i;
					break;
				}
			}
			if (rowIndex == -1)
			{
				rowIndex = grvData.RowCount - 1;
			}
			return rowIndex;
		}

		void setFocusCell(int indexRow, int indexColum)
		{
			if (indexRow <= grvData.RowCount - 1)
			{
				grvData.FocusedRowHandle = indexRow;

				grvData.FocusedColumn = grvData.VisibleColumns[indexColum];

				grvData.ShowEditor();
			}
			else
			{
				(pannelBot.Controls.Find("textBox" + (indexColum - 2), true)[0]).Focus();
			}
		}

		int getNextIndex(int index)
		{
			int valueIndex = grvData.RowCount;
			for (int i = index + 1; i < grvData.RowCount; i++)
			{
				int valueType = TextUtils.ToInt(grvData.GetRowCellValue(i, colValueType));
				if (valueType == 1)//Kiểu giá trị
				{
					valueIndex = i;
					break;
				}
			}

			return valueIndex;
		}

		/// <summary>
		/// Set caption cho các cột nhập giá trị kiểm tra
		/// Cái này làm cho dự án thêm hạng mục kiểm tra order sản phẩm
		/// </summary>
		void setCaptionGridColumn()
		{
			for (int i = 0; i < 6; i++)
			{
				if (_stt.Length > (int.Parse(_stt) + i).ToString().Length)
				{
					int lech = _stt.Length - (int.Parse(_stt) + i).ToString().Length;
					StringBuilder sokhong = new StringBuilder();
					for (int j = 0; j < lech; j++)
					{
						sokhong.Append("0");
					}

					grvData.Columns["RealValue" + (i + 1)].Caption = sokhong + (int.Parse(_stt) + i).ToString();
				}
				else
				{
					grvData.Columns["RealValue" + (i + 1)].Caption = (int.Parse(_stt) + i).ToString();

				}
			}
		}

		bool _isStartColor = false;
		//bool _isStart = false;
		private void cboWorkingStep_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Stopwatch s = new Stopwatch();
			//s.Start();

			if (string.IsNullOrEmpty(txtWorker.Text.Trim()) && cboWorkingStep.SelectedIndex != 0)
			{
				MessageBox.Show("Bạn chưa nhập tên người làm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWorker.Focus();
				return;
			}
			_step = cboWorkingStep.Text.Trim();

			if (cboWorkingStep.Text.Trim() == "CD1")
			{
				sendDataTCP("0", "4");
			}
			_isStartColor = false;
			int workingStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
			string qrCode = txtQRCode.Text.Trim();
			if (string.IsNullOrWhiteSpace(qrCode)) return;

			if (cboWorkingStep.SelectedIndex > 0)
			{
				cboWorkingStep.BackColor = Color.White;
			}
			else
			{
				cboWorkingStep.BackColor = _colorEmpty;
			}

			resetControl();

			if (workingStepID == 0)
			{
				_dtData = null;
				grdData.DataSource = null;
				txtStepName.Text = "";
				return;
			}

			//Sinh ra file lưu tên công đoạn
			File.WriteAllText(Application.StartupPath + "\\CD.txt", cboWorkingStep.Text.Trim());

			/*
             * Tách chuỗi QrCode
             */
			string orderCode = txtQRCode.Text.Trim();
			string[] arr1 = orderCode.Split(' ');
			if (arr1.Length > 1)
			{
				_order = arr1[0];
				_productCode = arr1[1].Trim();
				string[] arr;
				if (_order.Contains("-"))
				{
					arr = _order.Split('-');
					_tienTo = (arr[0] + "-" + arr[1] + "-");
					_stt = arr[2];
				}
				else
				{
					arr = Regex.Split(_order, @"\D+");
					_stt = arr[arr.Length - 1];
					_tienTo = _order.Substring(0, _order.IndexOf(_stt));
				}
			}

			//Ghi dữ liệu trạng thái vào bảng StatusCD
			string stepCode = cboWorkingStep.Text.Trim();
			//if (stepCode == "CD8-1") stepCode = "CD81";
			//string sqlUpdate = string.Format("Update StatusCD WITH (ROWLOCK) set {0} = 1", stepCode);
			//TextUtils.ExcuteSQL(sqlUpdate);

			//Hiển thị nút không sử dụng khi chọn xong công đoạn
			btnNotUseCD8.Visible = true;

			//Gán dữ liệu vào grid
			DataSet ds = ProductCheckHistoryDetailBO.Instance.GetDataSet("spGetWorkingByProduct",
				new string[] { "@WorkingStepID", "@WorkingStepCode", "@ProductCode" },
				new object[] { workingStepID, stepCode, arr1[1].ToString() });

			_dtData = ds.Tables[0];
			grdData.DataSource = _dtData;
			txtStepName.Text = TextUtils.ToString(ds.Tables[1].Rows.Count > 0 ? ds.Tables[1].Rows[0][0] : "");

			_GroupCode = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ProductGroupCode"] : "");
			txtName.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ProductName"] : "");
			txtMo.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["LoaiMo"] : "");
			txtGoal.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["Goal"] : "");

			string gunNumber = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["GunNumber"] : "");
			string jobNumber = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["JobNumber"] : "");
			string qtyOcBanGa = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QtyOcBanGa"] : "");
			string qtyOcBanThat = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QtyOcBanThat"] : "");
			_productID = TextUtils.ToInt(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ID"] : "");

			string file = string.Format("{0};{1};{2};{3}", gunNumber, jobNumber, qtyOcBanGa, qtyOcBanThat);
			try
			{
				System.IO.File.WriteAllText(Application.StartupPath + "\\SettingsTouque.txt", file);
			}
			catch
			{
			}

			// Set lại chiều cao của dòng
			if (grvData.RowCount > 0)
			{
				grvData.RowHeight = -1;
				int totalHeightRow = this.getSumHeightRows();
				if ((oldHeightGrid - grvData.ColumnPanelRowHeight - 30) > totalHeightRow)
				{
					grvData.RowHeight = (oldHeightGrid - grvData.ColumnPanelRowHeight - 30) / grvData.RowCount;
				}
			}

			//Nhảy đến ô cần điền giá trị đầu tiên
			int cIndex = grvData.Columns["RealValue1"].VisibleIndex;
			setFocusCell(getRowIndex(cIndex), cIndex);

			_isStartColor = true;

			setCaptionGridColumn();

			_currentIndex = 1;//đánh dấu số thứ tự sản phẩm được check trong order 

		}
		async void saveMasterAsync(string qrCode, int productID, string orderCode)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				if (!ProductCheckHistoryBO.Instance.CheckExist("QRCode", qrCode))
				{
					ProductCheckHistoryModel master = new ProductCheckHistoryModel();
					master.DateLR = DateTime.Now;
					master.QRCode = qrCode;
					master.ProductCode = _productCode;
					master.ProductID = productID;
					master.OrderCode = orderCode;
					ProductCheckHistoryBO.Instance.Insert(master);
				}
			});
			await task;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (grvData.RowCount == 0)
			{
				return;
			}

			int productID = _productID;
			int stepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
			if (productID == 0)
			{
				MessageBox.Show(string.Format("Không tồn tại sản phẩm có mã [{0}]!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (stepID == 0)
			{
				MessageBox.Show(string.Format("Bạn chưa chọn công đoạn nào!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(txtWorker.Text.Trim()))
			{
				MessageBox.Show(string.Format("Bạn chưa điền người làm!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWorker.Focus();
				return;
			}
			bool isHasValue = false;
			for (int i = 1; i < 7; i++)
			{
				Control control = pannelBot.Controls.Find("textbox" + i, false)[0];
				if (control.Text == "0" || control.Text == "1")
				{
					isHasValue = true;
					break;
				}
			}
			if (!isHasValue)
			{
				//MessageBox.Show("Bạn chưa nhập các giá trị kiểm tra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult result = MessageBox.Show("Bạn có chắc muốn cất dữ liệu?", "Cất?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No) return;

			int count = _dtData.Rows.Count;
			//TimeSpan b = new TimeSpan();
			//Stopwatch stopwatch = new Stopwatch();
			//stopwatch.Start();
			for (int i = 3; i < 9; i++)
			{
				Control control = pannelBot.Controls.Find("textbox" + (i - 2), false)[0];
				string columnCaption = grvData.Columns[i].Caption;
				string qrCode = "";
				if (string.IsNullOrEmpty(control.Text.Trim()))
					continue;
				else
				{
					qrCode = _tienTo + columnCaption + " " + _productCode;
				}
				if (string.IsNullOrWhiteSpace(control.Text.Trim()) || TextUtils.ToInt(control.Text.Trim()) > 1
					|| TextUtils.ToInt(control.Text.Trim()) < 0)
				{
					continue;
				}
				string orderCode = string.IsNullOrWhiteSpace(txtOrder.Text.Trim()) ?
						(_tienTo.Contains("-") ? _tienTo.Substring(0, _tienTo.Length - 1) : _order) :
						txtOrder.Text.Trim();

				/*
                 * Xóa các giá trị đã lưu cũ
                 */
				// ProductCheckHistoryDetailBO.Instance.DeleteByExpression(new Utils.Expression("QRCode", qrCode).And(new Utils.Expression("ProductStepID", stepID)));

				/*
                 * Insert Master
                 */
				saveMasterAsync(qrCode, productID, orderCode);
				/*
                 * Insert Detail dữ liệu kiểm tra vào bảng
                 */
				for (int j = 0; j < count; j++)
				{
					ProductCheckHistoryDetailModel cModel = new ProductCheckHistoryDetailModel();
					//cModel.ProductCheckHistoryID = masterID;
					cModel.ProductStepID = stepID;
					cModel.ProductStepCode = cboWorkingStep.Text.Trim();
					cModel.ProductStepName = txtStepName.Text.Trim();
					cModel.SSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSSortOrder));

					cModel.ProductWorkingID = TextUtils.ToInt(grvData.GetRowCellValue(j, colWorkingID));
					cModel.ProductWorkingName = TextUtils.ToString(grvData.GetRowCellValue(j, colProductWorkingName));
					cModel.WSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSortOrder));

					cModel.WorkerCode = txtWorker.Text.Trim();
					cModel.StandardValue = TextUtils.ToString(grvData.GetRowCellValue(j, colStandardValue));
					cModel.RealValue = TextUtils.ToString(grvData.GetRowCellValue(j, "RealValue" + (i - 2)));
					cModel.ValueType = TextUtils.ToInt(grvData.GetRowCellValue(j, colValueType));
					cModel.ValueTypeName = cModel.ValueType == 1 ? "Giá trị\n数値" : "Check mark";
					cModel.EditValue1 = "";
					cModel.EditValue2 = "";
					cModel.StatusResult = TextUtils.ToInt(control.Text.Trim());
					cModel.ProductID = productID;
					cModel.QRCode = qrCode;
					cModel.OrderCode = orderCode;
					//cModel.PackageNumber = _tienTo.Contains("-") ? _tienTo.Split('-')[1] : "";
					//cModel.QtyInPackage = columnCaption;
					cModel.Approved = "";
					cModel.Monitor = "";
					cModel.DateLR = DateTime.Now;
					cModel.EditContent = "";
					cModel.EditDate = DateTime.Now;
					cModel.ProductCode = _productCode;
					cModel.ProductOrder = _order;

					ProductCheckHistoryDetailBO.Instance.Insert(cModel);
				}
			}
			//stopwatch.Stop();
			//b = stopwatch.Elapsed;

			// MessageBox.Show(string.Format("Time: {0}", b.Seconds));

			_stepIndex = cboWorkingStep.SelectedIndex;
			_currentIndex = 0;

			_totalTimeDelay = 0;

			grdData.DataSource = null;
			txtQRCode.Text = "";
			txtOrder.Text = "";
			cboWorkingStep.DataSource = null;
			btnNotUseCD8.Visible = false;
			resetControl();
			txtQRCode.Focus();
		}
		private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				txtOrder.Focus();
			}
		}
		private void txtOrder_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter)
			{
				txtWorker.Focus();
				loadDataWorkingStep();
			}
		}
		private void frmProductCheckHistory_FormClosed(object sender, FormClosedEventArgs e)
		{
			//if (_threadDelay != null) _threadDelay.Abort();
			if (_threadRisk != null) _threadRisk.Abort();
			if (_threadFreeze != null) _threadFreeze.Abort();

			Application.Exit();
		}
		private void grvData_KeyDown(object sender, KeyEventArgs e)
		{
			if (grvData.FocusedRowHandle == grvData.RowCount - 1 && e.KeyCode == Keys.Down)//dòng cuối cùng
			{
				int indexColumn = grvData.FocusedColumn.VisibleIndex;
				(pannelBot.Controls.Find("textBox" + (indexColumn - 2), true)[0]).Focus();
			}
		}
		private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if (!_isStartColor) return;
			if (e.RowHandle >= 0 && e.Column.VisibleIndex > 2)
			{
				Control control = pannelBot.Controls.Find("textbox" + (e.Column.VisibleIndex - 2), false)[0];
				if (control.Text.Trim() == "0" || control.Text.Trim() == "1")
				{
					control.BackColor = Color.White;
				}
				else
				{
					control.BackColor = _colorEmpty;
				}

				if (cboWorkingStep.Text == "CD3")
				{
					int sortOrder1 = 70;
					int sortOrder2 = 80;
					int sortOrder3 = 90;
					int sortOrder4 = 100;

					if (_GroupCode == "511" || _GroupCode == "512")
					{
						sortOrder1 = 110;
						sortOrder2 = 120;
						sortOrder3 = 130;
						sortOrder4 = 140;
					}

					int sortOrder = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colSortOrder));
					if (sortOrder == sortOrder1 || sortOrder == sortOrder2 || sortOrder == sortOrder3)
					{
						string fieldName = string.Format("RealValue{0}", e.Column.VisibleIndex - 2);

						DataRow r1 = _dtData.Select("SortOrder = " + sortOrder1)[0];
						DataRow r2 = _dtData.Select("SortOrder = " + sortOrder2)[0];
						DataRow r3 = _dtData.Select("SortOrder = " + sortOrder3)[0];
						DataRow r = _dtData.Select("SortOrder = " + sortOrder4)[0];

						List<decimal> lst = new List<decimal>() { TextUtils.ToDecimal(r1[fieldName]), TextUtils.ToDecimal(r2[fieldName]), TextUtils.ToDecimal(r3[fieldName]) };

						r[fieldName] = lst.Max() - lst.Min();
					}
					if (sortOrder == sortOrder3)
					{
						this.setFocusCell(e.RowHandle + 2, grvData.FocusedColumn.VisibleIndex);
					}
					else
					{
						this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
					}
				}
				else
				{
					this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
				}
			}
		}
		private void grvData_RowCellStyle3(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if (!_isStartColor) return;
			if (e.RowHandle < 0) return;

			if (e.Column.VisibleIndex < 3) return;

			string value = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, e.Column));
			int checkValueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colCheckValueType));
			string standardValue = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colStandardValue));
			string productWorkingName = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colProductWorkingName));
			string columnCaption = e.Column.Caption;

			if (checkValueType == 2 && !string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
			{
				if (productWorkingName.Trim().ToLower() == "checkorder")
				{
					/*
                     * Mục này kiểm tra giá trị của qrcode của từng con sản phẩm
                     */
					string qrCode = txtQRCode.Text.Trim();
					string[] arrQR = qrCode.Split(' ');
					string firstWord = arrQR[0];
					int lenghtFirstWord = firstWord.Length;
					if (firstWord.Contains("-"))
					{
						//Dạng qrcode có tiền tố chứa ký tự '-' VD: MVNL0123-0-2 911KV5067J25T
						firstWord = firstWord.Split('-')[0];
						lenghtFirstWord = firstWord.Length;
						if (value.Length < lenghtFirstWord)
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							string currentValue = value.Substring(0, lenghtFirstWord);
							if (currentValue.ToLower() == firstWord.ToLower())
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
							else
							{
								e.Appearance.BackColor = Color.Red;
							}
						}
					}
					else
					{
						//Dạng qrcode có tiền tố không chứa ký tự '-', VD: VN0123 PA120932
						string orderText = _tienTo + columnCaption;
						if (orderText.Length != firstWord.Length)
						{
							orderText = _tienTo + "0" + columnCaption;
						}
						if (value.Length < orderText.Length)
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							string currentValue = value.Substring(0, orderText.Length);
							if (currentValue.ToLower() == orderText.ToLower())
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
							else
							{
								e.Appearance.BackColor = Color.Red;
							}
						}
					}
				}
				else
				{
					/*
                     * Kiểm tra ghi chép dạng giá trị, nhưng giá trị tiêu chuẩn dạng text chứ không phải dạng số
                     */
					string[] arr = value.Split(',');
					if (arr.Length > 0)
					{
						if (arr[0].ToLower() != standardValue.ToLower())
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
						}
					}
					else
					{
						e.Appearance.BackColor = _colorEmpty;
					}
				}

				return;
			}

			int valueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colValueType));
			if (valueType <= 0)
			{
				if (checkValueType == 2 && string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
				{
					e.Appearance.BackColor = _colorEmpty;
				}
				if (value.ToUpper() == "OK")
				{
					e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
				}
				else if (value.ToUpper() == "NG")
				{
					e.Appearance.BackColor = Color.Red;
				}
				return;
			}

			if (string.IsNullOrWhiteSpace(value))
			{
				e.Appearance.BackColor = _colorEmpty;
			}
			else
			{
				decimal number = TextUtils.ToDecimal(value);
				decimal min = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMinValue));
				decimal max = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMaxValue));
				if (number < min || number > max)
				{
					e.Appearance.BackColor = Color.Red;
					e.Appearance.ForeColor = Color.FromArgb(255, 255, 0);
				}
				else
				{
					e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
				}
			}

			//102, 255, 255
		}
		private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if (!_isStartColor) return;
			if (e.RowHandle < 0) return;

			if (e.Column.VisibleIndex < 3) return;

			string value = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, e.Column));
			int checkValueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colCheckValueType));
			string standardValue = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colStandardValue));
			string productWorkingName = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colProductWorkingName));
			string columnCaption = e.Column.Caption;

			if (checkValueType == 2 && !string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
			{
				if (productWorkingName.Trim().ToLower() == "checkorder")
				{
					/*
                     * Mục này kiểm tra giá trị của qrcode của từng con sản phẩm
                     */
					string qrCode = txtQRCode.Text.Trim();
					string[] arrQR = qrCode.Split(' ');
					string firstWord = arrQR[0];
					int lenghtFirstWord = firstWord.Length;
					if (firstWord.Contains("-"))
					{
						//Dạng qrcode có tiền tố chứa ký tự '-' VD: MVNL0123-0-2 911KV5067J25T
						firstWord = firstWord.Split('-')[0];
						lenghtFirstWord = firstWord.Length;
						if (value.Length < lenghtFirstWord)
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							string currentValue = value.Substring(0, lenghtFirstWord);
							if (currentValue.ToLower() == firstWord.ToLower())
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
							else
							{
								e.Appearance.BackColor = Color.Red;
							}
						}
					}
					else
					{
						//Dạng qrcode có tiền tố không chứa ký tự '-', VD: VN0123 PA120932
						string orderText = _tienTo + columnCaption;
						if (orderText.Length != firstWord.Length)
						{
							orderText = _tienTo + "0" + columnCaption;
						}
						if (value.Length < orderText.Length)
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							string currentValue = value.Substring(0, orderText.Length);
							if (currentValue.ToLower() == orderText.ToLower())
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
							else
							{
								e.Appearance.BackColor = Color.Red;
							}
						}
					}
				}
				else
				{
					/*
                     * Kiểm tra ghi chép dạng giá trị, nhưng giá trị tiêu chuẩn dạng text chứ không phải dạng số
                     */
					string[] arr = value.Split(',');
					if (arr.Length > 0)
					{
						if (arr[0].ToLower() != standardValue.ToLower())
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
						}
					}
					else
					{
						e.Appearance.BackColor = _colorEmpty;
					}
				}

				return;
			}

			int valueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colValueType));
			if (valueType <= 0)
			{
				if (checkValueType == 2 && string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
				{
					e.Appearance.BackColor = _colorEmpty;
				}
				if (value.ToUpper() == "OK")
				{
					e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
				}
				else if (value.ToUpper() == "NG")
				{
					e.Appearance.BackColor = Color.Red;
				}
				return;
			}

			if (string.IsNullOrWhiteSpace(value))
			{
				e.Appearance.BackColor = _colorEmpty;
			}
			else
			{
				decimal number = TextUtils.ToDecimal(value);
				decimal min = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMinValue));
				decimal max = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMaxValue));
				if (number < min || number > max)
				{
					e.Appearance.BackColor = Color.Red;
					e.Appearance.ForeColor = Color.FromArgb(255, 255, 0);
				}
				else
				{
					e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
				}
			}

			//102, 255, 255
		}
		private void txt_TextChanged(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
			{
				txt.BackColor = _colorEmpty;

			}
			else
			{
				txt.BackColor = Color.White;
			}
		}
		private void textBox_TextChanged(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;

			if (txt.Text.Trim() == "0" || txt.Text.Trim() == "1")
			{
				txt.BackColor = Color.White;
			}
			else
			{
				txt.BackColor = _colorEmpty;
			}
		}
		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (grvData.RowCount == 0) return;
			TextBox textBox = (TextBox)sender;
			int textIndex = TextUtils.ToInt(textBox.Tag);

			int columnIndex = textIndex + 2;

			//Khi ấn mũi tên đi lên thì focus vào cột tương ứng
			if (e.KeyCode == Keys.Up)
			{
				setFocusCell(getRowIndex(columnIndex), columnIndex);
			}
			if (e.KeyCode == Keys.Enter)
			{
				string value = ((TextBox)sender).Text;
				string valueString = "";// 
				if (value == "1")
				{
					valueString = "OK";
				}
				else if (value == "0")
				{
					valueString = "NG";
				}

				//Set giá trị các ô có giá trị check mark
				for (int i = 0; i < _dtData.Rows.Count; i++)
				{
					DataRow r = _dtData.Rows[i];

					int checkValueType = TextUtils.ToInt(r["CheckValueType"]);
					string standardValue = TextUtils.ToString(r["StandardValue"]);
					int valueType = TextUtils.ToInt(r["ValueType"]);

					if (valueType > 0) continue;

					if (checkValueType == 2 && !string.IsNullOrWhiteSpace(standardValue))
					{
						continue;
					}

					if (valueType == 0)
					{
						r["RealValue" + (columnIndex - 2)] = valueString;
					}
				}
				//Set tiêu đề cột trước khi chuyển sang cột mới
				if (value == "1" || value == "0")
				{
					//grvData.Columns["RealValue" + (columnIndex - 2)].Caption = (int.Parse(_stt) + columnIndex - 3).ToString();

					if (columnIndex < 8)
					{
						//focus vào ô của cột tiếp theo
						setFocusCell(getRowIndex(columnIndex + 1), columnIndex + 1);
					}
					else
					{
						btnSave.Focus();
					}
				}
				else
				{
					setFocusCell(getRowIndex(columnIndex), columnIndex);
				}


				if (_oAndonModel.ID > 0)
				{
					//Cập nhật trạng thái đã làm xong
					sendDataTCP("4", "2");

					_isStart = false;
					if (_startMakeTime == new DateTime())
					{
						_startMakeTime = DateTime.Now;
					}
					_endMakeTime = DateTime.Now;
					//Cất vào bảng AndonDetail
					AndonDetailModel andonDetail = new AndonDetailModel();
					andonDetail.ProductCode = _productCode;
					andonDetail.ProductID = _productID;
					andonDetail.ProductStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
					andonDetail.QrCode = _tienTo + grvData.Columns[columnIndex].Caption + " " + _productCode;
					andonDetail.OrderCode = txtOrder.Text.Trim();
					andonDetail.ProductStepCode = cboWorkingStep.Text.Trim();
					andonDetail.StartTime = _startMakeTime;
					andonDetail.EndTime = _endMakeTime;

					andonDetail.MakeTime = TextUtils.ToInt(Math.Round((_endMakeTime - _startMakeTime).TotalSeconds, 0));

					andonDetail.AnDonID = _oAndonModel.ID;
					andonDetail.ShiftID = _oAndonModel.ShiftID;
					andonDetail.Takt = _oAndonModel.Takt;
					if (andonDetail.MakeTime > andonDetail.Takt)
					{
						andonDetail.Type = 1;
						andonDetail.PeriodTime = andonDetail.MakeTime - _oAndonModel.Takt;
					}
					else
					{
						andonDetail.Type = 3;
						andonDetail.PeriodTime = 0;
					}

					andonDetail.WorkerCode = txtWorker.Text.Trim();
					andonDetail.OkStatus = TextUtils.ToInt(value);
					AndonDetailBO.Instance.Insert(andonDetail);

					//tăng qty actual
					if (cboWorkingStep.Text.Trim() == "CD7")
					{
						sendDataTCP("0", "3");
					}
				}
			}
		}
		private void textBox_GotFocus(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSave_Click(null, null);
		}
		private void startRiskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//startThreadRisk();
			_sTimeRisk = DateTime.Now;
			this.BackColor = Color.Red;

			//Gửi tín hiệu risk qua server Andon qua TCP/IP
			sendDataTCP("3", "1");
		}
		private void endRiskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_eTimeRisk = DateTime.Now;
			if (_sTimeRisk == new DateTime())
			{
				_sTimeRisk = DateTime.Now;
			}
			try
			{
				frmChooseRisk frm = new frmChooseRisk();
				if (frm.ShowDialog() == DialogResult.OK)
				{
					//Ghi dữ liệu sự cố vào bảng Andon
					AndonDetailModel detail = new AndonDetailModel();
					detail.ProductID = _productID;
					detail.ProductCode = _productCode;
					detail.OrderCode = txtOrder.Text.Trim();
					detail.ProductStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
					detail.ProductStepCode = cboWorkingStep.Text.Trim();
					detail.Type = 2;
					if (_oAndonModel != null)
					{
						detail.Takt = _oAndonModel.Takt;
						detail.AnDonID = _oAndonModel.ID;
						detail.ShiftID = _oAndonModel.ShiftID;


					}
					detail.PeriodTime = TextUtils.ToInt(Math.Round((_eTimeRisk - _sTimeRisk).TotalSeconds, 0));
					detail.MakeTime = 0;
					detail.StartTime = _sTimeRisk;
					detail.EndTime = _eTimeRisk;
					detail.RiskDescription = frm.RiskDescription;
					detail.WorkerCode = txtWorker.Text;

					AndonDetailBO.Instance.Insert(detail);
					// kiểm tra lại trạng thái nút Không sử dụng để gửi tín hiệu.
					if (btnNotUseCD8.Text == "Không sử dụng")
					{
						sendDataTCP("11", "10");
					}
					else
					{
						sendDataTCP("4", "2");
					}


					this.BackColor = Color.WhiteSmoke;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		bool _isUse = false;
		private void btnNotUseCD8_Click(object sender, EventArgs e)
		{
			//Khi nhấn ko sử dụng công đoạn 8 thì nó luôn cập nhật vào bảng statuscolorCD = 4 
			if (!_isUse)
			{
				//startThreadNotUseCD8();
				//TextUtils.ExcuteSQL(@"update AndonConfig set IsStopCD8 = 1");
				sendDataTCP("10", "10");
				btnNotUseCD8.Text = "Sử dụng";
				_isUse = true;
			}
			else
			{
				//TextUtils.ExcuteSQL(@"update AndonConfig set IsStopCD8 = 0");
				//if (_threadNotUseCD8 != null) _threadNotUseCD8.Abort();
				sendDataTCP("11", "10");
				_isUse = false;
				btnNotUseCD8.Text = "Không sử dụng";
				_startMakeTime = DateTime.Now;
			}
			grdData.Enabled = txtOrder.Enabled = txtQRCode.Enabled = !_isUse;
			textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = !_isUse;
		}

		private void loginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!_isLogin)
			{
				frmLogin frm = new frmLogin();
				frm.ShowDialog();
				if (frm.DialogResult == DialogResult.OK)
				{
					_isLogin = true;
				}
			}
			else
			{
				DialogResult rs = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo);
				if (rs == DialogResult.No) return;
				_isLogin = false;
			}
		}

		private void txtWorker_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtWorker.Text.Trim()))
			{
				MessageBox.Show("Bạn chưa điền tên người làm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWorker.Focus();
			}
		}

		private void txtWorker_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cboWorkingStep.Focus();
			}
		}
	}
}
