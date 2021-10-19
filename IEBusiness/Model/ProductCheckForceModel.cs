
using System;
namespace IE.Model
{
	public partial class ProductCheckForceModel : BaseModel
	{
		public int ID {get; set;}
		
		public string ProductCode {get; set;}
		
		public decimal CheckForceMin {get; set;}
		
		public decimal CheckForceMax {get; set;}
		
		public int GunNumber {get; set;}
		
		public int JobNumber {get; set;}
		
		public int QtyBuLong {get; set;}
		
		public int ShootNumber {get; set;}
		
		public int QtyOcBanGa {get; set;}

		public int QtyOcBanThat { get; set; }

		public decimal SetForce {get; set;}
		
		public string ProductStepCode {get; set;}
		
	}
}
	