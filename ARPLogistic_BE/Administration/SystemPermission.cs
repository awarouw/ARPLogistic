using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemPermission : EclipseLayer
    {
        public int SystemPermissionID { get; set; }
        public string CompanyCode { get; set; }
        public string Role { get; set; }
        public string ObjectID { get; set; }
        public short ReadData { get; set; }
        public short InsertData { get; set; }
        public short ModifyData { get; set; }
        public short DeleteData { get; set; }
        public short ExecuteData { get; set; }
        public short ValueData { get; set; }
    }
}
