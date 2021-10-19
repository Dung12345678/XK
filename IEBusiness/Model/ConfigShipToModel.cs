
using System;
namespace IE.Model
{
	public class ConfigShipToModel : BaseModel
	{
		private int iD;
		private string shipTo;
		private bool isHidden;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ShipTo
		{
			get { return shipTo; }
			set { shipTo = value; }
		}
	
		public bool IsHidden
		{
			get { return isHidden; }
			set { isHidden = value; }
		}
	
	}
}
	