
using System;
namespace BMS.Model
{
	public class AutoAddXKColorModel : BaseModel
	{
		private int iD;
		private string orderCodeAndCnt;
		private string stockCD;
		private string stockName;
		private DateTime? createDate;
		private string workerName;
		private int cnt;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string OrderCodeAndCnt
		{
			get { return orderCodeAndCnt; }
			set { orderCodeAndCnt = value; }
		}
	
		public string StockCD
		{
			get { return stockCD; }
			set { stockCD = value; }
		}
	
		public string StockName
		{
			get { return stockName; }
			set { stockName = value; }
		}
	
		public DateTime? CreateDate
		{
			get { return createDate; }
			set { createDate = value; }
		}
	
		public string WorkerName
		{
			get { return workerName; }
			set { workerName = value; }
		}
	
		public int Cnt
		{
			get { return cnt; }
			set { cnt = value; }
		}
	
	}
}
	