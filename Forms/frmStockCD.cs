using BMS.Business;
using BMS.Model;
using DevExpress.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
	public partial class frmStockCD : _Forms
	{
		int _curentNode = 0;
		int _catID = 0;

		public frmStockCD()
		{
			InitializeComponent();
		}


		private void frmProduct_Load(object sender, EventArgs e)
		{
			loadTree();
		}
		void loadTree()
		{
			try
			{
				DataTable tbl = TextUtils.Select("Select * from AssemblyStock with(nolock) order by ID");

				treeData.DataSource = tbl;
				treeData.KeyFieldName = "ID";
				treeData.PreviewFieldName = "StockCode";
				treeData.ExpandAll();

				DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = treeData.FindNodeByFieldValue("ID", _curentNode);
				treeData.SetFocusedNode(currentNode);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void btnNewGroup_Click(object sender, EventArgs e)
		{
			frmStock frm = new frmStock();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				//_curentNode = frm.CurentNode;
				loadTree();
			}
		}

		private void btnEditGroup_Click(object sender, EventArgs e)
		{
			try
			{
				int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
				if (id == 0) return;
				AssemblyStockModel model = (AssemblyStockModel)AssemblyStockBO.Instance.FindByPK(id);
				frmStock frm = new frmStock();
				frm._Stock = model;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					loadTree();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnDeleteGroup_Click(object sender, EventArgs e)
		{
			try
			{
				if (treeData.DataSource == null) return;
				int id = (int)treeData.Selection[0].GetValue(colIDTree);
				if (id == 0) return;

				if (StockCDBO.Instance.CheckExist("StockID", id))
				{
					MessageBox.Show("Kho này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				if (MessageBox.Show("Bạn có chắc muốn xóa Kho [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
					  TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
				AssemblyStockBO.Instance.Delete(id);
				loadTree();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LoadInfoSearch(int type = 0)
		{
			//string[] paraName = new string[2];
			//object[] paraValue = new object[2];

			if (type == 0)
			{
				_catID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
			}
			else
			{
				_catID = 0;
			}

			//paraName[0] = "@GroupID"; paraValue[0] = _catID;
			//paraName[1] = "@TextFilter"; paraValue[1] = txtName.Text.Trim();

			DataTable arr = TextUtils.LoadDataFromSP("spGetStockCD"
								  , "A"
								  , new string[] { "@StockID", "@TextFilter" }
								   , new object[] { _catID, txtName.Text.Trim() }
					);
			grdData.DataSource = arr;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
			if (id == 0) return;
			AssemblyStockModel model = (AssemblyStockModel)AssemblyStockBO.Instance.FindByPK(id);
			frmCD frm = new frmCD();
			frm._Stock = model;
			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadInfoSearch();
				grvData.FocusedRowHandle = grvData.RowCount - 1;
			}
		}
		int _rownIndex = 0;


		private void btnEdit_Click(object sender, EventArgs e)
		{
			int focus = TextUtils.ToInt(grvData.FocusedRowHandle);
			int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
			int CDID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
			if (id == 0 || CDID == 0) return;
			AssemblyStockModel model = (AssemblyStockModel)AssemblyStockBO.Instance.FindByPK(id);

			StockCDModel model1 = (StockCDModel)StockCDBO.Instance.FindByPK(CDID);
			frmCD frm = new frmCD();
			frm._Stock = model;
			frm._StockCD = model1;
			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadInfoSearch();
				grvData.FocusedRowHandle = focus;
				//grvData.SelectRow(focus);
			}
		}

		private void btnDel_Click(object sender, EventArgs e)
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

			if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa công đoạn này [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

		private void btnFindAll_Click(object sender, EventArgs e)
		{
			LoadInfoSearch(1);
		}
		private void txtName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				LoadInfoSearch(1);
			}
		}

		private void grvData_DoubleClick(object sender, EventArgs e)
		{
			if (grvData.RowCount > 0 && btnEdit.Enabled == true)
				btnEdit_Click(null, null);
		}

		private void btnShowWorking_Click(object sender, EventArgs e)
		{
			frmLocation frm = new frmLocation();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadInfoSearch();
			}

		}
		private void labelControl1_Click(object sender, EventArgs e)
		{

		}
		private void grdData_Click(object sender, EventArgs e)
		{

		}

		private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
		{
			try
			{
				int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
				if (id > 0)
				{
					txtName.Text = txtName.Text = "";
					LoadInfoSearch();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
