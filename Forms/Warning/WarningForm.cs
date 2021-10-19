using BMS.Business;
using BMS.Model;
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
	public partial class WarningForm : _Forms
	{
		public string LB;
		public string LBTieuDe;
		public string Order;
		public string NameKho;
		public string NameKhoCD;
		public string Worker;
		public string Line;
		public WarningForm()
		{
			InitializeComponent();
		}

		private void WarningForm_Load(object sender, EventArgs e)
		{
			label1.Text = LB;
			LBLTIEUDE.Text = LBTieuDe;
		
			if (LBLTIEUDE.Text == "")
			{
				LBLTIEUDE.Visible = false;
				label1.Size = new Size(869, 302);
				label1.Location = new System.Drawing.Point(4, 6);
				label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				
			}
			if (NameKho.Contains("KT") || NameKho.Contains("KN"))
			{
				btnDelete.Visible = false;
			}
			else
			{
				btnDelete.Visible = true;
			}

			textBox1.Focus();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnClose_Click(null, null);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				frmSkipOrder frmSkipOrder = new frmSkipOrder();
				if (frmSkipOrder.ShowDialog() == DialogResult.OK)
				{
					frmChooseRisk frm = new frmChooseRisk();
					if (frm.ShowDialog() == DialogResult.OK)
					{

						TextUtils.ExcuteProcedure("spDeleteStock", new string[] { "@Order", "@Stock" }, new object[] { Order, NameKho });
						//Lưu vào bảng biết được người bỏ qua công đoạn
						SkipOrderModel skipOrderModel = new SkipOrderModel();
						skipOrderModel.WorkerName =Worker;
						skipOrderModel.LineName = Line;
						skipOrderModel.OrderCode = Order;
						skipOrderModel.StockCode = NameKho;
						skipOrderModel.StockCDCode = NameKhoCD;
						skipOrderModel.CreatDate = DateTime.Now;
						skipOrderModel.Reason = frm.RiskDescription;
						SkipOrderBO.Instance.Insert(skipOrderModel);
						MessageBox.Show("Bỏ qua thành công", "Thông báo", MessageBoxButtons.OK);
						this.Dispose();
					}
				}
			}
			catch
			{

			}
		}
	}
}
