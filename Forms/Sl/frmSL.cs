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
	public partial class frmSL : _Forms
	{
		public string numer;
		public string PartCode;
		public frmSL()
		{
			InitializeComponent();
		}

		private void frmSL_Load(object sender, EventArgs e)
		{
			txtNumer.Enabled = false;
			lblMaHang.Text = PartCode.Trim().ToUpper();
			txtNumer.Text = numer.Trim();
			btnOK.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
