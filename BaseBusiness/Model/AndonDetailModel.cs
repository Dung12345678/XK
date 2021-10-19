
using System;
namespace BMS.Model
{
	public class AndonDetailModel : BaseModel
	{
		private int iD;
		private int anDonID;
		private int shiftConfigID;
		private int shiftID;
		private DateTime? shiftStartTime;
		private DateTime? shiftEndTime;
		private int productID;
		private string productCode;
		private string orderCode;
		private string qrCode;
		private int productStepID;
		private string productStepCode;
		private int type;
		private int takt;
		private int makeTime;
		private int periodTime;
		private DateTime? startTime;
		private DateTime? endTime;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int AnDonID
		{
			get { return anDonID; }
			set { anDonID = value; }
		}
	
		public int ShiftConfigID
		{
			get { return shiftConfigID; }
			set { shiftConfigID = value; }
		}
	
		public int ShiftID
		{
			get { return shiftID; }
			set { shiftID = value; }
		}
	
		public DateTime? ShiftStartTime
		{
			get { return shiftStartTime; }
			set { shiftStartTime = value; }
		}
	
		public DateTime? ShiftEndTime
		{
			get { return shiftEndTime; }
			set { shiftEndTime = value; }
		}
	
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}
	
		public string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string QrCode
		{
			get { return qrCode; }
			set { qrCode = value; }
		}
	
		public int ProductStepID
		{
			get { return productStepID; }
			set { productStepID = value; }
		}
	
		public string ProductStepCode
		{
			get { return productStepCode; }
			set { productStepCode = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public int Takt
		{
			get { return takt; }
			set { takt = value; }
		}
	
		public int MakeTime
		{
			get { return makeTime; }
			set { makeTime = value; }
		}
	
		public int PeriodTime
		{
			get { return periodTime; }
			set { periodTime = value; }
		}
	
		public DateTime? StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}
	
		public DateTime? EndTime
		{
			get { return endTime; }
			set { endTime = value; }
		}

        public string WorkerCode { get; set; }

        public string RiskDescription { get; set; }
		public int OkStatus { get; set; }
	}
}
	