using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemUserRoles : EclipseLayer
    {
        public int SystemUserRolesID { get; set; }
        public string CompanyCode { get; set; }
        public string UserCode { get; set; }
        public string Role { get; set; }
        public short DefaultCompany { get; set; }
        public string LastVersion { get; set; }
    }
}
