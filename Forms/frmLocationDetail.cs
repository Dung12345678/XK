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
	public partial class frmLocationDetail : _Forms
	{
		public int _AddNew;
		public StockCDModel _CD = new StockCDModel();
		public LocationModel _Location = new LocationModel();
		public frmLocationDetail()
		{
			InitializeComponent();
		}
		private void frmStockStepDetail_Load(object sender, EventArgs e)
		{
			if (_AddNew == 1)
			{
				cboCDName.Enabled = true;
			}
			loadCbo();
			loadStockCDDetail();
			txtLocationCode.Focus();

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
				_Location = new LocationModel();
				cboCDName.Enabled = true;
				loadStockCDDetail();
				txtLocationCode.Focus();
			}
		}
		void loadCbo()
		{
			DataTable dt = TextUtils.Select("SELECT * FROM dbo.StockCD WITH(NOLOCK)");
			cboCDName.DataSource = dt;
			cboCDName.DisplayMember = "CDName";
			cboCDName.ValueMember = "ID";

		}
		void loadStockCDDetail()
		{
			txtLocationName.Text = _Location.LocationName;
			txtLocationCode.Text = _Location.LocationCode;
			cboCDName.Text = _CD.CDName;
		}
		bool saveData()
		{
			if (!ValidateForm()) return false;
			_Location.LocationCode = txtLocationCode.Text.Trim();
			_Location.LocationName = txtLocationName.Text.Trim();
			_Location.CDName = cboCDName.Text.Trim();
			_Location.CDID = _CD.ID;
			if (_Location.ID > 0)
			{
				LocationBO.Instance.Update(_Location);
			}
			else
			{
				_Location.ID = (int)LocationBO.Instance.Insert(_Location);
			}
			return true;
		}
		private bool ValidateForm()
		{
			if (txtLocationCode.Text.Trim() == "" || txtLocationName.Text.Trim() == "" || cboCDName.Text.Trim() == "")
			{
				MessageBox.Show("Xin hãy nhập đầy đủ thông tin", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			string sql1 = "";
			if (_Location.ID > 0)
			{
				sql1 = $"SELECT top 1 ID from Location WHERE LocationCode = N'{txtLocationCode.Text.Trim()}' and ID <>'{_Location.ID}' and CDID = '{_CD.ID}'";
			}
			else
			{
				sql1 = $"SELECT top 1 ID from Location WHERE LocationCode = N'{txtLocationCode.Text.Trim()}' and CDID = '{_CD.ID}'";
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

		private void frmLocationDetail_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void txtLocationCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			txtLocationName.Focus();
		}
	}
}
