using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPLogistic_BE.Entities
{
    public class NoSeries : EclipseLayer
    {
        public int NoSeriesID { get; set; }
        public string NoSeriesCode { get; set; }
        public string NoSeriesDescription { get; set; }
        public short NoSeriesDefaultNos { get; set; }
        public short NoSeriesManualNos { get; set; }
        public short NoSeriesDateOrder { get; set; }
        public short DistLocationPrefix { get; set; }
    }
}
