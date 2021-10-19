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
	public partial class frmSaveOK : _Forms
	{
		public int _QtyReal;
		public int _QtyPlan;
		public frmSaveOK()
		{
			InitializeComponent();
		}

		private void frmSL_Load(object sender, EventArgs e)
		{
			//Thực tế
			label1.Text = $"Số linh kiện thực tế là: {_QtyReal}";
			//Kế hoạch
			label2.Text = $"Số linh kiện kế hoạch là: {_QtyPlan}";
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
