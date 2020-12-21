using System;

namespace ARPLogistic_BE.Entities
{
    public partial class RouteTrx : EclipseLayer
    {
        public int RouteTrxID { get; set; } // int, not null
        public string No { get; set; } // varchar(20), not null
        public string Description { get; set; } // varchar(80), null
        public DateTime TrxDate { get; set; } // datetime, not null
        public string StaffNo { get; set; } // varchar(20), not null
        public string FixedAssetNo { get; set; } // varchar(20), not null
        public byte? Blocked { get; set; } // tinyint, null

        public RouteTrx()
        {
            RouteTrxID = 0;
            No = "";
            Description = "";
            TrxDate = DateTime.Today;
            StaffNo = "";
            FixedAssetNo = "";
            Blocked = 0;
        }
    }
}
