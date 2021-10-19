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
	public partial class frmStartXH : _Forms
	{
		public int _QtyReal;
		public int _QtyPlan;
		public frmStartXH()
		{
			InitializeComponent();
		}

		private void frmSL_Load(object sender, EventArgs e)
		{
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
