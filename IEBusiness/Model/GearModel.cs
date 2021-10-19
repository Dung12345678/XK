
using System;
namespace IE.Model
{
	public partial class GearModel : BaseModel
	{
		public int ID {get; set;}
		
		public int GearGroupID {get; set;}
		
		public string HYP {get; set;}
		
		public string Gear1 {get; set;}
		
		public string Gear2 {get; set;}
		
		public string Gear3 {get; set;}
		
		public string Lap {get; set;}
		
		public int LotSize {get; set;}
		
		public int GThieu {get; set;}
		
		public int GGiaCongThem {get; set;}
		
		public int WipG {get; set;}
		
		public int OnhandG {get; set;}
		
		public int StockGCQT {get; set;}
		
		public int WipGCQT {get; set;}
		
		public int GCQTThieu {get; set;}
		
		public int WipTruc {get; set;}
		
		public int OrderTrucMoi {get; set;}
		
		public int HypNeed {get; set;}
		
		public decimal SlitMin {get; set;}
		
		public decimal SlitMax {get; set;}
		
		public decimal VibrateMin {get; set;}
		
		public decimal VibrateMax {get; set;}
		
		public decimal DoDaoJigLapMin {get; set;}
		
		public decimal DoDaoJigLapMax {get; set;}
		
		public decimal DoDaoTruocLapMin {get; set;}
		
		public decimal DoDaoTruocLapMax {get; set;}
		
		public decimal DoDaoTruocTesterMin {get; set;}
		
		public decimal DoDaoTruocTesterMax {get; set;}
		public int QtyImage { get; set; }
		public int QtyAudio { get; set; }
	}
}
	