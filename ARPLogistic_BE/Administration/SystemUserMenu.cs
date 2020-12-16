using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemUserMenu : EclipseLayer
    {
        public int SystemUserMenuID { get; set; }
        public string CompanyCode { get; set; }
        public string Role { get; set; }
        public string ParentID { get; set; }
        public string ChildID { get; set; }
        public int SeqNo { get; set; }
    }
}
