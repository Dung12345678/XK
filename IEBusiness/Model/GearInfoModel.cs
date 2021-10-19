
using System;
namespace IE.Model
{
	public partial class GearInfoModel : BaseModel
	{
		public int ID {get; set;}
		
		public string GearCode {get; set;}
		
		public decimal SlitMin {get; set;}
		
		public decimal SlitMax {get; set;}
		
		public decimal VibrateMin {get; set;}
		
		public decimal VibrateMax {get; set;}
		
	}
}
	