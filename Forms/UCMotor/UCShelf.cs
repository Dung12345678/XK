using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;

namespace BMS
{
	public partial class UCShelf : UserControl
	{
		public string NameShelf;
		public int Qty;
		public UCShelf()
		{
			InitializeComponent();
		}

		private void UCShelf_Load(object sender, EventArgs e)
		{
			lblGia.Text = "GIÁ: " + NameShelf.Trim();
			lblSLTT.Text = "THỰC TẾ: " + TextUtils.ToString(Qty);
			//if (Qty == 0)
			//{
			//	this.BackColor = System.Drawing.Color.Lime;
			//}
			//else
			//{
			//	this.BackColor = System.Drawing.Color.Gray;
			//}

		}
		public void LoadColor(string ShelfCode, int SL)
		{
			try
			{
				if (ShelfCode == "OK")
				{
					this.BackColor = System.Drawing.Color.Aqua;
				}
				else
				{
					this.BackColor = System.Drawing.Color.Gray;
				}

			}
			catch (Exception)
			{

			}
		}
		public void UpdateShelf(string ArticleID, int SL)
		{
			try
			{
				DataTable dt = TextUtils.GetDataTableFromSP("spLoadSLShelf", new string[] { "@ArticleID" }, new object[] { ArticleID });
				if (dt.Rows.Count > 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						ShelfModel shelfModel = new ShelfModel();
						shelfModel = (ShelfModel)ShelfBO.Instance.FindByAttribute("ShelfCode", TextUtils.ToString(dt.Rows[i]["Shelf"]).Trim())[0];
						shelfModel.ShelfNumber = shelfModel.ShelfNumber - TextUtils.ToInt(dt.Rows[i]["SL"]);
						ShelfBO.Instance.Update(shelfModel);
					}
				}
			}
			catch (Exception)
			{

			}

		}
		public void LoadShelfNumber(int SL)
		{
			try
			{
				lblSLTT.Text = "THỰC TẾ: " + SL;
			}
			catch (Exception)
			{

			}

		}
	}
}
