
using System;
namespace BMS.Model
{
	public class AutoAddXKModel : BaseModel
	{
		private int iD;
		private string workerName;
		private string orderCode;
		private string pID;
		private string stockCode;
		private string stockCD;
		private DateTime? creatDate;
		private string casse;
		private string motor;
		private bool checkCasse;
		private bool checkMotor;
		private int cnt;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string WorkerName
		{
			get { return workerName; }
			set { workerName = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string PID
		{
			get { return pID; }
			set { pID = value; }
		}
	
		public string StockCode
		{
			get { return stockCode; }
			set { stockCode = value; }
		}
	
		public string StockCD
		{
			get { return stockCD; }
			set { stockCD = value; }
		}
	
		public DateTime? CreatDate
		{
			get { return creatDate; }
			set { creatDate = value; }
		}
	
		public string Casse
		{
			get { return casse; }
			set { casse = value; }
		}
	
		public string Motor
		{
			get { return motor; }
			set { motor = value; }
		}
	
		public bool CheckCasse
		{
			get { return checkCasse; }
			set { checkCasse = value; }
		}
	
		public bool CheckMotor
		{
			get { return checkMotor; }
			set { checkMotor = value; }
		}
	
		public int Cnt
		{
			get { return cnt; }
			set { cnt = value; }
		}
	
	}
}
	