using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARPLogistic_BE.Entities
{
    public partial class FixedAsset : EclipseLayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FixedAssetID { get; set; } // int, not null

        [Required]
        [Column(TypeName = "varchar(20)")]
        [ConcurrencyCheck]
        public string No { get; set; } // varchar(20), not null

        [Column(TypeName = "varchar(30)")]
        public string Description { get; set; } // varchar(30), null

        [Column(TypeName = "varchar(30)")]
        public string SearchDescription { get; set; } // varchar(30), null
        [Column(TypeName = "varchar(30)")]
        public string Description2 { get; set; } // varchar(30), null
        [Column(TypeName = "varchar(20)")]
        public string FAClassCode { get; set; } // varchar(10), null
        [Column(TypeName = "varchar(20)")]
        public string FASubclassCode { get; set; } // varchar(10), null
        [Column(TypeName = "varchar(20)")]
        public string GlobalDimension1Code { get; set; } // varchar(20), null
        [Column(TypeName = "varchar(20)")]
        public string GlobalDimension2Code { get; set; } // varchar(20), null
        [Column(TypeName = "varchar(20)")]
        public string LocationCode { get; set; } // varchar(10), null
        [Column(TypeName = "varchar(20)")]
        public string FALocationCode { get; set; } // varchar(10), null
        [Column(TypeName = "varchar(20)")]
        public string VendorNo { get; set; } // varchar(20), null
        public int MainAssetComponent { get; set; } // int, null
        [Column(TypeName = "varchar(20)")]
        public string ComponentofMainAsset { get; set; } // varchar(20), null
        public byte BudgetedAsset { get; set; } // tinyint, null
        public DateTime? WarrantyDate { get; set; } // datetime, null
        [Column(TypeName = "varchar(20)")]
        public string ResponsibleEmployee { get; set; } // varchar(20), null
        [Column(TypeName = "varchar(30)")]
        public string SerialNo { get; set; } // varchar(30), null
        public byte Blocked { get; set; } // tinyint, null
        [Column(TypeName = "varchar(100)")]
        public string FileNamePicture { get; set; } // varchar(100), null
        [Column(TypeName = "varchar(20)")]
        public string MaintenanceVendorNo { get; set; } // varchar(20), null
        public byte UnderMaintenance { get; set; } // tinyint, null
        public DateTime? NextServiceDate { get; set; } // datetime, null
        [Column(TypeName = "varchar(20)")]
        public string NoSeries { get; set; } // varchar(10), null
        [Column(TypeName = "varchar(20)")]
        public string FAPostingGroup { get; set; } // varchar(10), null

        public FixedAsset()
        {
            this.FixedAssetID = 0;
            this.No = "";
            this.Description = "";
            this.SearchDescription = "";
            this.Description2 = "";
            this.FAClassCode = "TANGIBLE";
            this.FASubclassCode = "CAR";
            this.GlobalDimension1Code = "SALES";
            this.GlobalDimension2Code = "";
            this.LocationCode = "SALES";
            this.FALocationCode = "";
            this.VendorNo = "";
            this.MainAssetComponent = 0;
            this.ComponentofMainAsset = "";
            this.BudgetedAsset = 0;
            this.WarrantyDate = null;
            this.ResponsibleEmployee = "";
            this.SerialNo = "";
            this.Blocked = 0;
            this.FileNamePicture = "";
            this.MaintenanceVendorNo = "";
            this.UnderMaintenance = 0;
            this.NextServiceDate = null;
            this.NoSeries = "";
            this.FAPostingGroup = "";
        }

    }
}
