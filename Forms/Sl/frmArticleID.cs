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
	public partial class frmArticleID : _Forms
	{
		public string ArticleID = "";
		public frmArticleID()
		{
			InitializeComponent();
		
		}

		private void WarningForm_Load(object sender, EventArgs e)
		{
			lbArticleID.Text = ArticleID;
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
