
using System;
namespace BMS.Model
{
	public class StockCDModel : BaseModel
	{
		private int iD;
		private int stockID;
		private string stockName;
		private string cDName;
		private string cDCode;
		private DateTime? taktTime;
		private string nameLocation;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int StockID
		{
			get { return stockID; }
			set { stockID = value; }
		}
	
		public string StockName
		{
			get { return stockName; }
			set { stockName = value; }
		}
	
		public string CDName
		{
			get { return cDName; }
			set { cDName = value; }
		}
	
		public string CDCode
		{
			get { return cDCode; }
			set { cDCode = value; }
		}
	
		public DateTime? TaktTime
		{
			get { return taktTime; }
			set { taktTime = value; }
		}
	
		public string NameLocation
		{
			get { return nameLocation; }
			set { nameLocation = value; }
		}
	
	}
}
	