using BMS.Business;
using BMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
	public partial class frmStock : _Forms
	{
		public AssemblyStockModel _Stock = new AssemblyStockModel();
		public frmStock()
		{
			InitializeComponent();
		}
		private void frmStockStepDetail_Load(object sender, EventArgs e)
		{
			txtStockCode.Text = _Stock.Code;
			txtStockName.Text = _Stock.Name;
			txtStockCode.Focus();

		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (saveData())
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void btnSaveNew_Click(object sender, EventArgs e)
		{
			if (saveData())
			{
				_Stock = new AssemblyStockModel();
				loadStockCDDetail();
			}
		}
		void loadStockCDDetail()
		{
			txtStockName.Text = _Stock.Name;
			txtStockCode.Text = _Stock.Code;
			txtStockCode.Focus();
		}
		bool saveData()
		{
			if (!ValidateForm()) return false;
			_Stock.Name = txtStockName.Text.Trim();
			_Stock.Code = txtStockCode.Text.Trim();
			if (_Stock.ID > 0)
			{
				AssemblyStockBO.Instance.Update(_Stock);
				TextUtils.ExcuteSQL($"Update StockCD set StockName=N'{txtStockName.Text.Trim()}' where StockID={_Stock.ID}");

			}
			else
			{
				_Stock.ID = (int)AssemblyStockBO.Instance.Insert(_Stock);
			}
			return true;
		}
		private bool ValidateForm()
		{
			if (txtStockName.Text.Trim() == "" || txtStockCode.Text.Trim() == "")
			{
				MessageBox.Show("Xin hãy nhập đầy đủ thông tin", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			string sql1 = "";
			if (_Stock.ID > 0)
			{
				sql1 = $"SELECT top 1 ID from AssemblyStock WHERE Code = N'{txtStockCode.Text.Trim()}' and ID <>'{_Stock.ID}'";
			}
			else
			{
				sql1 = $"SELECT top 1 ID from AssemblyStock WHERE Code = N'{txtStockCode.Text.Trim()}'";
			}
			int id = TextUtils.ToInt(TextUtils.ExcuteScalar(sql1));
			if (id > 0)
			{
				MessageBox.Show("Đã tồn tại vị trí", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			return true;
		}

		private void KhaiBaoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSave_Click(null, null);
		}

		private void cấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSaveNew_Click(null, null);
		}

		private void frmStock_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			//this.Dispose();
		}

		private void txtStockCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			txtStockName.Focus();
		}
	}
}
