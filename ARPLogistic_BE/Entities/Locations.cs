using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARPLogistic_BE.Entities
{
    public class Locations : EclipseLayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        [ConcurrencyCheck]
        public string LocationCode { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LocationName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name2 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Address2 { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string PhoneNo { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string PhoneNo2 { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string FaxNo { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Contact { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string PostCode { get; set; }
        [Column(TypeName = "varchar(80)")]
        public string EMail { get; set; }
        [Column(TypeName = "varchar(80)")]
        public string HomePage { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string CountryRegionCode { get; set; }
        public short UseAsInTransit { get; set; }
        public short RequirePutaway { get; set; }
        public short RequirePick { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string CrossDockDueDateCalc { get; set; }
        public short UseCrossDocking { get; set; }
        public short RequireReceive { get; set; }
        public short RequireShipment { get; set; }
        public short BinMandatory { get; set; }
        public short DirectedPutawayandPick { get; set; }
        public int DefaultBinSelection { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string OutboundWhseHandlingTime { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string InboundWhseHandlingTime { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string PutawayTemplateCode { get; set; }
        public short UsePutawayWorksheet { get; set; }
        public short PickAccordingtoFEFO { get; set; }
        public short AllowBreakbulk { get; set; }
        public int BinCapacityPolicy { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string OpenShopFloorBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string InboundProductionBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string OutboundProductionBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string AdjustmentBinCode { get; set; }
        public short AlwaysCreatePutawayLine { get; set; }
        public short AlwaysCreatePickLine { get; set; }
        public int SpecialEquipment { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string ReceiptBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string ShipmentBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string CrossDockBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string OutboundBOMBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string InboundBOMBinCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string BaseCalendarCode { get; set; }
        public short UseADCS { get; set; }

        public Locations ShallowCopy()
        {
            return (Locations)this.MemberwiseClone();
        }

        public Locations()
        {
            this.LocationID = 0;
            this.LocationCode = "";
            this.LocationName = "";
            this.Name2 = "";
            this.Address = "";
            this.Address2 = "";
            this.City = "";
            this.PhoneNo = "";
            this.PhoneNo2 = "";
            this.FaxNo = "";
            this.Contact = "";
            this.PostCode = "";
            this.EMail = "";
            this.HomePage = "";
            this.CountryRegionCode = "";
            this.UseAsInTransit = 0;
            this.RequirePutaway = 0;
            this.RequirePick = 0;
            this.CrossDockDueDateCalc = "";
            this.UseCrossDocking = 0;
            this.RequireReceive = 0;
            this.RequireShipment = 0;
            this.BinMandatory = 0;
            this.DirectedPutawayandPick = 0;
            this.DefaultBinSelection = 0;
            this.OutboundWhseHandlingTime = "";
            this.InboundWhseHandlingTime = "";
            this.PutawayTemplateCode = "";
            this.UsePutawayWorksheet = 0;
            this.PickAccordingtoFEFO = 0;
            this.AllowBreakbulk = 0;
            this.BinCapacityPolicy = 0;
            this.OpenShopFloorBinCode = "";
            this.InboundProductionBinCode = "";
            this.OutboundProductionBinCode = "";
            this.AdjustmentBinCode = "";
            this.AlwaysCreatePutawayLine = 0;
            this.AlwaysCreatePickLine = 0;
            this.SpecialEquipment = 0;
            this.ReceiptBinCode = "";
            this.ShipmentBinCode = "";
            this.CrossDockBinCode = "";
            this.OutboundBOMBinCode = "";
            this.InboundBOMBinCode = "";
            this.BaseCalendarCode = "";
            this.UseADCS = 0;
        }
    }
}