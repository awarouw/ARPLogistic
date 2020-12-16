using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemMenu : EclipseLayer
    {
        public int SystemMenuID { get; set; }
        public string ParentID { get; set; }
        public string ChildID { get; set; }
        public string SeqNo { get; set; }
    }
}
