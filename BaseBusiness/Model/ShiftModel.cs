
using System;

namespace BMS.Model
{
	public class ShiftModel : BaseModel
	{
		private int iD;
		private int computerID;
		private int userID;
		private DateTime startTime;
		private DateTime endTime;
		private int status;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ComputerID
		{
			get { return computerID; }
			set { computerID = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public DateTime StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}
	
		public DateTime EndTime
		{
			get { return endTime; }
			set { endTime = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
	}
}
	