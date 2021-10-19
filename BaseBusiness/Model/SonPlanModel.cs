
using System;
namespace BMS.Model
{
	public class SonPlanModel : BaseModel
	{
		private int iD;
		private DateTime? dateExported;
		private string partCode;
		private int lotSize;
		private int qtyPlan;
		private DateTime? prodDate;
		private int realProdQty;
		private int nG;
		private string orderCode;
		private string saleCode;
		private int oP;
		private string shipTo;
		private string shipVia;
		private string confirmCode;
		private string note;
		private string workerCode;
		private DateTime? printedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public DateTime? DateExported
		{
			get { return dateExported; }
			set { dateExported = value; }
		}
	
		public string PartCode
		{
			get { return partCode; }
			set { partCode = value; }
		}
	
		public int LotSize
		{
			get { return lotSize; }
			set { lotSize = value; }
		}
	
		public int QtyPlan
		{
			get { return qtyPlan; }
			set { qtyPlan = value; }
		}
	
		public DateTime? ProdDate
		{
			get { return prodDate; }
			set { prodDate = value; }
		}
	
		public int RealProdQty
		{
			get { return realProdQty; }
			set { realProdQty = value; }
		}
	
		public int NG
		{
			get { return nG; }
			set { nG = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string SaleCode
		{
			get { return saleCode; }
			set { saleCode = value; }
		}
	
		public int OP
		{
			get { return oP; }
			set { oP = value; }
		}
	
		public string ShipTo
		{
			get { return shipTo; }
			set { shipTo = value; }
		}
	
		public string ShipVia
		{
			get { return shipVia; }
			set { shipVia = value; }
		}
	
		public string ConfirmCode
		{
			get { return confirmCode; }
			set { confirmCode = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string WorkerCode
		{
			get { return workerCode; }
			set { workerCode = value; }
		}
	
		public DateTime? PrintedDate
		{
			get { return printedDate; }
			set { printedDate = value; }
		}
	
	}
}
	