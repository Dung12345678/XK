using System;
using System.Windows.Forms;

namespace BMS
{
	public partial class frmChooseRisk : Form
	{
		public string RiskDescription = "";
		public frmChooseRisk()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (txtRisk.Text.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập nguyên nhân sự cố!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			RiskDescription = txtRisk.Text.Trim();
			DialogResult = DialogResult.OK;
		}

		private void frmChooseRisk_Load(object sender, EventArgs e)
		{
			txtRisk.Focus();
		}

		private void txtRisk_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				btnAdd.Focus();
			}	
		}
	}
}
