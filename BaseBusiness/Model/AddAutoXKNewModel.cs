
using System;
namespace BMS.Model
{
	public class AddAutoXKNewModel : BaseModel
	{
		private int iD;
		private string orderCode;
		private string pID;
		private int kT1;
		private int kT2;
		private int kN1;
		private int kN2;
		private int kCasse;
		private int kMotor;
		private DateTime? createDate;
		private int cnt;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
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
	
		public int KT1
		{
			get { return kT1; }
			set { kT1 = value; }
		}
	
		public int KT2
		{
			get { return kT2; }
			set { kT2 = value; }
		}
	
		public int KN1
		{
			get { return kN1; }
			set { kN1 = value; }
		}
	
		public int KN2
		{
			get { return kN2; }
			set { kN2 = value; }
		}
	
		public int KCasse
		{
			get { return kCasse; }
			set { kCasse = value; }
		}
	
		public int KMotor
		{
			get { return kMotor; }
			set { kMotor = value; }
		}
	
		public DateTime? CreateDate
		{
			get { return createDate; }
			set { createDate = value; }
		}
	
		public int Cnt
		{
			get { return cnt; }
			set { cnt = value; }
		}
	
	}
}
	