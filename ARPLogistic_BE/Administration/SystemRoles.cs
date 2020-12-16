using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemRoles : EclipseLayer 
    {
        public int SystemRolesID { get; set; }
        public string Role { get; set; }
        public string Descriptions { get; set; }
    }
}
