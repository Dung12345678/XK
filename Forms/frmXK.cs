using BMS.Business;
using BMS.Model;
using BMS.Utils;
using DevExpress.Skins;
using Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
	public partial class frmXK : _Forms
	{
		int _row = -1;
		string PartCode = "";
		string _pathFileConfigUpdate = Path.Combine(Application.StartupPath, "ConfigUpdate.txt");
		string _pathFolderUpdate = "";
		string _pathUpdateServer = "";
		string _pathFileVersion = "";
		string _pathError = Path.Combine(Application.StartupPath, "Errors");
		int _focusbtnSave = 0;
		DataTable dtTPSon;
		DataTable _dtOrderPart;
		DataTable dtSon;
		List<int> _lstID = new List<int>();
		List<String> lst = new List<string>();
		List<string> _lstArticleID = new List<string>();
		ASCIIEncoding _encoding = new ASCIIEncoding();
		string _socketIPAddressPicking = "172.0.0.1";
		int _socketPortPicking = 2000;
		Socket _socketPicking;
		DateTime _startMakeTime;
		DateTime _endMakeTime;
		Thread _threadLoadAll;
		Thread _threadConnect;
		string _Casse = "";
		string _Motor = "";
		DataTable _dtStockCD;
		List<int> _lstCount = new List<int>();
		List<int> _lstRow = new List<int>();

		string contentError;
		Thread _threadShelfNumber;
		public frmXK()
		{
			InitializeComponent();
		}
		private void frmAssembleStock_Load(object sender, EventArgs e)
		{
			string version = File.ReadAllText(Application.StartupPath + "/Version.txt");
			if (File.Exists(Application.StartupPath + "/Line.txt"))
			{
				cboLine.SelectedIndex = TextUtils.ToInt(File.ReadAllText(Application.StartupPath + "/Line.txt"));
			}
			this.Text += "  -  Version: " + version.Trim();
			DocUtils.InitFTPQLSX();
			//Check update version
			//updateVersion();
			//tableLayoutPanel1.SetColumnSpan(txtQtyAccessory, 3);
			//tableLayoutPanel1.SetColumnSpan(txtOrder, 3);
			tableLayoutPanel1.SetColumnSpan(txtDescriptionAssembleStock, 3);

			_startMakeTime = DateTime.Now;
			//ConnectAnDonPicking();
			loadCboStock();
			txtWorkerCode.Focus();
			NumSTT.Enabled = false;

			_threadConnect = new Thread(new ThreadStart(ConnectAnDonPicking));
			_threadConnect.IsBackground = true;
			_threadConnect.Start();

			//sendDataTCPAnDonPicking("SD", "XK");

		}
		void updateVersion()
		{
			if (!File.Exists(_pathFileConfigUpdate)) return;
			try
			{
				string[] lines = File.ReadAllLines(_pathFileConfigUpdate);
				if (lines == null) return;
				if (lines.Length < 2) return;

				string[] stringSeparators = new string[] { "||" };
				string[] arr = lines[1].Split(stringSeparators, 4, StringSplitOptions.RemoveEmptyEntries);

				if (arr == null) return;
				if (arr.Length < 4) return;

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
				if (listFileSv == null) return;
				if (listFileSv.Length == 0) return;

				List<string> lst = listFileSv.ToList();
				lst = lst.Where(o => o.Contains(".zip")).ToList();
				int newVersion = lst.Max(o => TextUtils.ToInt(Path.GetFileNameWithoutExtension(o)));

				if (newVersion != currentVerion)
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
		/// <summary>
		/// Kết nối AnDon
		/// </summary>
		void ConnectAnDonPicking()
		{
			while (true)
			{
				Thread.Sleep(200);
				try
				{
					if (_socketPicking != null && _socketPicking.Connected)
					{
						//if (!IsSocketConnected(_socketPicking))
						//{
							_socketPicking.Close(); _socketPicking = null;
						//}
					}
					else
					{
						//Load ra config trong database lấy địa chỉ tcp, port
						DataTable dtConfig = TextUtils.Select("SELECT TOP 1 * FROM [ShiStock].[dbo].[AndonPickingConfig] with (nolock)");
						_socketIPAddressPicking = TextUtils.ToString(dtConfig.Rows[0]["TcpIp"]);
						_socketPortPicking = TextUtils.ToInt(dtConfig.Rows[0]["SocketPort"]);
						IPAddress ipAddOut = IPAddress.Parse(_socketIPAddressPicking);
						IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPortPicking);
						_socketPicking = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						_socketPicking.Connect(endPoint);
						_socketPicking.ReceiveTimeout = 100;
					}
				}
				catch (Exception ex)
				{
					//MessageBox.Show("Can't connect to Andon!");
					_socketPicking = null;
				}
			}
		}
		// KIỂM TRA KẾT NỐI VỚI SERVER
		static bool IsSocketConnected(Socket socketPicking)
		{
			try
			{
				return !((socketPicking.Poll(1000, SelectMode.SelectRead) && (socketPicking.Available == 0)) || !socketPicking.Connected);
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Gửi tín hiệu lên ANDON
		/// </summary>
		/// <param name="value">  </param>
		void sendDataTCPAnDonPicking(string value, string XK)
		{
			try
			{
				//Gửi tín hiệu delay xuống server Andon qua TCP/IP
				if (_socketPicking != null && _socketPicking.Connected)
				{
					int selectedCb = -1;
					string sendData = "";
					if (cboLine.InvokeRequired) cboLine.Invoke(new Action(() => selectedCb = cboLine.SelectedIndex));
					else selectedCb = cboLine.SelectedIndex;
					if (cboKho.InvokeRequired) cboKho.Invoke(new Action(() => sendData = cboKho.Text.Trim()));
					else sendData = cboKho.Text.Trim();
					if (selectedCb == 2) return;
					try
					{
						sendData = $"{sendData};{value};{XK}";
						byte[] data = _encoding.GetBytes(sendData);
						_socketPicking.Send(data);
					}
					catch (Exception ex)
					{
						//ConnectAnDonPicking();
						ErrorLog.errorLog(value, "Truyền TCP lỗi", Environment.NewLine);
					}

				}
				else
				{
					ErrorLog.errorLog(value, "K kết nối được với AnDon", Environment.NewLine);
				}
			}
			catch (Exception ex)
			{
				//Ghi log vào 
				_socketPicking = null;
				//MessageBox.Show(ex.ToString() + Environment.NewLine);
			}
		}
		/// <summary>
		/// Load kho
		/// </summary>
		void loadCboStock()
		{
			try
			{
				DataTable dt = TextUtils.Select("SELECT * FROM dbo.AssemblyStock WITH(NOLOCK)");
				DataRow r = dt.NewRow();
				r["ID"] = 0;
				r["Name"] = "";
				dt.Rows.InsertAt(r, 0);
				cboKho.DataSource = dt;
				cboKho.DisplayMember = "Code";
				cboKho.ValueMember = "ID";
			}
			catch (Exception)
			{
			}

		}


		private void loadStockCD()
		{
			_dtStockCD = TextUtils.Select($"SELECT * FROM dbo.StockCD where StockID={TextUtils.ToInt(cboKho.SelectedValue)}");
			DataRow r = _dtStockCD.NewRow();
			r["ID"] = 0;
			r["CDName"] = "";
			_dtStockCD.Rows.InsertAt(r, 0);
			cboStockCD.DataSource = _dtStockCD;
			cboStockCD.DisplayMember = "CDName";
			cboStockCD.ValueMember = "ID";
		}
		/// <summary>
		/// Load theo mã từng công đoạn theo vị trí đã cài sẵn của bảng OrderPart
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		bool loadOrderPart(string order)
		{
			try
			{
				//Task task = Task.Factory.StartNew(() =>
				//{
				//string sql = $"select * from dbo.OrderPart Where OrderCode='{order}' ";

				//_dtOrderPart = TextUtils.Select(sql);

				DataSet ds = TextUtils.LoadDataSetFromSP("spLoadToLocationDuplicate", new string[] { "@CDID", "@OrderCode", "@StockName" }, new object[] { cboStockCD.SelectedValue, order, cboKho.Text.Trim() });
				if (ds.Tables.Count < 0) return false;
				_dtOrderPart = ds.Tables[0];

				DataTable dtNoSon = ds.Tables[4];
				dtSon = ds.Tables[3];
				dtNoSon.Merge(dtSon);
				DataRow[] drCheckIsGeneral = dtNoSon.Select("IsGeneral = 1");
				if (drCheckIsGeneral == null || drCheckIsGeneral.Length == 0 || drCheckIsGeneral.Count() == 0)
				{
					chkIsGeneral.BackColor = Color.Gray;
					chkIsGeneral.Checked = false;

				}
				else
				{
					chkIsGeneral.BackColor = Color.Yellow;
					chkIsGeneral.Checked = true;
				}
				DataTable dtCasse = ds.Tables[1];
				DataTable dtMotor = ds.Tables[2];
				DataTable dtDuplicate = new DataTable();
				if (cboKho.Text.Trim().Contains("KT"))
				{
					dtSon = ds.Tables[3];
					//Lấy ra toàn bộ mã hàng là sơn và khác vị trí 9999
					dtTPSon = ds.Tables[4];

				}
				//Lấy ra mã hàng trùng nếu có
				dtDuplicate = ds.Tables[5];
				for (int i = 0; i < dtDuplicate.Rows.Count; i++)
				{
					DataRow[] dr = _dtOrderPart.Select($"ArticleID='{dtDuplicate.Rows[i]["ArticleID"]}'");
					if (dr == null || dr.Length == 0 || dr.Count() == 0)
						continue;
					DataTable dttt = dr.CopyToDataTable();
					int Qty = TextUtils.ToInt(dttt.Rows[0]["Qty"]);
					//không check số lượng nhỏ hơn Order cứ trung nhau cộng Qty lại với nhau
					//if (Qty < TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()))
					//{
					//tính tổng số lượng của mã hàng
					int sum = TextUtils.ToInt(dttt.Compute("SUM(Qty)", string.Empty));
					//gán giá trị Qty vào dòng đầu tiên
					dttt.Rows[0]["Qty"] = sum;
					DataRow dataRow = _dtOrderPart.NewRow();
					//Hiển thị dòng đầu tiên 
					dataRow = dttt.Rows[0];

					DataRow[] dataRows = _dtOrderPart.Select($"ArticleID <>'{dtDuplicate.Rows[i]["ArticleID"]}'");
					if (dataRows.Count() > 0)
					{
						_dtOrderPart = dataRows.CopyToDataTable();
					}
					else
					{
						_dtOrderPart = _dtOrderPart.Clone();
						_dtOrderPart.Clone();
					}
					//Thêm dòng datarow
					_dtOrderPart.ImportRow(dataRow);
					//}
				}
				//danh sách vị trí 
				//List<string> lstLocation = new List<string>();
				//foreach (DataRow dataRow in dtLocation.Rows)
				//{
				//	lstLocation.Add(TextUtils.ToString(dataRow["LocationCode"]));
				//}
				DataColumnCollection columns = _dtOrderPart.Columns;
				if (!columns.Contains("Accessory"))
				{
					DataColumn dtc = new DataColumn("Accessory");
					DataColumn dtc1 = new DataColumn("Lo");
					DataColumn dtc2 = new DataColumn("RealQty");
					_dtOrderPart.Columns.Add(dtc);
					_dtOrderPart.Columns.Add(dtc1);
					_dtOrderPart.Columns.Add(dtc2);
				}
				else
				{
					_focusbtnSave = 1;
				}

				if (_dtOrderPart.Rows.Count == 0)
				{
					return false;
				}
				else
				{
					this.Invoke(new MethodInvoker(delegate ()
					{
						//Check bảng _dtOrderPart có trùng mã hàng ArticleID (trùng thì cộng tổng số lượng với nhau)

						grdData.DataSource = _dtOrderPart;

						for (int i = 0; i < _dtOrderPart.Rows.Count; i++)
						{
							int j = TextUtils.ToInt(grvData.GetRowCellValue(i, colQty));

							if (cboKho.Text.Trim() == "KMotor" || cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim().Contains("KN"))
							{
								break;
							}
							grvData.SetRowCellValue(i, "RealQty", j);
						}
						setFocus();
					}));
				}
				_Casse = "";
				_Motor = "";
				if (dtCasse.Rows.Count > 0)
				{
					_Casse = TextUtils.ToString(dtCasse.Rows[0]["ArticleID"]);
				}
				if (dtMotor.Rows.Count > 0)
				{
					_Motor = TextUtils.ToString(dtMotor.Rows[0]["ArticleID"]);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}
		bool loadPlan(string order)
		{
			try
			{
				DataSet ds = TextUtils.LoadDataSetFromSP("spLoadProductPlan", new string[] { "@OrderCode" }, new object[] { order });
				if (ds.Tables.Count <= 0) return false;
				DataTable dtHyp = ds.Tables[0];
				DataTable dtAltax = ds.Tables[1];

				if (cboLine.SelectedIndex == 1)
				{
					if (dtHyp.Rows.Count > 0)
					{
						txtQtyAssembleStock.Text = TextUtils.ToString(dtHyp.Rows[0]["Qty"]);
						txtTargetAssembleStock.Text = TextUtils.ToString(dtHyp.Rows[0]["ShipTo"]);
						txtPidAssembleStock.Text = TextUtils.ToString(dtHyp.Rows[0]["ProductCode"]);
						txtDescriptionAssembleStock.Text = TextUtils.ToString(dtHyp.Rows[0]["Description"]);
						NumSTT.Value = TextUtils.ToDecimal(dtHyp.Rows[0]["Stt"]);
						DtpDatePlan.Value = TextUtils.ToDate3(dtHyp.Rows[0]["JgDate"]);
					}
					else
					{
						return false;
					}
				}
				if (cboLine.SelectedIndex == 2)
				{
					if (dtAltax.Rows.Count > 0)
					{
						cboLine.SelectedIndex = 2;
						txtQtyAssembleStock.Text = TextUtils.ToString(dtAltax.Rows[0]["Qty"]);
						txtTargetAssembleStock.Text = TextUtils.ToString(dtAltax.Rows[0]["ShipTo"]);
						txtPidAssembleStock.Text = TextUtils.ToString(dtAltax.Rows[0]["ProductCode"]);
						txtDescriptionAssembleStock.Text = TextUtils.ToString(dtAltax.Rows[0]["Description"]);
						NumSTT.Value = TextUtils.ToDecimal(dtAltax.Rows[0]["Stt"]);
						DtpDatePlan.Value = TextUtils.ToDate3(dtAltax.Rows[0]["JgDate"]);
					}
					else
					{
						return false;
					}
				}
				setFocus();
				return true;
				//});
				//await task;
			}
			catch
			{
				return false;
			}
		}
		void checkPaint()
		{

			_lstArticleID = new List<string>();
			List<string> lstError = new List<string>();
			_lstID = new List<int>();

			DataRow[] rows = dtSon.Select($"Shelf like '99%'");
			if (rows.Length != 0)
			{
				//Check 9999
				for (int i = 0; i < rows.Length; i++)
				{
					DataRow r = rows[i];
					DataTable dt = TextUtils.Select($"SELECT top 1 * FROM dbo.PartSon where PartCode = '{TextUtils.ToString(r["ArticleID"])}'");
					if (dt.Rows.Count == 0) continue;
					_lstArticleID.Add(TextUtils.ToString(dt.Rows[0]["PartCode"]));
					int id = TextUtils.ToInt(dt.Rows[0]["ID"]);
					_lstID.Add(id);
					int qtyPaint = TextUtils.ToInt(dt.Rows[0]["QuantityAssembling"]);
					//int qtyOrder = TextUtils.ToInt(r["Qty"]);
					int qtyOrder = Lib.ToInt(txtQtyAssembleStock.Text.Trim());
					if (qtyOrder > qtyPaint)
					{
						lstError.Add("Mã Hàng: " + TextUtils.ToString(r["ArticleID"]) + " " + $"Yêu cầu: {qtyOrder}" + " " + $"Thực tế: {qtyPaint}");
					}
				}
			}
			//Check ArticleID có trong kho sơn không
			for (int i = 0; i < dtTPSon.Rows.Count; i++)
			{
				string ArticleID = TextUtils.ToString(dtTPSon.Rows[i]["ArticleID"]);
				Expression exp = new Expression("PartCode", ArticleID);
				ArrayList arr = PartSonBO.Instance.FindByExpression(exp);
				if (arr.Count > 0)
				{
					PartSonModel partSon = (PartSonModel)arr[0];
					if (partSon.ID > 0)
					{
						_lstArticleID.Add(partSon.PartCode);
						_lstID.Add(partSon.ID);
						if (TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()) > partSon.QuantityAssembling)
						{
							lstError.Add("Mã Hàng: " + ArticleID + " " + $"Yêu cầu: {TextUtils.ToInt(txtQtyAssembleStock.Text.Trim())}" + " " + $"Thực tế: {partSon.QuantityAssembling}");
						}
					}
				}
			}
			if (lstError.Count > 0)
			{

				contentError = string.Join("\n", lstError);
				//MessageBox.Show(contentError, "RTC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				//WarningForm frmWarning = new WarningForm();
				//frmWarning.LBTieuDe = "KHÔNG ĐỦ LINH KIỆN XUẤT KHO";
				//frmWarning.LB = $"{contentError}";
				//frmWarning.ShowDialog();
			}
			//}));

			//});
			//await task;
		}
		private void txtOrder_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			if (txtOrderr.Text.Trim() == "")
			{
				txtQtyAssembleStock.Text = "";
				txtTargetAssembleStock.Text = "";
				txtPidAssembleStock.Text = "";
				txtDescriptionAssembleStock.Text = "";

				grdData.DataSource = null;
				return;
			}
			//Check bắn order rồi thì khi bắn lại hiển thị cảnh báo Order đã xuất kho rồi 
			int ValueOld = TextUtils.ToInt(TextUtils.ExcuteScalar($"Select TOP 1 1 From PartOut Where OrderCode='{txtOrderr.Text.Trim()}' and StockCode='{cboKho.Text.Trim()}' and StockCDCode='{cboStockCD.Text.Trim()}'"));
			if (ValueOld > 0)
			{
				//Show cảnh báo màu đỏ Order đã xuất
				WarningForm frmWarning = new WarningForm();
				frmWarning.LB = $"ORDER ĐÃ XUẤT VUI LÒNG NHẬP LẠI";
				frmWarning.NameKho = cboKho.Text.Trim();
				frmWarning.Order = txtOrderr.Text.Trim();
				frmWarning.ShowDialog();
				txtOrderr.Text = "";
				txtOrderr.Focus();
				txtOrderr.SelectAll();
				return;
			}

			//Check là kho ngoài thì kho trong phải xuất kho thì kho ngoài mới được xuất
			if (cboKho.Text.Trim().Contains("KN") && cboLine.Text == "HYP")
			{
				int check = TextUtils.ToInt(TextUtils.ExcuteScalar($"Select TOP 1 1 From PartOut Where OrderCode='{txtOrderr.Text.Trim()}' and (StockCode like 'KT%')"));
				if (check <= 0)
				{
					WarningForm frmWarning = new WarningForm();
					frmWarning.LB = $"XIN VUI LÒNG ĐỢI KHO TRONG XUẤT KHO";
					frmWarning.NameKho = cboKho.Text.Trim();
					frmWarning.Order = txtOrderr.Text.Trim();
					frmWarning.ShowDialog();
					Reset();
					grdData.DataSource = null;
					return;
				}
			}
			if (!loadPlan(txtOrderr.Text.Trim()))
			{
				WarningForm frmWarning = new WarningForm();
				frmWarning.LB = "ORDER KHÔNG CÓ TRONG KẾ HOẠCH";
				frmWarning.NameKho = cboKho.Text.Trim();
				frmWarning.Order = txtOrderr.Text.Trim();
				frmWarning.ShowDialog();
				Reset();
				//MessageBox.Show("Order không có trong kế hoạch!", "RTC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				grdData.DataSource = null;
				return;
			}
			if (!loadOrderPart(txtOrderr.Text.Trim()))
			{
				WarningForm frmWarning = new WarningForm();
				frmWarning.LB = "ORDER KHÔNG CÓ VẬT TƯ";
				frmWarning.NameKho = cboKho.Text.Trim();
				frmWarning.Worker = txtWorkerCode.Text.Trim();
				frmWarning.NameKhoCD = cboStockCD.Text.Trim();
				frmWarning.Line = cboLine.Text.Trim();
				frmWarning.Order = txtOrderr.Text.Trim();
				frmWarning.ShowDialog();
				Reset();
				grdData.DataSource = null;
				//MessageBox.Show("Order không có vật tư!", "RTC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			//Bắn Order Cập nhật danh sách Order lên hệ thống bảng AutoAddXK 
			if (cboKho.Text.Trim().Contains("KT") || cboKho.Text.Trim().Contains("KN"))
			{
				//Hiển thị thông báo bắt đầu xuất hàng
				frmStartXH frmWarning = new frmStartXH();
				if (frmWarning.ShowDialog() == DialogResult.OK)
				{
					try
					{
						//Kho ngoài sau khi cất thì mới add Casse và Motor
						if (cboKho.Text.Trim().Contains("KN"))
						{
							int Line = 0;
							if (cboLine.Text.Trim().ToUpper() == "ALTAX")
							{
								Line = 2;
							}
							else if (cboLine.Text.Trim().ToUpper() == "HYP")
							{
								Line = 1;
							}
							//Nếu là xuất kho ngoài với công đoạn Name line altaxx thì k xuất kho motor
							if (_Casse.Trim() != "")
							{
								//Insert Casse 
								if (cboStockCD.Text.Trim().ToUpper() == "NAME" && Line == 2)
								{
								}
								else
								{
									TextUtils.ExcuteProcedure("spInsertRunCasseAndMotor", new string[] { "@Order", "@Pid", "@Line", "@Check" }, new object[] { txtOrderr.Text.Trim(), txtPidAssembleStock.Text.Trim(), Line, 1 });
								}
							}

							if (_Motor.Trim() != "")
							{
								if (cboStockCD.Text.Trim().ToUpper() == "NAME" && Line == 2)
								{
								}
								else
								{
									//Insert Motor 
									TextUtils.ExcuteProcedure("spInsertRunCasseAndMotor", new string[] { "@Order", "@Pid", "@Line", "@Check" }, new object[] { txtOrderr.Text.Trim(), txtPidAssembleStock.Text.Trim(), Line, 2 });
								}
							}
						}
					}
					catch (Exception ex)
					{
						ErrorLog.errorLog("Thêm spInsertRunCasseAndMotor", $"Lỗi InSert spInsertRunCasseAndMotor {ex.ToString()}", Environment.NewLine);
					}
				}
				else
				{
					txtOrderr.Text = "";
					txtOrderr.Focus();
					grdData.DataSource = null;
					return;
				}
			}
			if ((cboLine.Text.Trim() == "HYP" && cboStockCD.Text.Trim() == "CD1") || (cboLine.Text.Trim() == "HYP" && cboStockCD.Text.Trim() == "CD2"))
			{
				//Add vào bảng AutoXKNew 1 trạng thái chờ
				//Check có tồn tại thì không hiển thị 
				int check = TextUtils.ToInt(TextUtils.ExcuteScalar($"SELECT TOP 1 1 FROM [ShiStock].[dbo].[AddAutoXKNew] WHERE OrderCode = N'{txtOrderr.Text.Trim()}'"));
				if (check != 1)
				{
					AddAutoXKNewModel autoAddXKColorModel = new AddAutoXKNewModel();
					autoAddXKColorModel.OrderCode = txtOrderr.Text.Trim();
					autoAddXKColorModel.PID = txtPidAssembleStock.Text.Trim();
					switch (cboKho.Text.Trim())
					{
						case "KT1":
							autoAddXKColorModel.KT1 = 1;
							break;
						case "KT2":
							autoAddXKColorModel.KT2 = 1;
							break;
						case "KN1":
							autoAddXKColorModel.KN1 = 1;
							break;
						case "KN2":
							autoAddXKColorModel.KN2 = 1;
							break;
						case "KCasse":
							autoAddXKColorModel.KCasse = 1;
							break;
						case "KMotor":
							autoAddXKColorModel.KMotor = 1; //Trạng thái chờ
							break;
						default:
							break;
					}
					if (_Casse == "")
					{
						autoAddXKColorModel.KCasse = 3; // Không sử dụng
					}
					if (_Motor == "")
					{
						autoAddXKColorModel.KMotor = 3;// không sử dụng
					}
					int t = TextUtils.ToInt(txtQtyAssembleStock.Text.Trim());
					saveAutoAddXKColor(autoAddXKColorModel, t);
				}
				else
				{
					//Nếu tồn tài thì update
					string sql = "UPDATE [ShiStock].[dbo].[AddAutoXKNew] SET " + cboKho.Text.Trim() + $"= 1 where OrderCode = '{txtOrderr.Text.Trim()}'";
					TextUtils.ExcuteSQL(sql);
				}
				//Update chạy sử dụng hoặc không sử dung  VD 1;60 (0 sử dụng, 1 không sử dung) ; 60 là thời gian chạy
				TextUtils.ExcuteSQL($"UPDATE [ShiStock].[dbo].[StatusColorStock] SET {cboKho.Text.Trim()}=N'0;{ TextUtils.ToString(TextUtils.ToInt(TextUtils.ToDate(TextUtils.ToString(_dtStockCD.Rows[cboStockCD.SelectedIndex]["TaktTime"])).TimeOfDay.TotalSeconds) * TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()))}'");
			}

			//ToDo: Gửi giá trị time cho AnDonPicking
			//Add vào bảng hiển thị màu chờ

			string value = TextUtils.ToString(TextUtils.ToInt(TextUtils.ToDate(TextUtils.ToString(_dtStockCD.Rows[cboStockCD.SelectedIndex]["TaktTime"])).TimeOfDay.TotalSeconds) * TextUtils.ToInt(txtQtyAssembleStock.Text.Trim())) + "@";
			sendDataTCPAnDonPicking(value, txtQtyAssembleStock.Text.Trim());

			_lstCount.Clear();
			_startMakeTime = DateTime.Now;
			if (cboKho.Text.Trim().ToUpper().Contains("MOTOR"))
			{
				for (int k = 0; k < grvData.RowCount; k++)
				{
					string ArticleID = TextUtils.ToString(grvData.GetRowCellValue(k, colArticleID));
					DataTable dt = TextUtils.GetDataTableFromSP("spLoadHistoryShelf", new string[] { "@ArticleID" }, new object[] { ArticleID });
					if (dt.Rows.Count > 0)
					{
						//Hiển thị vị trí lên cột vị trí trong gridview
						grvData.SetRowCellValue(k, colShelf, TextUtils.ToString(dt.Rows[0][0]));
					}
				}
			}
			contentError = "";
			if (cboKho.Text.Trim().ToUpper().Contains("KT") && cboLine.SelectedIndex == 1)
			{
				checkPaint();
			}
			if (cboKho.Text.Trim().ToUpper().Contains("KT") && cboLine.SelectedIndex == 2)
			{
				//check trong kho sơn giá trị nó lớn hơn so với 
				checkPaintLineAltax();
				//Gán giá trị lên
				//Save 
			}
			//setFocus();
			if (_lstArticleID.Count > 0)
			{
				if (cboKho.Text.Trim().Contains("KT"))
				{
					string inform = "";
					frmArticleID frm = new frmArticleID();
					for (int i = 0; i < _lstArticleID.Count; i++)
					{
						inform += "Mã hàng:" + _lstArticleID[i] + "- Số lượng:" + txtQtyAssembleStock.Text.Trim() + "\n";
					}
					frm.ArticleID = inform;
					if (frm.ShowDialog() == DialogResult.OK)
					{
						List<SONHistoryImExModel> lstHistory = new List<SONHistoryImExModel>();
						// Lưu và trừ kho sơn nếu trong kho sơn có 
						for (int i = 0; i < _lstID.Count; i++)
						{
							// lấy ID theo từng dòng
							int ID = _lstID[i];
							string ArticleID = _lstArticleID[i];
							PartSonModel partSon = (PartSonModel)PartSonBO.Instance.FindByPK(ID);
							//	partSon.QuantityExporting;
							int RealQty = TextUtils.ToInt(txtQtyAssembleStock.Text.Trim());
							//Check trong lịch sử xuất kho sơn có không
							int check = TextUtils.ToInt(TextUtils.ExcuteScalar($"SELECT TOP 1 1 FROM [ShiStock].[dbo].[SONHistoryImEx] WHERE OrderCode=N'{txtOrderr.Text.Trim()}' AND PartCode=N'{partSon.PartCode}' and IsExported=1 and IsAssembled=1"));
							if (check == 1) continue;
							partSon.QuantityAssembling -= RealQty;
							if (partSon.QuantityAssembling < 0)
							{
								//MessageBox.Show($"Số lượng trong kho sơn không đủ thiếu {-partSon.QuantityAssembling}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								WarningForm frmWarning = new WarningForm();
								frmWarning.NameKho = cboKho.Text.Trim();
								frmWarning.Order = txtOrderr.Text.Trim();
								frmWarning.LB = $"{contentError}";
								frmWarning.ShowDialog();
								return;
							}
							PartSonBO.Instance.Update(partSon);
							SONHistoryImExModel sONHistoryImEx = new SONHistoryImExModel();
							sONHistoryImEx.PartID = partSon.ID;
							sONHistoryImEx.PartCode = partSon.PartCode;
							sONHistoryImEx.DateImEx = DateTime.Now;
							sONHistoryImEx.Quantity = RealQty;
							sONHistoryImEx.OrderCode = txtOrderr.Text.Trim();
							sONHistoryImEx.ProductCode = txtPidAssembleStock.Text.Trim();
							sONHistoryImEx.IsExported = true; // 1 xuất 0 nhập
							sONHistoryImEx.IsAssembled = 1;// 1 lắp ráp 0 xuất khẩu
							sONHistoryImEx.WorkerCode = txtWorkerCode.Text.Trim();
							lstHistory.Add(sONHistoryImEx);
						}
						saveHistory(lstHistory);
						_lstID.Clear();
						_lstArticleID.Clear();
					}
					else
					{
						txtOrderr.Text = "";
						txtOrderr.Focus();
						grdData.DataSource = null;
						return;
					}

				}
			}



		}
		void checkPaintLineAltax()
		{
			_lstArticleID = new List<string>();
			List<string> lstError = new List<string>();
			_lstID = new List<int>();
			//Check ArticleID có trong kho sơn không
			for (int i = 0; i < grvData.RowCount; i++)
			{
				string ArticleID = TextUtils.ToString(grvData.GetRowCellValue(i, colArticleID));
				Expression exp = new Expression("PartCode", ArticleID);
				ArrayList arr = PartSonBO.Instance.FindByExpression(exp);
				if (arr.Count > 0)
				{
					PartSonModel partSon = (PartSonModel)arr[0];
					if (partSon.ID > 0)
					{
						_lstArticleID.Add(partSon.PartCode);
						_lstID.Add(partSon.ID);
						if (TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()) > partSon.QuantityAssembling)
						{
							lstError.Add("Mã Hàng: " + ArticleID + " " + $"Yêu cầu: {TextUtils.ToInt(txtQtyAssembleStock.Text.Trim())}" + " " + $"Thực tế: {partSon.QuantityAssembling}");
						}
						else
						{
							//Gán giá trị lên grv
							grvData.SetRowCellValue(i, "Lo", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
							string PartCode = TextUtils.ToString(grvData.GetRowCellValue(i, colArticleID));
							grvData.SetRowCellValue(i, "Accessory", PartCode);
						}
					}
				}
			}
			if (lstError.Count > 0)
			{
				contentError = string.Join("\n", lstError);
				//MessageBox.Show(contentError, "RTC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				//WarningForm frmWarning = new WarningForm();
				//frmWarning.LBTieuDe = "KHÔNG ĐỦ LINH KIỆN XUẤT KHO";
				//frmWarning.LB = $"{contentError}";
				//frmWarning.ShowDialog();
			}
			else
			{
				if (grvData.RowCount == _lstCount.Count)
				{
					btnSave_Click(null, null);
					return;
				}
			}

		}
		private void setFocus()
		{
			if (cboKho.Text.Trim().Contains("KT"))
			{
				txtLocation.Focus();
			}
			else
				txtPartCode.Focus();
			txtOrderr.BackColor = Color.White;
			CboOrder.BackColor = Color.White;
			txtQtyAssembleStock.BackColor = Color.White;
			txtTargetAssembleStock.BackColor = Color.White;
			txtPidAssembleStock.BackColor = Color.White;
			txtDescriptionAssembleStock.BackColor = Color.White;
			if (_focusbtnSave == 1)
			{
				//btnSave.Focus();
				btnSave_Click(null, null);
				_focusbtnSave = 0;
			}
		}



		private void txtAccessoryChecking_Click(object sender, EventArgs e)
		{
			txtPartCode.SelectAll();
		}

		private void txtNumLot_Click(object sender, EventArgs e)
		{
			txtNumLot.SelectAll();
		}

		private void txtPartCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (txtPartCode.Text.Trim() == "") return;
			if (e.KeyCode != Keys.Enter) return;
			PartCode = txtPartCode.Text.Trim();
			//Check riêng Kho trong
			if (cboKho.Text.Trim().Contains("KT"))
			{
				if (txtLocation.Text.Trim() == "")
				{
					WarningForm frmWarning = new WarningForm();
					frmWarning.LB = "BẠN CHƯA NHẬP VỊ TRÍ";
					frmWarning.NameKho = cboKho.Text.Trim();
					frmWarning.Order = txtOrderr.Text.Trim();
					frmWarning.ShowDialog();
					return;
				}

				//Check mã hàng so với vị trí đã nhập trước
				int check = 0;
				for (int i = 0; i < _lstRow.Count; i++)
				{
					string ArticleID = TextUtils.ToString(grvData.GetRowCellValue(_lstRow[i], "ArticleID"));
					if (ArticleID.Trim().ToUpper() == PartCode.Trim().ToUpper())
					{
						check = 1;
						_row = _lstRow[i];
						break;
					}
				}
				if (check == 0)
				{
					WarningForm frmWarning = new WarningForm();
					frmWarning.LB = "SAI MÃ HÀNG SO VỚI VỊ TRÍ ĐÃ NHẬP";
					frmWarning.NameKho = cboKho.Text.Trim();
					frmWarning.Order = txtOrderr.Text.Trim();
					frmWarning.ShowDialog();
					txtPartCode.Focus();
					txtPartCode.SelectAll();
					return;
				}

			}
			else
			{
				try
				{
					PartCode = PartCode.Split(',')[0];
				}
				catch
				{

				}
			}

			_row = -1;
			for (int i = 0; i < _dtOrderPart.Rows.Count; i++)
			{
				string data = TextUtils.ToString(grvData.GetRowCellValue(i, "ArticleID"));
				if (cboKho.Text.Trim().ToUpper().Contains("MOTOR"))
				{
					if (LoadColorMotor(PartCode.Trim()).Trim().ToUpper() == data.Trim().ToUpper())
					{
						_row = i;
						break;
					}
					else
					{
						continue;
					}
				}
				if (PartCode.ToUpper() != "OK")
				{
					//nếu là công đoạn không phải motor
					if (cboKho.Text.ToUpper().Contains("CASSE") || cboKho.Text.ToUpper().Contains("KN"))
					{
						//bỏ T và A trong kho Casse trong 2 line 
						if (data.Substring(data.Length - 1).ToUpper() == "T" || data.Substring(data.Length - 1).ToUpper() == "A")
						{
							data = data.TrimEnd(data[data.Length - 1]);
						}
					}
					if (data.Trim().ToUpper() == PartCode.Trim().ToUpper())
					{
						_row = i;
						break;
					}
				}
				else
				{
					if (TextUtils.ToInt(grvData.GetRowCellValue(i, colRealQty)) == TextUtils.ToInt(grvData.GetRowCellValue(i, colQty)))
					{
						if (_dtOrderPart.Rows.Count - 1 == i)
						{
							btnSave_Click(null, null);
							txtPartCode.Text = "";
							return;
						}
						continue;
					}
					else
					{
						_row = i;
						break;
					}

				}
			}
			//DataRow[] rows = _dtOrderPart.Select($"ArticleID = '{txtPartCode.Text.Trim()}'");
			if (_row == -1)
			{
				WarningForm frmWarning = new WarningForm();
				frmWarning.NameKho = cboKho.Text.Trim();
				frmWarning.Order = txtOrderr.Text.Trim();
				frmWarning.LB = "SAI MÃ HÀNG";
				frmWarning.ShowDialog();
				txtPartCode.Text = "";
				txtPartCode.Focus();
				txtPartCode.SelectAll();
				//MessageBox.Show("Linh kiện không tồn tại trong Order!", "RTC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim() == "KMotor" || cboKho.Text.Trim().Contains("KN"))
			{
				int QtyReal = TextUtils.ToInt(grvData.GetRowCellValue(_row, colRealQty));
				int ColumnName = 6;
				//Hiển thị mã bắn lên grid view
				if (cboLine.SelectedIndex == 1)
				{
					ColumnName = 6;
				}
				else if (cboLine.SelectedIndex == 2)
				{
					ColumnName = 7;
				}
				//Gửi mã bắn và số lượng để trừ luôn giá trị kho
				if (cboKho.Text.ToUpper().Contains("MOTOR"))
				{
					try
					{
						string Shelf = TextUtils.ToString(grvData.GetRowCellValue(0, colShelf));
						if (Shelf.Trim() != "")
						{
							DataTable dt = TextUtils.GetDataTableFromSP("spLoadSLShelf", new string[] { "@CardNo", "@Shelf" }, new object[] { PartCode.Trim(), Shelf });
							if (dt == null || dt.Rows.Count == 0)
							{
								WarningForm frmWarning = new WarningForm();
								frmWarning.NameKho = cboKho.Text.Trim();
								frmWarning.Order = txtOrderr.Text.Trim();
								frmWarning.LB = $"KHÔNG TÌM THẤY LINH KIỆN THEO VỊ TRÍ {TextUtils.ToString(grvData.GetRowCellValue(0, colShelf))}";
								frmWarning.ShowDialog();
								txtPartCode.Text = "";
								txtPartCode.Focus();
								txtPartCode.SelectAll();
								return;
							}
							//if (dt.Rows.Count <= 0) return;
							ShelfModel shelfModel = new ShelfModel();
							shelfModel = (ShelfModel)ShelfBO.Instance.FindByAttribute("ShelfCode", TextUtils.ToString(dt.Rows[0]["Shelf"]).Trim())[0];
							shelfModel.ShelfNumber = shelfModel.ShelfNumber - 1;
							if (shelfModel.ShelfNumber < 0)
							{
							}
							else
							{
								ShelfBO.Instance.Update(shelfModel);
							}
							//Xóa trường trong bảng AutoAddMotor
							TextUtils.ExcuteSQL($" DELETE [ShiStock].[dbo].[AutoAddShelfMotor] WHERE SerialNumber=N'{PartCode.Trim()}'");
							for (int i = 0; i < grvData.RowCount; i++)
							{
								if (shelfModel.ShelfNumber == 0 && TextUtils.ToInt(grvData.GetRowCellValue(i, colRealQty)) != TextUtils.ToInt(grvData.GetRowCellValue(i, colQty)))
								{
									//Tìm vị trí tiếp theo
									string ArticleID = TextUtils.ToString(grvData.GetRowCellValue(i, colArticleID));
									DataTable dtt = TextUtils.GetDataTableFromSP("spLoadHistoryShelf", new string[] { "@ArticleID" }, new object[] { ArticleID });
									if (dtt != null && dtt.Rows.Count > 0)
									{
										//Hiển thị vị trí lên cột vị trí trong gridview
										grvData.SetRowCellValue(i, colShelf, TextUtils.ToString(dtt.Rows[0][0]));
									}
								}
							}
						}

					}
					catch (Exception)
					{
						//MessageBox.Show("Lỗi update số lượng giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

				}
				for (int i = 1; i < ColumnName; i++)
				{
					string Column = "Column";
					string valueColumn = TextUtils.ToString(grvData.GetRowCellValue(_row, Column + i)).ToUpper();
					if (PartCode.ToUpper() != "OK")
					{
						if (valueColumn == txtPartCode.Text.Trim().ToUpper())
						{
							txtPartCode.Text = "";
							txtPartCode.Focus();
							txtPartCode.SelectAll();
							return;
						}
						if (valueColumn != "" || i > TextUtils.ToInt(grvData.GetRowCellValue(_row, colQty))) continue;
						grvData.SetRowCellValue(_row, Column + i, txtPartCode.Text.Trim().ToUpper());
					}
					else
					{
						if (valueColumn.ToUpper() == "OK" || valueColumn != "") continue;
						grvData.SetRowCellValue(_row, Column + i, PartCode.ToUpper());

					}
					QtyReal++;
					grvData.SetRowCellValue(_row, "RealQty", QtyReal);
					break;
				}
				if (cboKho.Text.Contains("KN"))
				{
					if (TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()) < QtyReal)
					{
						//btnSave_Click(null, null);
						return;
					}
				}
				//Check số lượng thực tế nếu bằng vs số lượng quy định thì dừng lại 
				else if (TextUtils.ToInt(grvData.GetRowCellValue(_row, colQty)) < QtyReal)
				{
					//btnSave_Click(null, null);
					txtPartCode.Text = "";
					txtPartCode.Focus();
					txtPartCode.SelectAll();
					return;
				}

				colRealQty.OptionsColumn.AllowEdit = false;
				txtNumLot.Enabled = true;

				if (cboKho.Text.Contains("KN"))
				{
					if (TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()) == QtyReal)
					{
						if (grvData.RowCount == _lstCount.Count)
						{
							btnSave_Click(null, null);
							//btnSave.Focus();
							return;
						}
					}
				}
				else if (TextUtils.ToInt(grvData.GetRowCellValue(_row, colQty)) >= QtyReal)
				{
					if (grvData.RowCount == _lstCount.Count)
					{
						btnSave_Click(null, null);
						//btnSave.Focus();
						return;
					}
				}
				//if (row == _dtOrderPart.Rows.Count - 1)
				//	{
				//		btnSave.Focus();
				//		return;
				//	}
				txtPartCode.Text = "";
				txtPartCode.Focus();
				txtPartCode.SelectAll();
				return;
			}
			//kHO trong

			colRealQty.OptionsColumn.AllowEdit = true;
			grvData.SetRowCellValue(_row, "Accessory", PartCode.Trim());
			txtQtyAccessory.Text = TextUtils.ToString(grvData.GetRowCellValue(_row, "Qty"));
			//string _textCompare = TextUtils.ToString(grvData.GetRowCellValue(_row, "ArticleID"));

			//checkLocation(row);
			txtNumLot.Focus();
			txtNumLot.SelectAll();
		}
		string LoadColorMotor(string CardNo)
		{
			string _AritelID = TextUtils.ToString(TextUtils.ExcuteScalar($"SELECT TOP 1 ArticleID FROM [SystemData].[dbo].[CheckMotor] WHERE MotorInspSealNo=N'{CardNo}' or CardNo=N'{CardNo}'"));
			return _AritelID;
		}
		private void txtNumLot_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			_row = -1;
			string data = "";
			string Numer = "";
			for (int i = 0; i < _dtOrderPart.Rows.Count; i++)
			{
				data = TextUtils.ToString(grvData.GetRowCellValue(i, "ArticleID"));
				Numer = TextUtils.ToString(grvData.GetRowCellValue(i, colQty));
				if (data.ToUpper() == PartCode.Trim().ToUpper())
				{
					_row = i;
					break;
				}
			}

			//HIển thị form xác nhận số lượng
			frmSL frm = new frmSL();
			frm.PartCode = data;
			frm.numer = Numer;
			if (frm.ShowDialog() != DialogResult.OK)
			{
				txtNumLot.Focus();
				txtNumLot.SelectAll();
				return;
			}
			else
			{
				grvData.SetRowCellValue(_row, "Lo", txtNumLot.Text.Trim().ToUpper());
				txtLocation.Focus();
				txtLocation.SelectAll();
				txtLocation.Text = "";
				txtNumLot.Text = "";
				txtPartCode.Text = "";
				txtQtyAccessory.Text = "";

				if (grvData.RowCount == _lstCount.Count)
				{
					btnSave_Click(null, null);
					//	btnSave.Focus();
					return;
				}
			}

		}
		private void cấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSave_Click(null, null);
		}
		void Reset()
		{
			txtPidAssembleStock.Text = "";
			txtDescriptionAssembleStock.Text = "";
			CboOrder.Text = "";
			txtOrderr.Text = "";
			txtQtyAssembleStock.Text = "";
			txtTargetAssembleStock.Text = "";
			txtPartCode.Text = "";
			txtNumLot.Text = "";
			txtQtyAccessory.Text = "";
			grdData.DataSource = null;
			txtOrderr.Focus();
			txtOrderr.SelectAll();
			txtLocation.Text = "";
		}
		async void saveAutoAddXK(AutoAddXKModel autoAdd, int t)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				this.Invoke((MethodInvoker)delegate
				{
					for (int i = 0; i < t; i++)
					{
						autoAdd.CreatDate = DateTime.Now.AddSeconds(10 * i);
						autoAdd.Cnt = -(i + 1);
						AutoAddXKBO.Instance.Insert(autoAdd);
					}
					//_Casse = "";
					//_Motor = "";
				});
			});
			await task;
		}
		async void saveAutoAddXKColor(AddAutoXKNewModel autoAdd, int t)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				this.Invoke((MethodInvoker)delegate
				{
					for (int i = 0; i < t; i++)
					{
						autoAdd.CreateDate = DateTime.Now.AddSeconds(10 * i);
						autoAdd.Cnt = -(i + 1);
						AddAutoXKNewBO.Instance.Insert(autoAdd);
					}
				});
			});
			await task;
		}
		async void saveDetail(List<PartOutDetailModel> lstDetail)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				foreach (PartOutDetailModel item in lstDetail)
				{
					PartOutDetailBO.Instance.Insert(item);
				}
			});
			await task;
		}
		async void saveHistory(List<SONHistoryImExModel> lstDetail)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				foreach (SONHistoryImExModel item in lstDetail)
				{
					SONHistoryImExBO.Instance.Insert(item);
				}
			});
			await task;
		}


		private void txtWorkerCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			txtWorkerCode.BackColor = Color.White;
			cboKho.Focus();
		}

		private void KhaiBaoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmStockCD frm = new frmStockCD();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				loadCboStock();
			}
		}

		private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboKho.Text.Trim() == "") return;
			if (cboKho.Text.Trim() == null) return;
			if (cboKho.Text.Trim().ToUpper().Contains("KT"))
			{
				colColumn1.Visible = false;
				colColumn2.Visible = false;
				colColumn3.Visible = false;
				colColumn4.Visible = false;
				colColumn5.Visible = false;
				colColumn6.Visible = false;
				button4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				tableLayoutPanel1.SetColumn(txtPartCode, 3);
				tableLayoutPanel1.SetColumn(button4, 2);
				button1.Visible = true;
				txtLocation.Visible = true;
				txtSoLot.Visible = true;
				btnSL.Visible = true;
				txtQtyAccessory.Visible = true;
				tableLayoutPanel1.SetColumnSpan(txtPartCode, 1);
				colLoLot.Visible = true;
				colRealQty.Visible = true;
				txtNumLot.Visible = true;
			}
			else
			{
				if (cboLine.SelectedIndex == 2)
					colColumn6.Visible = true;
				colColumn5.Visible = true;
				colColumn4.Visible = true;
				colColumn3.Visible = true;
				colColumn2.Visible = true;
				colColumn1.Visible = true;
				txtSoLot.Visible = false;
				txtNumLot.Visible = false;
				btnSL.Visible = false;
				button1.Visible = false;
				txtLocation.Visible = false;
				txtQtyAccessory.Visible = false;
				tableLayoutPanel1.SetColumn(txtPartCode, 1);
				tableLayoutPanel1.SetColumn(button4, 0);
				tableLayoutPanel1.SetColumnSpan(txtPartCode, 7);
				button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				colRealQty.Visible = false;
				colLoLot.Visible = false;

			}
			cboLine.Focus();
			if (_threadLoadAll != null) _threadLoadAll.Abort();
			loadStockCD();
		}
		/// <summary>
		/// Load liên tục khi kho casse và motor để tìm ra order
		/// </summary>
		void threadLoadAll()
		{
			while (true)
			{
				Thread.Sleep(500);
				this.Invoke((MethodInvoker)delegate
				{

					try
					{
						if (txtOrderr.Text.Trim() == "" && cboStockCD.Text.Trim() != "")
						{
							if (cboKho.Text.Trim().ToUpper().Contains("KCASSE"))
							{
								LoadCboCasse();
							}
							else if (cboKho.Text.Trim().ToUpper().Contains("KMOTOR"))
							{
								LoadCboMotor();
							}
							string order = TextUtils.ToString(TextUtils.ExcuteScalar("spLoadContinute",
																						new string[] { "@Check", "@Line" },
																						new object[] { cboKho.Text.Trim(), cboLine.SelectedIndex }));
							txtOrderr.Text = order.Trim();

							txtOrder_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
						}
					}
					catch
					{
						ErrorLog.errorLog("ThreadLoadAll", $"Lỗi {cboKho.Text.Trim()} và {cboStockCD.Text.Trim()} không tìm ra Order ", Environment.NewLine);
					}
				});
			}
		}
		void LoadCboCasse()
		{
			DataTable dt = TextUtils.Select($"select * from RunCasse where Line ='{cboLine.SelectedIndex}'");
			DataRow dr = dt.NewRow();
			dr["ID"] = 0;
			dr["OrderCode"] = "";
			dt.Rows.InsertAt(dr, 0);
			CboOrder.DataSource = dt;
			CboOrder.DisplayMember = "OrderCode";
			CboOrder.ValueMember = "ID";
		}
		void LoadCboMotor()
		{
			DataTable dt = TextUtils.Select($"select * from RunMotor where Line ='{cboLine.SelectedIndex}'");
			DataRow dr = dt.NewRow();
			dr["ID"] = 0;
			dr["OrderCode"] = "";
			dt.Rows.InsertAt(dr, 0);
			CboOrder.DataSource = dt;
			CboOrder.DisplayMember = "OrderCode";
			CboOrder.ValueMember = "ID";
		}
		private void cboKho_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode != Keys.Enter) return;
			if (cboKho.Text.Trim() == "") return;
			if (cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim() == "KMotor")
			{
				txtSoLot.Visible = false;
				txtNumLot.Visible = false;
				btnSL.Visible = false;
				txtQtyAccessory.Visible = false;
				tableLayoutPanel1.SetColumnSpan(txtPartCode, 5);
			}
			else
			{
				txtSoLot.Visible = true;
				txtNumLot.Visible = true;
				btnSL.Visible = true;
				txtQtyAccessory.Visible = true;
				tableLayoutPanel1.SetColumnSpan(txtPartCode, 1);
			}
			Reset();
			cboStockCD.Focus();

		}
		private void frmXK_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_threadLoadAll != null) _threadLoadAll.Abort();
		}

		private void sựCốToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.BackColor = Color.Red;
			//Gửi tín hiệu risk qua server Andon qua TCP/IP
			sendDataTCPAnDonPicking("Error", "XK");
		}

		private void cboKho_Click(object sender, EventArgs e)
		{
			if (_threadLoadAll != null) _threadLoadAll.Abort();
		}



		/// <summary>
		/// F8 không sử dụng và ngược lại
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void khôngSửDụngToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (khôngSửDụngToolStripMenuItem1.Text.Trim() == "Không Sử Dụng")
			{
				sendDataTCPAnDonPicking("KSD", "XK");
				khôngSửDụngToolStripMenuItem1.Text = "Sử dụng";
				this.Enabled = false;

			}
			else
			{
				sendDataTCPAnDonPicking("SD", "XK");
				khôngSửDụngToolStripMenuItem1.Text = "Không Sử Dụng";
				_startMakeTime = DateTime.Now;
				this.Enabled = true;
			}

		}

		private void khôngSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				frmChooseRisk frm = new frmChooseRisk();
				if (frm.ShowDialog() == DialogResult.OK)
				{
					PartOutModel partOut = new PartOutModel();
					partOut.StockID = TextUtils.ToInt(cboKho.SelectedValue);
					partOut.StockCDID = TextUtils.ToInt(cboStockCD.SelectedValue);
					partOut.WorkerName = txtWorkerCode.Text.Trim();
					partOut.LineName = cboLine.Text.Trim();
					partOut.OrderCode = txtOrderr.Text.Trim();
					partOut.PidAssembleStock = txtPidAssembleStock.Text.Trim();
					partOut.DescriptionAssembleStock = txtDescriptionAssembleStock.Text.Trim();
					partOut.StockCode = cboKho.Text.Trim();
					partOut.StockCDCode = cboStockCD.Text.Trim();
					partOut.CreatDate = DateTime.Now;
					partOut.Status = false;
					partOut.StartTime = _startMakeTime;
					_endMakeTime = DateTime.Now;
					partOut.EndTime = _endMakeTime;
					partOut.RiskDescription = frm.RiskDescription;
					partOut.PeriodTime = TextUtils.ToInt(Math.Round((_endMakeTime - _startMakeTime).TotalSeconds, 0));
					partOut.Type = 2;
					PartOutBO.Instance.Insert(partOut);
					sendDataTCPAnDonPicking("OK", "XK");
					this.BackColor = Color.White;
				}
			}
			catch
			{

			}
		}

		private void cboStockCD_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cboStockCD.SelectedIndex == 0) return;
				if (cboLine.SelectedIndex <= 0)
				{
					MessageBox.Show("Vui lòng chọn line", "Thông báo", MessageBoxButtons.OK);
					cboStockCD.SelectedIndex = 0;
					return;
				}
				//if (e.KeyCode != Keys.Enter) return;
				if (cboStockCD.Text.Trim() == "")
				{
					return;
				}
				txtOrderr.Focus();
				txtNumLot.Enabled = true;
				lst = new List<string>();
				string sql = $"select LocationCode from Location where CDID = {cboStockCD.SelectedValue}";
				DataTable dt = TextUtils.Select(sql);
				if (dt.Rows.Count <= 0) return;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					lst.Add(TextUtils.ToString(dt.Rows[i]["LocationCode"]));
				}

				txtQtyAccessory.Enabled = true;

				if (cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim() == "KMotor")
				{

					txtNumLot.Enabled = false;
					txtQtyAccessory.Enabled = false;
					if (_threadLoadAll != null) _threadLoadAll.Abort();
					_threadLoadAll = new Thread(new ThreadStart(threadLoadAll));
					_threadLoadAll.IsBackground = true;
					_threadLoadAll.Start();
				}
				Reset();

			}
			catch
			{

			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (txtWorkerCode.Text.Trim() == "" || txtOrderr.Text.Trim() == "" || cboKho.Text.Trim() == "" || cboStockCD.Text.Trim() == "")
			{
				txtPartCode.Text = "";
				return;
			}
			int row = grvData.RowCount;
			if (row <= 0) return;
			if (cboKho.Text.Trim() == "KMotor" || cboKho.Text.Trim() == "KCasse")
			{

				for (int i = 0; i < row; i++)
				{
					if (Lib.ToInt(grvData.GetRowCellValue(i, colQty)) > Lib.ToInt(grvData.GetRowCellValue(i, colRealQty)))
					{
						MessageBox.Show("Bạn phải nhập đủ số lượng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}
			}
			//TODO: Check các kho trừ kho ngoài thì được cất
			if (cboKho.Text.Trim() == "KMotor" || cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim().Contains("KT"))
			{
				if (row != _lstCount.Count)
				{
					MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			//Hiển thị có cất hay không và hiển thị số lượng thực tế và số lượng kế hoạch
			frmSaveOK frm = new frmSaveOK();
			frm._QtyReal = grvData.RowCount;
			frm._QtyPlan = grvData.RowCount;
			if (frm.ShowDialog() == DialogResult.Cancel)
			{
				txtPartCode.Text = "";
				return;
			}


			if (cboLine.Text.Trim().ToUpper() == "HYP")
			{
				try
				{
					//Update dữ liệu bảng AutoAddXKNew trạng thái hoàn thành
					string sql = "UPDATE [ShiStock].[dbo].[AddAutoXKNew] SET " + cboKho.Text.Trim() + $"= 2 where OrderCode = '{txtOrderr.Text.Trim()}'";
					TextUtils.ExcuteSQL(sql);
				}
				catch
				{

				}
			}


			// Lưu master Xuất kho
			PartOutModel partOut = new PartOutModel();
			try
			{
				partOut.StockID = TextUtils.ToInt(cboKho.SelectedValue);
				partOut.StockCDID = TextUtils.ToInt(cboStockCD.SelectedValue);
				partOut.WorkerName = txtWorkerCode.Text.Trim();
				partOut.LineName = cboLine.Text.Trim();
				partOut.OrderCode = txtOrderr.Text.Trim();
				partOut.PidAssembleStock = txtPidAssembleStock.Text.Trim();
				partOut.DescriptionAssembleStock = txtDescriptionAssembleStock.Text.Trim();
				partOut.StockCode = cboKho.Text.Trim();
				partOut.StockCDCode = cboStockCD.Text.Trim();
				partOut.CreatDate = DateTime.Now;
				partOut.Status = false;
				partOut.StartTime = _startMakeTime;
				_endMakeTime = DateTime.Now;
				partOut.EndTime = _endMakeTime;
				partOut.PeriodTime = TextUtils.ToInt(Math.Round((_endMakeTime - _startMakeTime).TotalSeconds, 0));
				if (partOut.PeriodTime > 0 && partOut.PeriodTime < 200)
				{
					partOut.Type = 1;
				}
				else
				{
					partOut.Type = 3;
				}
				partOut.ID = (int)PartOutBO.Instance.Insert(partOut);
			}
			catch (Exception ex)
			{
				ErrorLog.errorLog("Thêm PartOut", "Lỗi InSert Part Out", Environment.NewLine);
			}


			List<PartOutDetailModel> lstDetail = new List<PartOutDetailModel>();
			try
			{
				for (int i = 0; i < grvData.RowCount; i++)
				{
					//Lưu detail Xuất kho
					PartOutDetailModel partOutDetail = new PartOutDetailModel();
					partOutDetail.PartOutID = partOut.ID;
					partOutDetail.Description = TextUtils.ToString(grvData.GetRowCellValue(i, colDescription));
					partOutDetail.ArticleID = TextUtils.ToString(grvData.GetRowCellValue(i, colArticleID));
					partOutDetail.Shelf = TextUtils.ToString(grvData.GetRowCellValue(i, colShelf));
					partOutDetail.Qty = TextUtils.ToInt(grvData.GetRowCellValue(i, colQty));
					partOutDetail.Lo = TextUtils.ToString(grvData.GetRowCellValue(i, colLoLot));
					partOutDetail.Column1 = TextUtils.ToString(grvData.GetRowCellValue(i, colColumn1));
					partOutDetail.Column2 = TextUtils.ToString(grvData.GetRowCellValue(i, colColumn2));
					partOutDetail.Column3 = TextUtils.ToString(grvData.GetRowCellValue(i, colColumn3));
					partOutDetail.Column4 = TextUtils.ToString(grvData.GetRowCellValue(i, colColumn4));
					partOutDetail.Column5 = TextUtils.ToString(grvData.GetRowCellValue(i, colColumn5));
					partOutDetail.Column6 = TextUtils.ToString(grvData.GetRowCellValue(i, colColumn6));
					partOutDetail.Accessory = TextUtils.ToString(grvData.GetRowCellValue(i, colRealValue));
					partOutDetail.RealQty = TextUtils.ToInt(grvData.GetRowCellValue(i, colRealQty));
					partOutDetail.CreatDate = DateTime.Now;
					lstDetail.Add(partOutDetail);
				}
			}
			catch (Exception ex)
			{
				ErrorLog.errorLog("Thêm partOutDetail", $"Lỗi InSert partOutDetail {ex.ToString()}", Environment.NewLine);
			}

			//Khi cất kho ngoài xóa order kho trong hiển thị lên AnDon đi
			//if(cboKho.Text.Trim().Contains("KN"))
			//{
			//	TextUtils.ExcuteSQL($"DELETE [ShiStock].[dbo].[AutoAddXK] WHERE OrderCode = N'{txtOrderr.Text.Trim()}' AND StockCode LIKE 'KT%'");
			//}
			try
			{
				//Xóa 2 bảng tạm Run Casse và Run Motor và Update check dữ liệu AddAutoXK khi đang xuất kho casse hoặc motor
				if (cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim() == "KMotor")
				{
					TextUtils.ExcuteProcedure("spDeleteCasseOrMotor",
												new string[] { "@Check", "@Order" },
												new object[] { cboKho.Text.Trim(), txtOrderr.Text.Trim() });
				}
			}
			catch (Exception ex)
			{
				ErrorLog.errorLog("spDeleteCasseOrMotor", $" {ex.ToString()}", Environment.NewLine);
			}
			//frmSaveOK frm = new frmSaveOK();
			//frm.Show();
			//Update trạng thái vào kế hoạch hyp và altax 
			int Stock = 0;//1 KT,2 KN
			try
			{
				if (cboKho.Text.Trim().ToUpper().Contains("KT"))
				{
					Stock = 1;
				}
				else if (cboKho.Text.Trim().ToUpper().Contains("KN"))
				{
					Stock = 2;
				}
				if (cboKho.Text.Trim().ToUpper().Contains("KN") || cboKho.Text.Trim().ToUpper().Contains("KT"))
					TextUtils.ExcuteProcedure("spUpdateShowPlan", new string[] { "@Stock", "@Order", "@Line" }, new object[] { Stock, txtOrderr.Text.Trim(), cboLine.Text.Trim().ToUpper().Contains("HYP") == true ? 1 : 0 });//1 line Hyp, 0 Line altax
			}
			catch (Exception ex)
			{
				ErrorLog.errorLog("spUpdateShowPlan", $" {ex.ToString()}", Environment.NewLine);
			}

			//Xóa bảng tạm theo Order và Tên kho
			if (cboLine.Text.Trim() == "HYP")
			{
				//Check có tồn tại thì không hiển thị 
				int check = TextUtils.ToInt(TextUtils.Select($"SELECT TOP 1 1 FROM [ShiStock].[dbo].[AutoAddXKColor] WHERE OrderCodeAndCnt= N'{txtOrderr.Text.Trim()}'"));
				if (check != 1)
				{
					TextUtils.ExcuteSQL($"DELETE [ShiStock].[dbo].[AutoAddXKColor] WHERE OrderCodeAndCnt=N'{txtOrderr.Text.Trim()}' AND StockCD=N'{cboStockCD.Text.Trim()}' AND StockName=N'{cboKho.Text.Trim()}'");
				}
				//Update chạy sử dụng hoặc không sử dung  VD 1;60 (0 sử dụng, 1 không sử dung) ; 60 là thời gian chạy
				TextUtils.ExcuteSQL($"UPDATE [ShiStock].[dbo].[StatusColorStock] SET {cboKho.Text.Trim()}=N'1;{ TextUtils.ToString(TextUtils.ToInt(TextUtils.ToDate(TextUtils.ToString(_dtStockCD.Rows[cboStockCD.SelectedIndex]["TaktTime"])).TimeOfDay.TotalSeconds) * TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()))}'");
			}
			if (cboKho.Text.Trim().Contains("KT") || cboKho.Text.Trim().Contains("KN"))
				sendDataTCPAnDonPicking(txtOrderr.Text.Trim(), $"Delete {txtQtyAssembleStock.Text.Trim()} {cboKho.Text.Trim()}");
			else if (cboKho.Text.Trim().ToUpper().Contains("KCASSE"))
			{
				sendDataTCPAnDonPicking(_Casse, $"Delete {txtQtyAssembleStock.Text.Trim()} {cboKho.Text.Trim()}");
			}
			else if (cboKho.Text.Trim().ToUpper().Contains("KMOTOR"))
			{
				sendDataTCPAnDonPicking(_Motor, $"Delete {txtQtyAssembleStock.Text.Trim()} {cboKho.Text.Trim()}");
			}

			saveDetail(lstDetail);
			//saveHistory(lstHistory);
			Reset();
			chkIsGeneral.Checked = false;
			_lstCount.Clear();
			_lstID.Clear();
			_lstArticleID.Clear();
		}
		private void txtLocation_KeyDown(object sender, KeyEventArgs e)
		{
			_lstRow.Clear();
			if (txtLocation.Text.Trim() == "") return;
			if (e.KeyCode != Keys.Enter) return;
			_row = -1;
			for (int i = 0; i < _dtOrderPart.Rows.Count; i++)
			{
				string data = TextUtils.ToString(grvData.GetRowCellValue(i, "Shelf"));
				if (data.ToUpper() == txtLocation.Text.Trim().ToUpper())
				{
					_row = i;
					_lstRow.Add(_row);
					//break;
				}
			}
			//DataRow[] rows = _dtOrderPart.Select($"ArticleID = '{txtPartCode.Text.Trim()}'");
			if (_row == -1)
			{
				WarningForm frmWarning = new WarningForm();
				frmWarning.NameKho = cboKho.Text.Trim();
				frmWarning.Order = txtOrderr.Text.Trim();
				frmWarning.LB = "SAI VỊ TRÍ";
				frmWarning.ShowDialog();
				txtLocation.Focus();
				txtLocation.SelectAll();
				//MessageBox.Show("Linh kiện không tồn tại trong Order!", "RTC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			txtPartCode.Focus();
			txtPartCode.SelectAll();
		}

		private void cboKho_SelectedValueChanged(object sender, EventArgs e)
		{

		}
		/// <summary>
		/// đổi màu xanh với những dòng đã điền đầy đủ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void grvData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			if (cboKho.Text.Trim() == "KCasse" || cboKho.Text.Trim() == "KMotor")
			{
				if (Lib.ToInt(grvData.GetRowCellValue(e.RowHandle, colQty)) == Lib.ToInt(grvData.GetRowCellValue(e.RowHandle, colRealQty)) && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colQty)) != "")
				{
					//e.Appearance.BackColor = Color.Lime;
					if (!_lstCount.Contains(e.RowHandle))
						_lstCount.Add(e.RowHandle);
				}
			}
			else if (cboKho.Text.Trim().Contains("KN"))
			{
				if (TextUtils.ToInt(txtQtyAssembleStock.Text.Trim()) == Lib.ToInt(grvData.GetRowCellValue(e.RowHandle, colRealQty)))
				{
					//e.Appearance.BackColor = Color.Lime;
					if (!_lstCount.Contains(e.RowHandle))
						_lstCount.Add(e.RowHandle);
				}
			}
			else if (Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colLoLot)) != "" && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colRealValue)) != "" && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colRealQty)) != "")
			{
				e.Appearance.BackColor = Color.Lime;
				if (!_lstCount.Contains(e.RowHandle))
					_lstCount.Add(e.RowHandle);

			}
		}
		private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if ((e.Column == colColumn1 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn1)) == "")
				|| (e.Column == colColumn2 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn2)) == "")
				|| (e.Column == colColumn3 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn3)) == ""
				|| (e.Column == colColumn4 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn4)) == "")
				|| (e.Column == colColumn5 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn5)) == "")
				|| (e.Column == colColumn6 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn6)) == "")))
			{
				e.Appearance.BackColor = Color.FromArgb(255, 192, 255);
			}
			else if ((e.Column == colColumn1 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn1)) != "")
				|| (e.Column == colColumn2 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn2)) != "")
				|| (e.Column == colColumn3 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn3)) != ""
				|| (e.Column == colColumn4 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn4)) != "")
				|| (e.Column == colColumn5 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn5)) != "")
				|| (e.Column == colColumn6 && Lib.ToString(grvData.GetRowCellValue(e.RowHandle, colColumn6)) != "")))
			{
				e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
			}
		}

		private void btnDeleteOrder_Click(object sender, EventArgs e)
		{
			try
			{
				frmSkipOrder frmSkipOrder = new frmSkipOrder();
				if (frmSkipOrder.ShowDialog() == DialogResult.OK)
				{
					frmChooseRisk frm = new frmChooseRisk();
					if (frm.ShowDialog() == DialogResult.OK)
					{

						TextUtils.ExcuteProcedure("spDeleteStock", new string[] { "@Order", "@Stock" }, new object[] { txtOrderr.Text.Trim(), cboKho.Text.Trim() });
						//Lưu vào bảng biết được người bỏ qua công đoạn
						SkipOrderModel skipOrderModel = new SkipOrderModel();

						skipOrderModel.StockID = TextUtils.ToInt(cboKho.SelectedValue);
						skipOrderModel.StockCDID = TextUtils.ToInt(cboStockCD.SelectedValue);
						skipOrderModel.WorkerName = txtWorkerCode.Text.Trim();
						skipOrderModel.LineName = cboLine.Text.Trim();
						skipOrderModel.OrderCode = txtOrderr.Text.Trim();
						skipOrderModel.PidAssembleStock = txtPidAssembleStock.Text.Trim();
						skipOrderModel.DescriptionAssembleStock = txtDescriptionAssembleStock.Text.Trim();
						skipOrderModel.StockCode = cboKho.Text.Trim();
						skipOrderModel.StockCDCode = cboStockCD.Text.Trim();
						skipOrderModel.CreatDate = DateTime.Now;
						skipOrderModel.Reason = frm.RiskDescription;
						SkipOrderBO.Instance.Insert(skipOrderModel);
						MessageBox.Show("Bỏ qua thành công", "Thông báo", MessageBoxButtons.OK);
						txtOrderr.Text = "";
					}
				}
			}
			catch
			{

			}
		}

		private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboLine.SelectedIndex == 1)
			{
				colColumn6.Visible = false;
			}
			else if (cboLine.SelectedIndex == 2)
			{
				colColumn6.Visible = true;
			}
			cboStockCD.Focus();
			File.WriteAllText(Application.StartupPath + "\\Line.txt", TextUtils.ToString(cboLine.SelectedIndex));
		}

		private void txtOrder_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CboOrder.SelectedIndex == 0) return;
			txtOrderr.Text = CboOrder.Text.Trim();
			txtOrder_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
		}

		private void txtOrder_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(CboOrder.Text))
			{
				CboOrder.BackColor = Color.White;
			}
			else
			{
				CboOrder.BackColor = Color.FromArgb(255, 153, 255);
			}
		}

		private void CboOrder_DrawItem(object sender, DrawItemEventArgs e)
		{
			//ComboBox cbx = sender as ComboBox;
			//if (cbx != null)
			//{
			//	e.DrawBackground();
			//	if (e.Index >= 0)
			//	{
			//		StringFormat sf = new StringFormat();
			//		sf.LineAlignment = StringAlignment.Center;
			//		sf.Alignment = StringAlignment.Center;
			//		Brush brush = new SolidBrush(cbx.ForeColor);
			//		if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) brush = SystemBrushes.HighlightText;
			//		e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
			//	}
			//}
		}
		private void txtOrderr_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtOrderr.Text))
			{
				txtOrderr.BackColor = Color.White;
			}
			else
			{
				txtOrderr.BackColor = Color.FromArgb(255, 153, 255);
			}
		}
	}
}
