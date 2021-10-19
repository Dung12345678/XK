
using System;
namespace BMS.Model
{
	public class LocationModel : BaseModel
	{
		private int iD;
		private int cDID;
		private string cDName;
		private string locationCode;
		private string locationName;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int CDID
		{
			get { return cDID; }
			set { cDID = value; }
		}
	
		public string CDName
		{
			get { return cDName; }
			set { cDName = value; }
		}
	
		public string LocationCode
		{
			get { return locationCode; }
			set { locationCode = value; }
		}
	
		public string LocationName
		{
			get { return locationName; }
			set { locationName = value; }
		}
	
	}
}
	