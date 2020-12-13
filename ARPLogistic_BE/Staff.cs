using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARPLogistic_BE
{
    public partial class Staff : EclipseLayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; } // int, not null

        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20, ErrorMessage = "Your ID is too long (20 characters max)")]
        [ConcurrencyCheck]
        public string No { get; set; } // varchar(20), not null

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "Your First Name is too long (30 characters max)")]
        public string FirstName { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "Your Last Name is too long (30 characters max)")]
        public string LastName { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(30)")]
        public string Address { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(30)")]
        public string Address2 { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(30)")]
        public string City { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(20)")]
        public string PostCode { get; set; } // varchar(20), not null
        [Column(TypeName = "varchar(30)")]
        public string HomePhoneNo { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(30)")]
        public string WorkPhoneNo { get; set; } // varchar(30), not null
        [Column(TypeName = "varchar(20)")]
        public string StoreNo { get; set; } // varchar(10), not null
        [Column(TypeName = "varchar(100)")]
        public string EmailAddress { get; set; } // varchar(100), not null
        public byte TransVoidingAllowed { get; set; } // tinyint, not null
        public byte ManagerPrivileges { get; set; } // tinyint, not null
        public byte XReportPrintingAllowed { get; set; } // tinyint, not null
        public byte TenderDeclAllowed { get; set; } // tinyint, not null
        public byte FloatingDeclAllowed { get; set; } // tinyint, not null
        public int PriceOverride { get; set; } // int, not null
        [Column(TypeName = "decimal(18, 5)")]
        public decimal MaxDiscounttoGivePercent { get; set; } // decimal(18,5), not null
        public byte NoVoidOnlyItemCorr { get; set; } // tinyint, not null
        public byte TransSuspensAllowed { get; set; } // tinyint, not null
        [Column(TypeName = "decimal(18, 5)")]
        public decimal MaxTotalDiscountPercent { get; set; } // decimal(18,5), not null
        public byte OpenDrawwithoutSale { get; set; } // tinyint, not null
        public int EmploymentType { get; set; } // int, not null
        [Column(TypeName = "decimal(18, 5)")]
        public decimal FraudSortField { get; set; } // decimal(18,5), not null
        [Column(TypeName = "varchar(20)")]
        public string NameonReceipt { get; set; } // varchar(15), not null
        [Column(TypeName = "decimal(18, 5)")]
        public decimal HourlyRate { get; set; } // decimal(18,5), not null
        [Column(TypeName = "varchar(20)")]
        public string PayrollNo { get; set; } // varchar(20), not null
        public byte Blocked { get; set; } // tinyint, not null
        public DateTime? DatetoBeBlocked { get; set; } // datetime, not null
        public byte LeftHanded { get; set; } // tinyint, not null
        [Column(TypeName = "varchar(20)")]
        public string SalesPerson { get; set; } // varchar(10), not null
        [Column(TypeName = "varchar(20)")]
        public string NoSeries { get; set; } // varchar(20), not null
        [Column(TypeName = "varchar(20)")]
        public string PermissionGroup { get; set; } // varchar(10), not null
        public byte ReturninTransaction { get; set; } // tinyint, not null
        public byte VoidPrepaymentAllowed { get; set; } // tinyint, not null
        public byte VoidPrepaymentLineAllowed { get; set; } // tinyint, not null
        public byte ChangePrepmtAmtAllowed { get; set; } // tinyint, not null
        public byte AddPrepmtAmtAllowed { get; set; } // tinyint, not null
        public byte NoVoidLineAllowed { get; set; } // tinyint, not null
        public byte NoPaymentAllowed { get; set; } // tinyint, not null
        public byte NoTableTransferAllowed { get; set; } // tinyint, not null
        public byte NoSplitBillAllowed { get; set; } // tinyint, not null
        public byte NoLayoutSwitchingAllowed { get; set; } // tinyint, not null
        public byte NoTableAdjustingAllowed { get; set; } // tinyint, not null
        public byte NoTableDesigningAllowed { get; set; } // tinyint, not null
        public byte ContinueonTSerrors { get; set; } // tinyint, not null
        [Column(TypeName = "varchar(20)")]
        public string LastZReport { get; set; } // varchar(10), not null
        [Column(TypeName = "varchar(20)")]
        public string POSInterfaceProfile { get; set; } // varchar(10), not null
        [Column(TypeName = "varchar(20)")]
        public string Language { get; set; } // varchar(10), not null
        public byte CreateCustomers { get; set; } // tinyint, not null
        public byte ViewSaleshistory { get; set; } // tinyint, not null
        public int CustomerComments { get; set; } // int, not null
        [Column(TypeName = "decimal(18, 5)")]
        public decimal MaxTenderDeclDifference { get; set; } // decimal(18,5), not null
        public int MaxWarningCount { get; set; } // int, not null
        public byte ShowDifferenceinWarning { get; set; } // tinyint, not null
        public int ActionAfterDiffWarning { get; set; } // int, not null
        public byte CIDReportPrintingAllowed { get; set; } // tinyint, not null
        public byte ShowTransAmount { get; set; } // tinyint, not null
        public byte UpdateCustomers { get; set; } // tinyint, not null
        public byte InventoryActive { get; set; } // tinyint, not null
        [Column(TypeName = "varchar(20)")]
        public string InventoryMainMenu { get; set; } // varchar(10), not null

        public Staff ShallowCopy()
        {
            return (Staff)this.MemberwiseClone();
        }

        public Staff()
        {
            this.StaffID = 0;
            this.No = "";
            this.StoreNo = "";
            this.TransVoidingAllowed = 0;
            this.ManagerPrivileges = 0;
            this.XReportPrintingAllowed = 0;
            this.TenderDeclAllowed = 0;
            this.FloatingDeclAllowed = 0;
            this.PriceOverride = 0;
            this.MaxDiscounttoGivePercent = 0;
            this.NoVoidOnlyItemCorr = 0;
            this.TransSuspensAllowed = 0;
            this.MaxTotalDiscountPercent = 0;
            this.OpenDrawwithoutSale = 0;
            this.FirstName = "";
            this.LastName = "";
            this.EmploymentType = 0;
            this.FraudSortField = 0;
            this.NameonReceipt = "";
            this.Address = "";
            this.Address2 = "";
            this.City = "";
            this.PostCode = "";
            this.HomePhoneNo = "";
            this.WorkPhoneNo = "";
            this.HourlyRate = 0;
            this.PayrollNo = "";
            this.Blocked = 0;
            this.DatetoBeBlocked = null;
            this.LeftHanded = 0;
            this.SalesPerson = "";
            this.NoSeries = "";
            this.PermissionGroup = "";
            this.ReturninTransaction = 0;
            this.VoidPrepaymentAllowed = 0;
            this.VoidPrepaymentLineAllowed = 0;
            this.ChangePrepmtAmtAllowed = 0;
            this.AddPrepmtAmtAllowed = 0;
            this.NoVoidLineAllowed = 0;
            this.NoPaymentAllowed = 0;
            this.NoTableTransferAllowed = 0;
            this.NoSplitBillAllowed = 0;
            this.NoLayoutSwitchingAllowed = 0;
            this.NoTableAdjustingAllowed = 0;
            this.NoTableDesigningAllowed = 0;
            this.ContinueonTSerrors = 0;
            this.LastZReport = "";
            this.POSInterfaceProfile = "";
            this.Language = "";
            this.CreateCustomers = 0;
            this.ViewSaleshistory = 0;
            this.CustomerComments = 0;
            this.MaxTenderDeclDifference = 0;
            this.MaxWarningCount = 0;
            this.ShowDifferenceinWarning = 0;
            this.ActionAfterDiffWarning = 0;
            this.CIDReportPrintingAllowed = 0;
            this.ShowTransAmount = 0;
            this.UpdateCustomers = 0;
            this.InventoryActive = 0;
            this.InventoryMainMenu = "";
        }
    }
}
