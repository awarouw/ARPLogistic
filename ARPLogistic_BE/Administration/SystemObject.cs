using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemObject : EclipseLayer
    {
        public string SystemObjectID { get; set; }
        public string ObjectType { get; set; }
        public string ObjectDesc { get; set; }
        public string ObjectSystemName { get; set; }
        public string ObjectSystemArg { get; set; }
        public string ObjectSystemImageFileName { get; set; }
        public string urlObjectName { get; set; }
        public short ObjectSeqNo { get; set; }

        public SystemObject()
        {
            this.SystemObjectID = "";
            this.ObjectType = "";
            this.ObjectDesc = "";
            this.ObjectSystemName = "";
            this.ObjectSystemArg = "";
            this.ObjectSystemImageFileName = "";
            this.urlObjectName = "";
            this.ObjectSeqNo = 0;
        }
    }
}
