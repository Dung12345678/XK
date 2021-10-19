
using System;
namespace IE.Model
{
	public partial class WorkingModel : BaseModel
	{
		public int ID {get; set;}
		
		public int WorkingStepID {get; set;}
		
		public string WorkingName {get; set;}
		
		public int ValueType {get; set;}
		
		public string ValueTypeName {get; set;}
		
		public string PeriodValue {get; set;}
		
		public decimal MinValue {get; set;}
		
		public decimal MaxValue {get; set;}
		
		public string Unit {get; set;}
		
		public int SortOrder {get; set;}
		
		public bool IsGetAutoValueComport {get; set;}
		
		public int Comport {get; set;}
		
		public bool IsDeleted {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
		public int Type {get; set;}
		
		public bool IsGetAutoValueIP {get; set;}
		
		public string IpAddress {get; set;}
		
		public string Port {get; set;}
		
		public int CheckValueType {get; set;}
		
	}
}
	