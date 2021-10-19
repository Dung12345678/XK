
using System;
namespace BMS.Model
{
	public class PartSonModel : BaseModel
	{
		private int iD;
		private string partCode;
		private string partName;
		private string description;
		private int quantityExporting;
		private int quantityAssembling;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartCode
		{
			get { return partCode; }
			set { partCode = value; }
		}
	
		public string PartName
		{
			get { return partName; }
			set { partName = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int QuantityExporting
		{
			get { return quantityExporting; }
			set { quantityExporting = value; }
		}
	
		public int QuantityAssembling
		{
			get { return quantityAssembling; }
			set { quantityAssembling = value; }
		}
	
	}
}
	