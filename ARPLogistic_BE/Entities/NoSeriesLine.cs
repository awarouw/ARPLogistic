using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPLogistic_BE.Entities
{
    public class NoSeriesLine : EclipseLayer
    {
        public int NoSeriesLineID { get; set; }
        public string NoSeriesCode { get; set; }
        public int SeqLineNo { get; set; }
        public DateTime? StartingDate { get; set; }
        public string StartingNo { get; set; }
        public string EndingNo { get; set; }
        public string WarningNo { get; set; }
        public int IncrementbyNo { get; set; }
        public string LastNoUsed { get; set; }
        public short isOpen { get; set; }
        public DateTime? LastDateUsed { get; set; }
    }
}
