
using System;
namespace IE.Model
{
	public partial class ProductWorkingModel : BaseModel
	{
		public int ID {get; set;}
		
		public int ProductID {get; set;}
		
		public int ProductStepID {get; set;}
		
		public int WorkingID {get; set;}
		
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
		
		public bool IsGetAutoValueIP {get; set;}
		
		public string Port {get; set;}
		
		public string IpAddress {get; set;}
		
		public int CheckValueType {get; set;}
		
		public string ProductStepCode {get; set;}
		public int ActionType { get; set; }
		public int IsApproved { get; set; }
		public bool IsHidden { get; set; }
	}
}
	