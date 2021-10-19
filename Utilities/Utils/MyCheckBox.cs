using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BMS
{
	public class MyCheckBox : CheckBox
	{
		private CheckBox checkBox1;

		public MyCheckBox()
        {
            this.TextAlign = ContentAlignment.MiddleRight;
		}
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = false; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
			base.OnPaint(e);
			int h = this.ClientSize.Height - 2;
			var rc = new Rectangle(new Point(-1, this.Height / 2 - h / 2), new Size(h, h));
			if (this.FlatStyle == FlatStyle.Flat)
			{
				ControlPaint.DrawCheckBox(e.Graphics, rc, this.Checked ? ButtonState.Flat | ButtonState.Checked : ButtonState.Flat | ButtonState.Normal);
			}
			else
			{
				ControlPaint.DrawCheckBox(e.Graphics, rc, this.Checked ? ButtonState.Checked : ButtonState.Normal);
			}
		}
	}
}
