using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPLogistic_BE.Entities
{
    public class Employee : EclipseLayer
    {
        public int EmployeeID { get; set; } // int, not null
        public string No { get; set; } // varchar(20), not null
        public string FirstName { get; set; } // varchar(30), not null
        public string MiddleName { get; set; } // varchar(30), not null
        public string LastName { get; set; } // varchar(30), not null
        public string Initials { get; set; } // varchar(30), not null
        public string JobTitle { get; set; } // varchar(30), not null
        public string Address { get; set; } // varchar(50), not null
        public string Address2 { get; set; } // varchar(50), not null
        public string City { get; set; } // varchar(30), not null
        public string PostCode { get; set; } // varchar(20), not null
        public string BloodType { get; set; } // varchar(30), not null
        public string PhoneNo { get; set; } // varchar(30), not null
        public string Extension { get; set; } // varchar(30), not null
        public string MobilePhoneNo { get; set; } // varchar(30), not null
        public string EMail { get; set; } // varchar(80), not null
        public string ReligionCode { get; set; } // varchar(10), not null
        public string JamsostekNo { get; set; } // datetime, not null
        public string BPJSKesehatanNo { get; set; } // datetime, not null
        public string FilePicture { get; set; } // varchar(80), not null
        public DateTime? BirthDate { get; set; } // datetime, not null
        public string SocialSecurityNo { get; set; } // varchar(30), not null
        public string TaxCode { get; set; } // varchar(10), not null
        public string PlaceofBirth { get; set; } // varchar(30), not null
        public string MaritalStatus { get; set; } // varchar(30), not null
        public string TaxStatusCode { get; set; } // varchar(30), not null
        public string BankAccountNo { get; set; } // varchar(30), not null
        public string BankAccountName { get; set; } // varchar(30), not null
        public int Gender { get; set; } // int, not null
        public string Country { get; set; } // varchar(10), not null
        public string ManagerNo { get; set; } // varchar(20), not null
        public string EmplymtContractCode { get; set; } // varchar(10), not null
        public string StatisticsGroupCode { get; set; } // varchar(10), not null
        public string EmployeePostingGroup { get; set; } // varchar(20), not null
        public DateTime? EmploymentDate { get; set; } // datetime, not null
        public int Status { get; set; } // int, not null
        public DateTime? InactiveDate { get; set; } // datetime, not null
        public string CauseofInactivityCode { get; set; } // varchar(10), not null
        public DateTime? TerminationDate { get; set; } // datetime, not null
        public string GroundsforTermCode { get; set; } // varchar(10), not null
        public string GlobalDimension1Code { get; set; } // varchar(20), not null
        public string GlobalDimension2Code { get; set; } // varchar(20), not null
        public string ResourceNo { get; set; } // varchar(20), not null
        public string FaxNo { get; set; } // varchar(30), not null
        public string CompanyEMail { get; set; } // varchar(80), not null
        public string Title { get; set; } // varchar(30), not null
        public string SalespersPurchCode { get; set; } // varchar(10), not null
        public string NoSeries { get; set; } // varchar(10), not null

        public Employee()
        {
            this.EmployeeID = 0;
            this.No = "";
            this.FirstName = "";
            this.MiddleName = "";
            this.LastName = "";
            this.Initials = "";
            this.JobTitle = "";
            this.Address = "";
            this.Address2 = "";
            this.City = "";
            this.PostCode = "";
            this.BloodType = "";
            this.PhoneNo = "";
            this.Extension = "";
            this.MobilePhoneNo = "";
            this.EMail = "";
            this.ReligionCode = "";
            this.JamsostekNo = "";
            this.BPJSKesehatanNo = "";
            this.FilePicture = "";
            this.BirthDate = null;
            this.SocialSecurityNo = "";
            this.TaxCode = "";
            this.PlaceofBirth = "";
            this.MaritalStatus = "";
            this.TaxStatusCode = "";
            this.BankAccountNo = "";
            this.BankAccountName = "";
            this.Gender = 0;
            this.Country = "";
            this.ManagerNo = "";
            this.EmplymtContractCode = "";
            this.StatisticsGroupCode = "";
            this.EmployeePostingGroup = "";
            this.EmploymentDate = null;
            this.Status = 0;
            this.InactiveDate = null;
            this.CauseofInactivityCode = "";
            this.TerminationDate = null;
            this.GroundsforTermCode = "";
            this.GlobalDimension1Code = "";
            this.GlobalDimension2Code = "";
            this.ResourceNo = "";
            this.FaxNo = "";
            this.CompanyEMail = "";
            this.Title = "";
            this.SalespersPurchCode = "";
            this.NoSeries = "";
        }
    }

}
