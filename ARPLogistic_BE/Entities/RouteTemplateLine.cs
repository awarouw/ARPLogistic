namespace ARPLogistic_BE.Entities
{
    public partial class RouteTemplateLine : EclipseLayer
    {
        public int RouteTemplateLineID { get; set; } // int, not null
        public int RouteTemplateID { get; set; } // int, not null
        public string RouteTemplateCode { get; set; } // varchar(20), not null
        public int SeqLineNo { get; set; } // int, not null
        public string TransferFromCode { get; set; } // varchar(20), not null
        public string TransferToCode { get; set; } // varchar(20), not null
        public decimal JarakTempuh { get; set; } // decimal(18,5), null
        public decimal BiayaToll { get; set; } // decimal(18,5), null
        public decimal BiayaBBM { get; set; } // decimal(18,5), null
        public decimal Retribusi { get; set; } // decimal(18,5), null
        public decimal BiayaLainLain { get; set; } // decimal(18,5), null

        public RouteTemplateLine()
        {
            RouteTemplateLineID = 0;
            RouteTemplateID = 0;
            RouteTemplateCode = "";
            SeqLineNo = 0;
            TransferFromCode = "";
            TransferToCode = "";
            JarakTempuh = 0;
            BiayaToll = 0;
            BiayaBBM = 0;
            Retribusi = 0;
            BiayaLainLain = 0;
        }
    }
}
