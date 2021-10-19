
using System;
namespace BMS.Model
{
	public class PartOutDetailModel : BaseModel
	{
		private int iD;
		private int partOutID;
		private string description;
		private string articleID;
		private string shelf;
		private int qty;
		private string lo;
		private string accessory;
		private int realQty;
		private DateTime? creatDate;
		private string column1;
		private string column2;
		private string column3;
		private string column4;
		private string column5;
		private string column6;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int PartOutID
		{
			get { return partOutID; }
			set { partOutID = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public string ArticleID
		{
			get { return articleID; }
			set { articleID = value; }
		}
	
		public string Shelf
		{
			get { return shelf; }
			set { shelf = value; }
		}
	
		public int Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public string Lo
		{
			get { return lo; }
			set { lo = value; }
		}
	
		public string Accessory
		{
			get { return accessory; }
			set { accessory = value; }
		}
	
		public int RealQty
		{
			get { return realQty; }
			set { realQty = value; }
		}
	
		public DateTime? CreatDate
		{
			get { return creatDate; }
			set { creatDate = value; }
		}
	
		public string Column1
		{
			get { return column1; }
			set { column1 = value; }
		}
	
		public string Column2
		{
			get { return column2; }
			set { column2 = value; }
		}
	
		public string Column3
		{
			get { return column3; }
			set { column3 = value; }
		}
	
		public string Column4
		{
			get { return column4; }
			set { column4 = value; }
		}
	
		public string Column5
		{
			get { return column5; }
			set { column5 = value; }
		}
	
		public string Column6
		{
			get { return column6; }
			set { column6 = value; }
		}
	
	}
}
	