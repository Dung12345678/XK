
using System;
namespace IE.Model
{
	public class ConfigFormulaAllModel : BaseModel
	{
		private int iD;
		private int sTT;
		private int productGroupID;
		private string productTypeCode;
		private string productGroupCode;
		private string formula;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int STT
		{
			get { return sTT; }
			set { sTT = value; }
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
	
		public string ProductGroupCode
		{
			get { return productGroupCode; }
			set { productGroupCode = value; }
		}
	
		public string Formula
		{
			get { return formula; }
			set { formula = value; }
		}
	
	}
}
	