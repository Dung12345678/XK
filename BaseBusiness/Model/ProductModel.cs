
using System;
namespace BMS.Model
{
    public partial class ProductModel : BaseModel
    {
        public int ID { get; set; }

        public int ProductGroupID { get; set; }

        public string ProductGroupCode { get; set; }

        public int ProductTypeID { get; set; }

        public string MaVanBan { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string RatioCode { get; set; }

        public string SlowSpeedShaftDimesion { get; set; }

        public string DoDao { get; set; }

        public string MURATA { get; set; }

        public string MotorCode { get; set; }

        public string MauSon { get; set; }

        public string GiamTocTong { get; set; }

        public string TiengOn { get; set; }

        public string PinNumber { get; set; }

        public string LoaiMo { get; set; }

        public string LuongMo { get; set; }

        public DateTime? MEDEDAY { get; set; }

        public string CoilCode { get; set; }

        public string LucCheckGearMotor { get; set; }

        public string LucCheckGear { get; set; }

        public string HuongHopCau { get; set; }

        public string UnitMotor { get; set; }

        public string Loai2TrucCoChan { get; set; }

        public DateTime? ProductDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public decimal LucCheckGearMin { get; set; }

        public decimal LucCheckGearMax { get; set; }

        public decimal LucCheckGearMotorMin { get; set; }

        public decimal LucCheckGearMotorMax { get; set; }

        public int GunNumber { get; set; }
        public int JobNumber { get; set; }
        public int QtyOcBanGa { get; set; }
        public int QtyOcBanThat { get; set; }
    }
}
