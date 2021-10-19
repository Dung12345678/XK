
using System;
namespace BMS.Model
{
	public class ShelfModel : BaseModel
	{
		private int iD;
		private int sequenceID;
		private string shelfCode;
		private string shelfName;
		private int shelfNumber;
		private DateTime? creatDate;
		private int sortOrder;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int SequenceID
		{
			get { return sequenceID; }
			set { sequenceID = value; }
		}
	
		public string ShelfCode
		{
			get { return shelfCode; }
			set { shelfCode = value; }
		}
	
		public string ShelfName
		{
			get { return shelfName; }
			set { shelfName = value; }
		}
	
		public int ShelfNumber
		{
			get { return shelfNumber; }
			set { shelfNumber = value; }
		}
	
		public DateTime? CreatDate
		{
			get { return creatDate; }
			set { creatDate = value; }
		}
	
		public int SortOrder
		{
			get { return sortOrder; }
			set { sortOrder = value; }
		}
	
	}
}
	