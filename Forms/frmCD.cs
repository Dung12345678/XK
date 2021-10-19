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
	public partial class frmCD : _Forms
	{
		public int _AddNew;
		public AssemblyStockModel _Stock = new AssemblyStockModel();
		public StockCDModel _StockCD = new StockCDModel();
		public frmCD()
		{
			InitializeComponent();
		}
		private void frmStockStepDetail_Load(object sender, EventArgs e)
		{
			if (_AddNew == 1)
			{
				cboStockName.Enabled = true;
			}
			loadCbo();
			loadStockCDDetail();
			txtCDCode.Focus();

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
				_StockCD = new StockCDModel();
				cboStockName.Enabled = true;
				loadStockCDDetail();
				txtCDCode.Focus();
			}
		}
		void loadCbo()
		{
			DataTable dt = TextUtils.Select("SELECT * FROM dbo.AssemblyStock WITH(NOLOCK)");
			cboStockName.DataSource = dt;
			cboStockName.DisplayMember = "Name";
			cboStockName.ValueMember = "ID";

		}
		void loadStockCDDetail()
		{
			txtCDName.Text = _StockCD.CDName;
			txtCDCode.Text = _StockCD.CDCode;
			cboStockName.Text = _Stock.Name;
			txtTaktTime.Value = TextUtils.ToDate3(_StockCD.TaktTime);
			txtLocation.Text = _StockCD.NameLocation.Split('%')[0];
		}
		bool saveData()
		{
			if (!ValidateForm()) return false;
			_StockCD.CDCode = txtCDCode.Text.Trim();
			_StockCD.CDName = txtCDName.Text.Trim();
			_StockCD.StockName = cboStockName.Text.Trim();
			_StockCD.StockID = TextUtils.ToInt(cboStockName.SelectedValue);
			_StockCD.TaktTime = txtTaktTime.Value;
			if (_StockCD.CDCode.Trim().ToUpper().Contains("MOTOR"))
			{
				_StockCD.NameLocation = txtLocation.Text.Trim();
			}
			else
				_StockCD.NameLocation = txtLocation.Text.Trim() + "%";
			if (_StockCD.ID > 0)
			{
				AssemblyStockBO.Instance.Update(_StockCD);
				TextUtils.ExcuteSQL($"Update Location set CDName='{txtCDName.Text.Trim()}' where CDID={_StockCD.ID}");
			}
			else
			{
				_StockCD.ID = (int)AssemblyStockBO.Instance.Insert(_StockCD);
			}
			return true;
		}
		private bool ValidateForm()
		{
			if (txtCDCode.Text.Trim() == "" || txtCDName.Text.Trim() == "" || cboStockName.Text.Trim() == "")
			{
				MessageBox.Show("Xin hãy nhập đầy đủ thông tin", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			string sql1 = "";
			if (_StockCD.ID > 0)
			{
				sql1 = $"SELECT top 1 ID from StockCD WHERE CDCode = N'{txtCDCode.Text.Trim()}' and ID <>'{_StockCD.ID}' and StockID={_Stock.ID}";
			}
			else
			{
				sql1 = $"SELECT top 1 ID from StockCD WHERE CDCode = N'{txtCDCode.Text.Trim()}' and StockID={_Stock.ID}";
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

		private void frmCD_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void txtCDCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			txtCDName.Focus();
		}

		private void label5_Click(object sender, EventArgs e)
		{

		}
	}
}
