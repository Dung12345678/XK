using BMS.Business;
using BMS.Model;
using DevExpress.XtraCharts.GLGraphics;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{

	public partial class frmLocation : _Forms
	{
		public int ProductID = 0;
		public string ProductCode = "";


		public frmLocation()
		{

			InitializeComponent();
		}
		private void frmProductWorking_Load(object sender, EventArgs e)
		{
			this.Text += " - " + ProductCode;
			loadStep();

		}
		void loadStep()
		{
			DataTable dt = TextUtils.Select("SELECT * FROM dbo.StockCD ORDER BY ID");
			grdData.DataSource = dt;
		}

		void loadLocation()
		{
			int stepID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
			DataTable dt = new DataTable();

			//dt = TextUtils.Select(string.Format("SELECT * FROM dbo.ProductWorking WHERE ProductStepID = {0} ORDER BY SortOrder", stepID));
			dt = TextUtils.LoadDataFromSP("spGetLocation", "A"
				, new string[] { "@CDID" }
				, new object[] { stepID });

			grdDetail.DataSource = dt;
		}

		private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			loadLocation();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			frmLocationDetail frm = new frmLocationDetail();
			int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
			if (id == 0) return;
			StockCDModel model = (StockCDModel)StockCDBO.Instance.FindByPK(id);
			frm._CD = model;
			if (frm.ShowDialog() == DialogResult.OK)
			{
				loadLocation();
				grvDetail.FocusedRowHandle = grvData.RowCount - 1;

			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			try
			{
				int focus = TextUtils.ToInt(grvData.FocusedRowHandle);
				int CDID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
				int LocationID = TextUtils.ToInt(grvDetail.GetFocusedRowCellValue(colLocationID));
				if (CDID == 0 || LocationID == 0) return;
				LocationModel modelLocation = (LocationModel)LocationBO.Instance.FindByPK(LocationID);

				StockCDModel modelCD = (StockCDModel)StockCDBO.Instance.FindByPK(CDID);
				frmLocationDetail frm = new frmLocationDetail();
				frm._Location = modelLocation;
				frm._CD = modelCD;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					loadLocation();
					grvDetail.FocusedRowHandle = focus;
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void grdDetail_DoubleClick(object sender, EventArgs e)
		{
			if (grvDetail.RowCount > 0)
				btnEdit_Click(null, null);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (!grvData.IsDataRow(grvData.FocusedRowHandle))
					return;

				int strID = TextUtils.ToInt(grvDetail.GetFocusedRowCellValue(colLocationID));
				string strName = TextUtils.ToString(grvDetail.GetFocusedRowCellValue(colCDName));

				if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa vị trí [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{
						LocationBO.Instance.DeleteByAttribute("ID", strID);
						grvDetail.DeleteRow(grvData.FocusedRowHandle);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.\n" + ex.ToString());
					}
				}
				loadLocation();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void btnAddStep_Click(object sender, EventArgs e)
		{
			frmCD frm = new frmCD();
			frm._AddNew = 1;
			if (frm.ShowDialog() == DialogResult.OK)
			{
				loadStep();
				grvData.FocusedRowHandle = grvData.RowCount - 1;
			}
		}

		private void btnEditStep_Click(object sender, EventArgs e)
		{
			try
			{
				int focus = TextUtils.ToInt(grvData.FocusedRowHandle);
				int idStock = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colStockID));
				AssemblyStockModel stock = (AssemblyStockModel)AssemblyStockBO.Instance.FindByPK(idStock);
				int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
				if (id == 0) return;
				StockCDModel model = (StockCDModel)StockCDBO.Instance.FindByPK(id);
				frmCD frm = new frmCD();
				frm._Stock = stock;
				frm._StockCD = model;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					loadStep();
					grvData.FocusedRowHandle = focus;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDeleteStep_Click(object sender, EventArgs e)
		{
			if (!grvData.IsDataRow(grvData.FocusedRowHandle))
				return;

			int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

			string strName = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCDName));
			if (LocationBO.Instance.CheckExist("CDID", strID))
			{
				MessageBox.Show("Công đoạn này có vị trí không được xóa!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa sản phẩm [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					StockCDBO.Instance.DeleteByAttribute("ID", strID);
					LocationBO.Instance.DeleteByAttribute("CDID", strID);
					//ProductCheckHistoryDetailBO.Instance.DeleteByAttribute("",);
					//ProductBO.Instance.Delete(strID);
					grvData.DeleteRow(grvData.FocusedRowHandle);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.\n" + ex.ToString());
				}
			}
		}

		private void grvData_DoubleClick(object sender, EventArgs e)
		{
			if (grvData.RowCount > 0)
				btnEditStep_Click(null, null);
		}

		private void btnRestart_Click(object sender, EventArgs e)
		{
			loadLocation();
		}
		private void btnRestartCD_Click(object sender, EventArgs e)
		{
			loadStep();
		}
	}
}
