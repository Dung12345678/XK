
using System;
namespace BMS.Model
{
	public class SONHistoryImExModel : BaseModel
	{
		private int iD;
		private int partID;
		private string partCode;
		private DateTime? dateImEx;
		private int quantity;
		private string orderCode;
		private string productCode;
		private bool isExported;
		private int isAssembled;
		private string workerCode;
		private int hour;
		private int month;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int PartID
		{
			get { return partID; }
			set { partID = value; }
		}
	
		public string PartCode
		{
			get { return partCode; }
			set { partCode = value; }
		}
	
		public DateTime? DateImEx
		{
			get { return dateImEx; }
			set { dateImEx = value; }
		}
	
		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}
	
		public bool IsExported
		{
			get { return isExported; }
			set { isExported = value; }
		}
	
		public int IsAssembled
		{
			get { return isAssembled; }
			set { isAssembled = value; }
		}
	
		public string WorkerCode
		{
			get { return workerCode; }
			set { workerCode = value; }
		}
	
		public int Hour
		{
			get { return hour; }
			set { hour = value; }
		}
	
		public int Month
		{
			get { return month; }
			set { month = value; }
		}
	
	}
}
	