using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARPLogistic_BE.Entities
{
    public class SystemUsers : EclipseLayer
    {
        public int SystemUsersID { get; set; }

        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime? AllowPostingFrom { get; set; }
        public DateTime? AllowPostingTo { get; set; }
        public short RegisterTime { get; set; }
        public string SalespersPurchCode { get; set; }
        public string ApproverID { get; set; }
        public int SalesAmountApprovalLimit { get; set; }
        public int PurchaseAmountApprovalLimit { get; set; }
        public short UnlimitedSalesApproval { get; set; }
        public short UnlimitedPurchaseApproval { get; set; }
        public string Substitute { get; set; }
        public string EMailAddress { get; set; }
        public int RequestAmountApprovalLimit { get; set; }
        public short UnlimitedRequestApproval { get; set; }
        public DateTime? AllowFAPostingFrom { get; set; }
        public DateTime? AllowFAPostingTo { get; set; }
        public string SalesRespCtrFilter { get; set; }
        public string PurchaseRespCtrFilter { get; set; }
        public string ServiceRespCtr_Filter { get; set; }
        public string DepartmentCode { get; set; }
        public string LocationCode { get; set; }

        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Role { get; set; }

    }
}
