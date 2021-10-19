
using System;
namespace BMS.Model
{
	public class StatusColorStockModel : BaseModel
	{
		private int iD;
		private string kT1;
		private string kT2;
		private string kN1;
		private string kN2;
		private string kCasse;
		private string kMotor;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string KT1
		{
			get { return kT1; }
			set { kT1 = value; }
		}
	
		public string KT2
		{
			get { return kT2; }
			set { kT2 = value; }
		}
	
		public string KN1
		{
			get { return kN1; }
			set { kN1 = value; }
		}
	
		public string KN2
		{
			get { return kN2; }
			set { kN2 = value; }
		}
	
		public string KCasse
		{
			get { return kCasse; }
			set { kCasse = value; }
		}
	
		public string KMotor
		{
			get { return kMotor; }
			set { kMotor = value; }
		}
	
	}
}
	