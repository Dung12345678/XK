
using System;
namespace IE.Model
{
	public class ConfigFormulaModel : BaseModel
	{
		private int iD;
		private int productGroupID;
		private string productTypeCode;
		private string formula1;
		private string productGroupCode;
		private string formula2;
		private string formula3;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ProductGroupID
		{
			get { return productGroupID; }
			set { productGroupID = value; }
		}
	
		public string ProductTypeCode
		{
			get { return productTypeCode; }
			set { productTypeCode = value; }
		}
	
		public string Formula1
		{
			get { return formula1; }
			set { formula1 = value; }
		}
		public string ProductGroupCode
		{
			get { return productGroupCode; }
			set { productGroupCode = value; }
		}
		public string Formula2
		{
			get { return formula2; }
			set { formula2 = value; }
		}
		public string Formula3
		{
			get { return formula3; }
			set { formula3 = value; }
		}
	}
}
	