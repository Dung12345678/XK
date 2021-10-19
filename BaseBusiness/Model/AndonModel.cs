
using System;
namespace BMS.Model
{
	public class AndonModel : BaseModel
	{
		private int iD;
		private int shiftID;
		private DateTime? shiftStartTime;
		private DateTime? shiftEndTime;
		private DateTime? startTimeBreak1;
		private DateTime? startTimeBreak2;
		private DateTime? startTimeBreak3;
		private DateTime? startTimeBreak4;
		private DateTime? endTimeBreak1;
		private DateTime? endTimeBreak2;
		private DateTime? endTimeBreak3;
		private DateTime? endTimeBreak4;
		private int totalSeconds;
		private DateTime? dateLR;
		private int takt;
		private int qtyPlanDay;
		private int qtyPlanCurrent;
		private int qtyActual;
		private int qtyActualNG;
		private int qtyDelay;
		private int qtyNG;
		private bool isStart;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ShiftID
		{
			get { return shiftID; }
			set { shiftID = value; }
		}
	
		public DateTime? ShiftStartTime
		{
			get { return shiftStartTime; }
			set { shiftStartTime = value; }
		}
	
		public DateTime? ShiftEndTime
		{
			get { return shiftEndTime; }
			set { shiftEndTime = value; }
		}
	
		public DateTime? StartTimeBreak1
		{
			get { return startTimeBreak1; }
			set { startTimeBreak1 = value; }
		}
	
		public DateTime? StartTimeBreak2
		{
			get { return startTimeBreak2; }
			set { startTimeBreak2 = value; }
		}
	
		public DateTime? StartTimeBreak3
		{
			get { return startTimeBreak3; }
			set { startTimeBreak3 = value; }
		}
	
		public DateTime? StartTimeBreak4
		{
			get { return startTimeBreak4; }
			set { startTimeBreak4 = value; }
		}
	
		public DateTime? EndTimeBreak1
		{
			get { return endTimeBreak1; }
			set { endTimeBreak1 = value; }
		}
	
		public DateTime? EndTimeBreak2
		{
			get { return endTimeBreak2; }
			set { endTimeBreak2 = value; }
		}
	
		public DateTime? EndTimeBreak3
		{
			get { return endTimeBreak3; }
			set { endTimeBreak3 = value; }
		}
	
		public DateTime? EndTimeBreak4
		{
			get { return endTimeBreak4; }
			set { endTimeBreak4 = value; }
		}
	
		public int TotalSeconds
		{
			get { return totalSeconds; }
			set { totalSeconds = value; }
		}
	
		public DateTime? DateLR
		{
			get { return dateLR; }
			set { dateLR = value; }
		}
	
		public int Takt
		{
			get { return takt; }
			set { takt = value; }
		}
	
		public int QtyPlanDay
		{
			get { return qtyPlanDay; }
			set { qtyPlanDay = value; }
		}
	
		public int QtyPlanCurrent
		{
			get { return qtyPlanCurrent; }
			set { qtyPlanCurrent = value; }
		}
	
		public int QtyActual
		{
			get { return qtyActual; }
			set { qtyActual = value; }
		}
	
		public int QtyActualNG
		{
			get { return qtyActualNG; }
			set { qtyActualNG = value; }
		}
	
		public int QtyDelay
		{
			get { return qtyDelay; }
			set { qtyDelay = value; }
		}
	
		public int QtyNG
		{
			get { return qtyNG; }
			set { qtyNG = value; }
		}
	
		public bool IsStart
		{
			get { return isStart; }
			set { isStart = value; }
		}
	
	}
}
	