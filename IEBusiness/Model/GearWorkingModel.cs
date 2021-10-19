
using System;
namespace IE.Model
{
	public partial class GearWorkingModel : BaseModel
	{
		public int ID {get; set;}
		
		public int GearID {get; set;}
		
		public string WorkingName {get; set;}
		
		public int ValueType {get; set;}
		
		public string ValueTypeName {get; set;}
		
		public string PeriodValue {get; set;}
		
		public decimal MinValue {get; set;}
		
		public decimal MaxValue {get; set;}
		
		public decimal DefaultValue {get; set;}
		
		public string TanSuat {get; set;}
		
		public string Unit {get; set;}
		
		public int SortOrder {get; set;}
		
		public int CheckValueType {get; set;}
		
		public bool IsDeleted {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
	}
}
	