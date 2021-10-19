
using System;
namespace BMS.Model
{
	public class HistoryShelfMotorModel : BaseModel
	{
		private int iD;
		private string worker;
		private string shelf;
		private string serialNumber;
		private string saleNumBer;
		private int qtySale;
		private int qtyShelf;
		private DateTime? createDate;
		private string articleID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Worker
		{
			get { return worker; }
			set { worker = value; }
		}
	
		public string Shelf
		{
			get { return shelf; }
			set { shelf = value; }
		}
	
		public string SerialNumber
		{
			get { return serialNumber; }
			set { serialNumber = value; }
		}
	
		public string SaleNumBer
		{
			get { return saleNumBer; }
			set { saleNumBer = value; }
		}
	
		public int QtySale
		{
			get { return qtySale; }
			set { qtySale = value; }
		}
	
		public int QtyShelf
		{
			get { return qtyShelf; }
			set { qtyShelf = value; }
		}
	
		public DateTime? CreateDate
		{
			get { return createDate; }
			set { createDate = value; }
		}
	
		public string ArticleID
		{
			get { return articleID; }
			set { articleID = value; }
		}
	
	}
}
	