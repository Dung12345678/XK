
using System;
namespace BMS.Model
{
	public class PartOutModel : BaseModel
	{
		private int iD;
		private int stockID;
		private int stockCDID;
		private string workerName;
		private string lineName;
		private string orderCode;
		private string pidAssembleStock;
		private string descriptionAssembleStock;
		private string stockCode;
		private string stockCDCode;
		private DateTime? creatDate;
		private bool status;
		private DateTime? startTime;
		private DateTime? endTime;
		private int periodTime;
		private int type;
		private string riskDescription;
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
	
		public int StockCDID
		{
			get { return stockCDID; }
			set { stockCDID = value; }
		}
	
		public string WorkerName
		{
			get { return workerName; }
			set { workerName = value; }
		}
	
		public string LineName
		{
			get { return lineName; }
			set { lineName = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string PidAssembleStock
		{
			get { return pidAssembleStock; }
			set { pidAssembleStock = value; }
		}
	
		public string DescriptionAssembleStock
		{
			get { return descriptionAssembleStock; }
			set { descriptionAssembleStock = value; }
		}
	
		public string StockCode
		{
			get { return stockCode; }
			set { stockCode = value; }
		}
	
		public string StockCDCode
		{
			get { return stockCDCode; }
			set { stockCDCode = value; }
		}
	
		public DateTime? CreatDate
		{
			get { return creatDate; }
			set { creatDate = value; }
		}
	
		public bool Status
		{
			get { return status; }
			set { status = value; }
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
	
		public int PeriodTime
		{
			get { return periodTime; }
			set { periodTime = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public string RiskDescription
		{
			get { return riskDescription; }
			set { riskDescription = value; }
		}
	
	}
}
	