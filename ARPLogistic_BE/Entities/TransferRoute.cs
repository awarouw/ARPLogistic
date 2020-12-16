using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARPLogistic_BE.Entities
{
    public class TransferRoute : EclipseLayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransferRouteID { get; set; } // int, not null

        [Column(TypeName = "varchar(20)")]
        public string TransferfromCode { get; set; } // varchar(10), not null

        [Column(TypeName = "varchar(20)")]
        public string TransfertoCode { get; set; } // varchar(10), not null

        [Column(TypeName = "varchar(20)")]
        public string InTransitCode { get; set; } // varchar(10), null

        [Column(TypeName = "varchar(20)")]
        public string ShippingAgentCode { get; set; } // varchar(10), null

        [Column(TypeName = "varchar(20)")]
        public string ShippingAgentServiceCode { get; set; } // varchar(10), null

        [Column(TypeName = "decimal(18, 5)")]
        public decimal JarakTempuh { get; set; }

        [Column(TypeName = "decimal(18, 5)")]
        public decimal BiayaToll { get; set; }

        [Column(TypeName = "decimal(18, 5)")]
        public decimal BiayaBBM { get; set; }

        [Column(TypeName = "decimal(18, 5)")]
        public decimal Retribusi { get; set; }

        [Column(TypeName = "decimal(18, 5)")]
        public decimal BiayaLainLain { get; set; }

        public TransferRoute()
        {
            this.TransferRouteID = 0;
            this.TransferfromCode = "";
            this.TransfertoCode = "";
            this.InTransitCode = "";
            this.ShippingAgentCode = "";
            this.ShippingAgentServiceCode = "";
            JarakTempuh = 0;
            BiayaToll = 0;
            BiayaBBM = 0;
            Retribusi = 0;
            BiayaLainLain = 0;
        }
    }
}
