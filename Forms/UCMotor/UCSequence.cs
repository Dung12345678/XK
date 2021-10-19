using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
	public partial class UCSequence : UserControl
	{
		public string SequenceName;
		public UCSequence()
		{
			InitializeComponent();
		}

		private void btnSequence_Click(object sender, EventArgs e)
		{

		}

		private void UCSequence_Load(object sender, EventArgs e)
		{
			lblCaption.Text = SequenceName.Trim();
		}
	}
}
