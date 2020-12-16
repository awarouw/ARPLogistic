USE [master]
GO
/****** Object:  Database [ARPLogistic]    Script Date: 12/17/2020 12:09:54 AM ******/
CREATE DATABASE [ARPLogistic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARPLogistic', FILENAME = N'E:\SQLData\ARPLogistic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ARPLogistic_log', FILENAME = N'E:\SQLData\ARPLogistic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ARPLogistic] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ARPLogistic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ARPLogistic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ARPLogistic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ARPLogistic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ARPLogistic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ARPLogistic] SET ARITHABORT OFF 
GO
ALTER DATABASE [ARPLogistic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ARPLogistic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ARPLogistic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ARPLogistic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ARPLogistic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ARPLogistic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ARPLogistic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ARPLogistic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ARPLogistic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ARPLogistic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ARPLogistic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ARPLogistic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ARPLogistic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ARPLogistic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ARPLogistic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ARPLogistic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ARPLogistic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ARPLogistic] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ARPLogistic] SET  MULTI_USER 
GO
ALTER DATABASE [ARPLogistic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ARPLogistic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ARPLogistic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ARPLogistic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ARPLogistic] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ARPLogistic] SET QUERY_STORE = OFF
GO
USE [ARPLogistic]
GO
/****** Object:  Table [dbo].[CauseofAbsence]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauseofAbsence](
	[CauseofAbsenceID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[UnitofMeasureCode] [varchar](10) NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [CauseofAbsence$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauseofInactivity]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauseofInactivity](
	[CauseofInactivityID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [CauseofInactivity$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyInformation]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInformation](
	[CompanyCode] [varchar](20) NOT NULL,
	[ParentCompanyCode] [varchar](20) NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[CompanyName2] [varchar](50) NULL,
	[CompanyAddress] [varchar](80) NOT NULL,
	[CompanyAddress2] [varchar](80) NULL,
	[CompanyCity] [varchar](30) NULL,
	[CompanyPhoneNo] [varchar](30) NULL,
	[CompanyPhoneNo2] [varchar](30) NULL,
	[CompanyFaxNo] [varchar](30) NULL,
	[GiroNo] [varchar](20) NULL,
	[BankName] [varchar](50) NULL,
	[BankBranchNo] [varchar](50) NULL,
	[BankAccountNo] [varchar](30) NULL,
	[BankAccountName] [varchar](50) NULL,
	[BankAddress] [varchar](80) NULL,
	[PaymentRoutingNo] [varchar](20) NULL,
	[CustomsPermitNo] [varchar](20) NULL,
	[CustomsPermitDate] [datetime] NULL,
	[VATRegistrationNo] [varchar](20) NULL,
	[RegistrationNo] [varchar](20) NULL,
	[ShiptoName] [varchar](50) NULL,
	[ShiptoName2] [varchar](50) NULL,
	[ShiptoAddress] [varchar](50) NULL,
	[ShiptoAddress2] [varchar](50) NULL,
	[ShiptoCity] [varchar](30) NULL,
	[ShiptoContact] [varchar](50) NULL,
	[LocationCode] [varchar](10) NULL,
	[ImageFolderName] [varchar](250) NULL,
	[PostCode] [varchar](20) NULL,
	[ShiptoPostCode] [varchar](20) NULL,
	[EMail] [varchar](80) NULL,
	[HomePage] [varchar](80) NULL,
	[CountryRegionCode] [varchar](10) NULL,
	[ShiptoCountryRegionCode] [varchar](10) NULL,
	[IBAN] [varchar](50) NULL,
	[SWIFTCode] [varchar](20) NULL,
	[IndustrialClassification] [varchar](30) NULL,
	[AbbreviatedName] [varchar](4) NULL,
	[ShowAbbreviatedName] [tinyint] NULL,
	[SystemIndicator] [int] NULL,
	[CustomSystemIndicatorText] [varchar](250) NULL,
	[SystemIndicatorStyle] [int] NULL,
	[ResponsibilityCenter] [varchar](10) NULL,
	[CheckAvailPeriodCalc] [varchar](32) NULL,
	[CheckAvailTimeBucket] [int] NULL,
	[BaseCalendarCode] [varchar](10) NULL,
	[CalConvergenceTimeFrame] [varchar](32) NULL,
	[ABN] [varchar](11) NULL,
	[TaxPeriod] [int] NULL,
	[ABNDivisionPartNo] [varchar](3) NULL,
	[IRDNo] [varchar](30) NULL,
	[RDOCode] [varchar](3) NULL,
	[VATRegistrationDate] [datetime] NULL,
	[SignInvoiceName] [varchar](50) NULL,
	[SignInvoiceDept] [varchar](50) NULL,
	[InvoiceRemarks] [varchar](250) NULL,
	[APPVersion] [varchar](50) NULL,
	[FileFolder] [varchar](250) NULL,
	[LoginImageName] [varchar](50) NULL,
	[LogoFileName] [varchar](50) NULL,
	[WallFileName] [varchar](50) NULL,
	[SecurityCheck] [varchar](20) NULL,
	[ConnectionString] [varchar](150) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [CompanyInformation$0] PRIMARY KEY CLUSTERED 
(
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryRegion]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryRegion](
	[CountryRegionID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](50) NULL,
	[EUCountryRegionCode] [varchar](10) NULL,
	[IntrastatCode] [varchar](10) NULL,
	[AddressFormat] [int] NULL,
	[ContactAddressFormat] [int] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [CountryRegion$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dimension]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dimension](
	[DimensionID] [int] IDENTITY(1,1) NOT NULL,
	[DimensionCode] [varchar](20) NOT NULL,
	[DimensionName] [varchar](30) NOT NULL,
	[DimensionDescription] [varchar](50) NULL,
	[CodeCaption] [varchar](30) NULL,
	[FilterCaption] [varchar](30) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
	[Blocked] [smallint] NULL,
 CONSTRAINT [PK_Dimension] PRIMARY KEY CLUSTERED 
(
	[DimensionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DimensionValue]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimensionValue](
	[DimensionValueID] [int] IDENTITY(1,1) NOT NULL,
	[DimensionCode] [varchar](20) NOT NULL,
	[DimensionValueCode] [varchar](20) NOT NULL,
	[DimensionValueName] [varchar](50) NOT NULL,
	[DimensionValueType] [int] NULL,
	[ParentDimensionValueCode] [varchar](20) NULL,
	[Indentation] [int] NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
	[Blocked] [smallint] NULL,
 CONSTRAINT [DimensionValue$0] PRIMARY KEY CLUSTERED 
(
	[DimensionCode] ASC,
	[DimensionValueCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[No] [varchar](20) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[MiddleName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Initials] [varchar](30) NULL,
	[JobTitle] [varchar](30) NULL,
	[Address] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](30) NULL,
	[PostCode] [varchar](20) NULL,
	[BloodType] [varchar](2) NULL,
	[PhoneNo] [varchar](30) NULL,
	[MobilePhoneNo] [varchar](30) NULL,
	[EMail] [varchar](80) NULL,
	[ReligionCode] [varchar](10) NULL,
	[JamsostekNo] [varchar](20) NULL,
	[BPJSKesehatanNo] [varchar](20) NULL,
	[FilePicture] [varchar](80) NULL,
	[BirthDate] [datetime] NULL,
	[SocialSecurityNo] [varchar](30) NULL,
	[TaxCode] [varchar](20) NULL,
	[PlaceofBirth] [varchar](30) NULL,
	[MaritalStatus] [varchar](30) NULL,
	[TaxStatusCode] [varchar](30) NULL,
	[BankAccountNo] [varchar](30) NULL,
	[BankAccountName] [varchar](30) NULL,
	[Gender] [int] NULL,
	[Country] [varchar](10) NULL,
	[ManagerNo] [varchar](20) NULL,
	[EmplymtContractCode] [varchar](10) NULL,
	[StatisticsGroupCode] [varchar](10) NULL,
	[EmployeePostingGroup] [varchar](20) NULL,
	[EmploymentDate] [datetime] NULL,
	[Status] [int] NULL,
	[InactiveDate] [datetime] NULL,
	[CauseofInactivityCode] [varchar](10) NULL,
	[TerminationDate] [datetime] NULL,
	[GroundsforTermCode] [varchar](10) NULL,
	[GlobalDimension1Code] [varchar](20) NULL,
	[GlobalDimension2Code] [varchar](20) NULL,
	[ResourceNo] [varchar](20) NULL,
	[FaxNo] [varchar](30) NULL,
	[CompanyEmail] [varchar](80) NULL,
	[Title] [varchar](30) NULL,
	[SalespersPurchCode] [varchar](10) NULL,
	[NoSeries] [varchar](10) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [Employee$0] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeePostingGroup]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePostingGroup](
	[EmployeePostingGroupID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[GLAccountNo] [varchar](20) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [EmployeePostingGroup$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeStatisticsGroup]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeStatisticsGroup](
	[EmployeeStatisticsGroupID] [int] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [EmployeeStatisticsGroup$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmploymentContract]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmploymentContract](
	[EmploymentContractID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [EmploymentContract$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixedAsset]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixedAsset](
	[FixedAssetID] [int] IDENTITY(1,1) NOT NULL,
	[No] [varchar](20) NOT NULL,
	[Description] [varchar](30) NULL,
	[SearchDescription] [varchar](30) NULL,
	[Description2] [varchar](30) NULL,
	[FAClassCode] [varchar](10) NULL,
	[FASubclassCode] [varchar](10) NULL,
	[GlobalDimension1Code] [varchar](20) NULL,
	[GlobalDimension2Code] [varchar](20) NULL,
	[LocationCode] [varchar](10) NULL,
	[FALocationCode] [varchar](10) NULL,
	[VendorNo] [varchar](20) NULL,
	[MainAssetComponent] [int] NULL,
	[ComponentofMainAsset] [varchar](20) NULL,
	[BudgetedAsset] [tinyint] NULL,
	[WarrantyDate] [datetime] NULL,
	[ResponsibleEmployee] [varchar](20) NULL,
	[SerialNo] [varchar](30) NULL,
	[Blocked] [tinyint] NULL,
	[FileNamePicture] [varchar](100) NULL,
	[MaintenanceVendorNo] [varchar](20) NULL,
	[UnderMaintenance] [tinyint] NULL,
	[NextServiceDate] [datetime] NULL,
	[NoSeries] [varchar](10) NULL,
	[FAPostingGroup] [varchar](10) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_FixedAsset] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenLedgerSetup]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenLedgerSetup](
	[GenLedgerSetupID] [int] IDENTITY(1,1) NOT NULL,
	[AllowPostingFrom] [datetime] NULL,
	[AllowPostingTo] [datetime] NULL,
	[RegisterTime] [tinyint] NULL,
	[PmtDiscExclVAT] [tinyint] NULL,
	[UnrealizedVAT] [tinyint] NULL,
	[AdjustforPaymentDisc] [tinyint] NULL,
	[MarkCrMemosasCorrections] [tinyint] NULL,
	[LocalAddressFormat] [int] NULL,
	[InvRoundingPrecisionLCY] [decimal](38, 5) NULL,
	[InvRoundingTypeLCY] [int] NULL,
	[LocalContAddrFormat] [int] NULL,
	[BankAccountNos] [varchar](10) NULL,
	[SummarizeGLEntries] [tinyint] NULL,
	[AmountDecimalPlaces] [varchar](5) NULL,
	[UnitAmountDecimalPlaces] [varchar](5) NULL,
	[AdditionalReportingCurrency] [varchar](10) NULL,
	[VATTolerancePercent] [decimal](38, 5) NULL,
	[LCYCode] [varchar](10) NULL,
	[VATExchangeRateAdjustment] [int] NULL,
	[AmountRoundingPrecision] [decimal](38, 5) NULL,
	[UnitAmountRoundingPrecision] [decimal](38, 5) NULL,
	[ApplnRoundingPrecision] [decimal](38, 5) NULL,
	[GlobalDimension1Code] [varchar](20) NULL,
	[GlobalDimension2Code] [varchar](20) NULL,
	[ShortcutDimension1Code] [varchar](20) NULL,
	[ShortcutDimension2Code] [varchar](20) NULL,
	[ShortcutDimension3Code] [varchar](20) NULL,
	[ShortcutDimension4Code] [varchar](20) NULL,
	[ShortcutDimension5Code] [varchar](20) NULL,
	[ShortcutDimension6Code] [varchar](20) NULL,
	[ShortcutDimension7Code] [varchar](20) NULL,
	[ShortcutDimension8Code] [varchar](20) NULL,
	[MaxVATDifferenceAllowed] [decimal](38, 5) NULL,
	[VATRoundingType] [int] NULL,
	[PmtDiscTolerancePosting] [int] NULL,
	[PaymentDiscountGracePeriod] [varchar](32) NULL,
	[PaymentTolerancePercent] [decimal](38, 5) NULL,
	[MaxPaymentToleranceAmount] [decimal](38, 5) NULL,
	[AdaptMainMenutoPermissions] [tinyint] NULL,
	[AllowGLAccDeletionBefore] [datetime] NULL,
	[CheckGLAccountUsage] [tinyint] NULL,
	[PaymentTolerancePosting] [int] NULL,
	[PmtDiscToleranceWarning] [tinyint] NULL,
	[PaymentToleranceWarning] [tinyint] NULL,
	[LastICTransactionNo] [int] NULL,
	[BilltoSelltoVATCalc] [int] NULL,
	[PrintVATspecificationinLCY] [tinyint] NULL,
	[PrepaymentUnrealizedVAT] [tinyint] NULL,
	[BAStobeLodgedasaGroup] [tinyint] NULL,
	[BASGroupCompany] [tinyint] NULL,
	[BASGSTDivisionFactor] [decimal](38, 5) NULL,
	[AdjustmentMandatory] [tinyint] NULL,
	[EnableIRDNo] [tinyint] NULL,
	[EnableVATRegistrationNo] [tinyint] NULL,
	[AddressValidation] [int] NULL,
	[BarCodeCustomInformation] [int] NULL,
	[FullGSTonPrepayment] [tinyint] NULL,
	[EnableTaxInvoices] [tinyint] NULL,
	[PrintTaxInvoicesonPosting] [tinyint] NULL,
	[ForcePaymentWithInvoice] [tinyint] NULL,
	[PostDatedJournalTemplate] [varchar](10) NULL,
	[PostDatedJournalBatch] [varchar](10) NULL,
	[InterestCalExclVAT] [tinyint] NULL,
	[GSTReport] [tinyint] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [GeneralLedgerSetup$0] PRIMARY KEY CLUSTERED 
(
	[GenLedgerSetupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroundsforTermination]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroundsforTermination](
	[GroundsforTerminationID] [int] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [GroundsforTermination$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationCode] [varchar](10) NOT NULL,
	[LocationName] [varchar](30) NULL,
	[Name2] [varchar](30) NULL,
	[Address] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](30) NULL,
	[PhoneNo] [varchar](30) NULL,
	[PhoneNo2] [varchar](30) NULL,
	[FaxNo] [varchar](30) NULL,
	[Contact] [varchar](50) NULL,
	[PostCode] [varchar](20) NULL,
	[EMail] [varchar](80) NULL,
	[HomePage] [varchar](90) NULL,
	[CountryRegionCode] [varchar](10) NULL,
	[UseAsInTransit] [tinyint] NULL,
	[RequirePutaway] [tinyint] NULL,
	[RequirePick] [tinyint] NULL,
	[CrossDockDueDateCalc] [varchar](32) NULL,
	[UseCrossDocking] [tinyint] NULL,
	[RequireReceive] [tinyint] NULL,
	[RequireShipment] [tinyint] NULL,
	[BinMandatory] [tinyint] NULL,
	[DirectedPutawayandPick] [tinyint] NULL,
	[DefaultBinSelection] [int] NULL,
	[OutboundWhseHandlingTime] [varchar](32) NULL,
	[InboundWhseHandlingTime] [varchar](32) NULL,
	[PutawayTemplateCode] [varchar](10) NULL,
	[UsePutawayWorksheet] [tinyint] NULL,
	[PickAccordingtoFEFO] [tinyint] NULL,
	[AllowBreakbulk] [tinyint] NULL,
	[BinCapacityPolicy] [int] NULL,
	[OpenShopFloorBinCode] [varchar](20) NULL,
	[InboundProductionBinCode] [varchar](20) NULL,
	[OutboundProductionBinCode] [varchar](20) NULL,
	[AdjustmentBinCode] [varchar](20) NULL,
	[AlwaysCreatePutawayLine] [tinyint] NULL,
	[AlwaysCreatePickLine] [tinyint] NULL,
	[SpecialEquipment] [int] NULL,
	[ReceiptBinCode] [varchar](20) NULL,
	[ShipmentBinCode] [varchar](20) NULL,
	[CrossDockBinCode] [varchar](20) NULL,
	[OutboundBOMBinCode] [varchar](20) NULL,
	[InboundBOMBinCode] [varchar](20) NULL,
	[BaseCalendarCode] [varchar](10) NULL,
	[UseADCS] [tinyint] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupField]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupField](
	[LookupFieldID] [int] IDENTITY(1,1) NOT NULL,
	[LookupGroup] [varchar](31) NOT NULL,
	[LookupCode] [varchar](25) NOT NULL,
	[LookupDescription] [varchar](50) NULL,
	[SeqNo] [int] NULL,
	[IndexBy] [varchar](10) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_LookupField_1] PRIMARY KEY CLUSTERED 
(
	[LookupGroup] ASC,
	[LookupCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoSeries]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoSeries](
	[NoSeriesID] [int] IDENTITY(1,1) NOT NULL,
	[NoSeriesCode] [varchar](10) NOT NULL,
	[NoSeriesDescription] [varchar](50) NULL,
	[NoSeriesDefaultNos] [tinyint] NULL,
	[NoSeriesManualNos] [tinyint] NULL,
	[NoSeriesDateOrder] [tinyint] NULL,
	[DistLocationPrefix] [tinyint] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_NoSeries] PRIMARY KEY CLUSTERED 
(
	[NoSeriesCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoSeriesLine]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoSeriesLine](
	[NoSeriesLineID] [int] IDENTITY(1,1) NOT NULL,
	[NoSeriesCode] [varchar](10) NOT NULL,
	[SeqLineNo] [int] NOT NULL,
	[StartingDate] [datetime] NULL,
	[StartingNo] [varchar](20) NULL,
	[EndingNo] [varchar](20) NULL,
	[WarningNo] [varchar](20) NULL,
	[IncrementbyNo] [int] NULL,
	[LastNoUsed] [varchar](20) NULL,
	[isOpen] [tinyint] NULL,
	[LastDateUsed] [datetime] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [NoSeriesLine$0] PRIMARY KEY CLUSTERED 
(
	[NoSeriesCode] ASC,
	[SeqLineNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[RecourceID] [int] IDENTITY(1,1) NOT NULL,
	[No] [varchar](20) NOT NULL,
	[Type] [int] NULL,
	[Name] [varchar](50) NULL,
	[SearchName] [varchar](50) NULL,
	[Name2] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](30) NULL,
	[SocialSecurityNo] [varchar](30) NULL,
	[JobTitle] [varchar](30) NULL,
	[Education] [varchar](30) NULL,
	[ContractClass] [varchar](30) NULL,
	[EmploymentDate] [datetime] NULL,
	[ResourceGroupNo] [varchar](20) NULL,
	[GlobalDimension1Code] [varchar](20) NULL,
	[GlobalDimension2Code] [varchar](20) NULL,
	[BaseUnitofMeasure] [varchar](10) NULL,
	[DirectUnitCost] [decimal](38, 5) NULL,
	[IndirectCostPercent] [decimal](38, 5) NULL,
	[UnitCost] [decimal](38, 5) NULL,
	[ProfitPercent] [decimal](38, 5) NULL,
	[PriceProfitCalculation] [int] NULL,
	[UnitPrice] [decimal](38, 5) NULL,
	[VendorNo] [varchar](20) NULL,
	[Blocked] [tinyint] NULL,
	[GenProdPostingGroup] [varchar](10) NULL,
	[PostCode] [varchar](20) NULL,
	[County] [varchar](30) NULL,
	[AutomaticExtTexts] [tinyint] NULL,
	[NoSeries] [varchar](10) NULL,
	[TaxGroupCode] [varchar](10) NULL,
	[VATProdPostingGroup] [varchar](10) NULL,
	[Country] [varchar](10) NULL,
	[ICPartnerPurchGLAccNo] [varchar](20) NULL,
	[ServiceZoneFilter] [varchar](10) NULL,
	[WHTProductPostingGroup] [varchar](10) NULL,
	[ImageFileName] [varchar](150) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [Resource$0] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salesperson_Purchaser]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salesperson_Purchaser](
	[SalesPerson_PurchaserID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](50) NULL,
	[CommissionPercent] [decimal](38, 5) NULL,
	[GlobalDimension1Code] [varchar](20) NULL,
	[GlobalDimension2Code] [varchar](20) NULL,
	[EMail] [varchar](80) NULL,
	[PhoneNo] [varchar](30) NULL,
	[JobTitle] [varchar](30) NULL,
	[SearchEMail] [varchar](80) NULL,
	[EMail2] [varchar](80) NULL,
	[FloatAmount] [decimal](38, 5) NULL,
	[Store] [varchar](10) NULL,
	[AccountType] [int] NULL,
	[AccountNo] [varchar](20) NULL,
	[RetailCommissionBlocked] [tinyint] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [Salesperson_Purchaser$0] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[systemobject]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systemobject](
	[SystemObjectID] [int] NOT NULL,
	[ObjectName] [varchar](50) NOT NULL,
	[ObjectType] [varchar](20) NULL,
	[ObjectDesc] [varchar](50) NULL,
	[ObjectSystemName] [varchar](50) NULL,
	[ObjectSystemArg] [varchar](50) NULL,
	[ObjectSystemImageFileName] [varchar](50) NULL,
	[urlObjectName] [varchar](150) NULL,
	[ObjectSeqNo] [tinyint] NOT NULL,
	[ControllerName] [varchar](50) NULL,
	[ActionName] [varchar](50) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
	[Icon] [varchar](50) NULL,
 CONSTRAINT [PK_systemobject_1] PRIMARY KEY CLUSTERED 
(
	[SystemObjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[systempermission]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systempermission](
	[SystemPermissionID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [varchar](20) NOT NULL,
	[RoleID] [varchar](20) NOT NULL,
	[ObjectID] [int] NOT NULL,
	[ReadData] [smallint] NOT NULL,
	[InsertData] [smallint] NOT NULL,
	[ModifyData] [smallint] NOT NULL,
	[DeleteData] [smallint] NOT NULL,
	[ExecuteData] [smallint] NOT NULL,
	[ValueData] [smallint] NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_systempermission_1] PRIMARY KEY CLUSTERED 
(
	[CompanyCode] ASC,
	[RoleID] ASC,
	[ObjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[systemroles]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systemroles](
	[SystemRolesID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [varchar](20) NOT NULL,
	[Role] [varchar](20) NOT NULL,
	[Descriptions] [varchar](50) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_systemroles] PRIMARY KEY CLUSTERED 
(
	[CompanyCode] ASC,
	[Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[systemusermenu]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systemusermenu](
	[SystemUserMenuID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [varchar](20) NOT NULL,
	[RoleID] [varchar](20) NOT NULL,
	[ParentID] [int] NOT NULL,
	[ChildID] [int] NOT NULL,
	[SeqNo] [int] NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_systemusermenu_1] PRIMARY KEY CLUSTERED 
(
	[CompanyCode] ASC,
	[RoleID] ASC,
	[ParentID] ASC,
	[ChildID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[systemuserroles]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systemuserroles](
	[SystemUserRolesID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](10) NOT NULL,
	[CompanyCode] [varchar](20) NOT NULL,
	[RoleID] [varchar](20) NOT NULL,
	[DefaultCompany] [tinyint] NOT NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
	[LastVersion] [varchar](20) NULL,
 CONSTRAINT [PK_systemuserroles_1] PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC,
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[systemusers]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systemusers](
	[SystemUsersID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](10) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserPassword] [varchar](50) NULL,
	[AllowPostingFrom] [datetime] NULL,
	[AllowPostingTo] [datetime] NULL,
	[RegisterTime] [tinyint] NULL,
	[SalespersPurchCode] [varchar](10) NULL,
	[ApproverID] [varchar](20) NULL,
	[SalesAmountApprovalLimit] [int] NULL,
	[PurchaseAmountApprovalLimit] [int] NULL,
	[UnlimitedSalesApproval] [tinyint] NULL,
	[UnlimitedPurchaseApproval] [tinyint] NULL,
	[Substitute] [varchar](20) NULL,
	[EMailAddress] [varchar](100) NULL,
	[RequestAmountApprovalLimit] [int] NULL,
	[UnlimitedRequestApproval] [tinyint] NULL,
	[AllowFAPostingFrom] [datetime] NULL,
	[AllowFAPostingTo] [datetime] NULL,
	[SalesRespCtrFilter] [varchar](10) NULL,
	[PurchaseRespCtrFilter] [varchar](10) NULL,
	[ServiceRespCtr_Filter] [varchar](10) NULL,
	[DepartmentCode] [varchar](20) NULL,
	[LocationCode] [varchar](20) NULL,
	[Blocked] [smallint] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_systemusers_1] PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferRoute]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferRoute](
	[TransferRouteID] [int] IDENTITY(1,1) NOT NULL,
	[TransferfromCode] [varchar](10) NOT NULL,
	[TransfertoCode] [varchar](10) NOT NULL,
	[InTransitCode] [varchar](10) NOT NULL,
	[ShippingAgentCode] [varchar](10) NULL,
	[ShippingAgentServiceCode] [varchar](10) NULL,
	[RowStatus] [smallint] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedTime] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [TransferRoute$0] PRIMARY KEY CLUSTERED 
(
	[TransferfromCode] ASC,
	[TransfertoCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CauseofAbsence] ON 
GO
INSERT [dbo].[CauseofAbsence] ([CauseofAbsenceID], [Code], [Description], [UnitofMeasureCode], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'DAYOFF', N'Day Off', N'HOUR', 0, N'System', CAST(N'2018-10-26T17:25:26.503' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CauseofAbsence] ([CauseofAbsenceID], [Code], [Description], [UnitofMeasureCode], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'HOLIDAY', N'Holiday', N'DAY', 0, N'System', CAST(N'2018-10-26T17:25:26.503' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CauseofAbsence] ([CauseofAbsenceID], [Code], [Description], [UnitofMeasureCode], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (3, N'SICK', N'Sick', N'HOUR', 0, N'System', CAST(N'2018-10-26T17:25:26.503' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CauseofAbsence] OFF
GO
SET IDENTITY_INSERT [dbo].[CauseofInactivity] ON 
GO
INSERT [dbo].[CauseofInactivity] ([CauseofInactivityID], [Code], [Description], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'COURSE', N'Attending a Course', 0, N'System', CAST(N'2018-10-26T17:26:25.083' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CauseofInactivity] ([CauseofInactivityID], [Code], [Description], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'LEAVE', N'On Leave', 0, N'System', CAST(N'2018-10-26T17:26:25.083' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CauseofInactivity] ([CauseofInactivityID], [Code], [Description], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (3, N'MATERNITY', N'Maternity Leave', 0, N'System', CAST(N'2018-10-26T17:26:25.083' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CauseofInactivity] OFF
GO
INSERT [dbo].[CompanyInformation] ([CompanyCode], [ParentCompanyCode], [CompanyName], [CompanyName2], [CompanyAddress], [CompanyAddress2], [CompanyCity], [CompanyPhoneNo], [CompanyPhoneNo2], [CompanyFaxNo], [GiroNo], [BankName], [BankBranchNo], [BankAccountNo], [BankAccountName], [BankAddress], [PaymentRoutingNo], [CustomsPermitNo], [CustomsPermitDate], [VATRegistrationNo], [RegistrationNo], [ShiptoName], [ShiptoName2], [ShiptoAddress], [ShiptoAddress2], [ShiptoCity], [ShiptoContact], [LocationCode], [ImageFolderName], [PostCode], [ShiptoPostCode], [EMail], [HomePage], [CountryRegionCode], [ShiptoCountryRegionCode], [IBAN], [SWIFTCode], [IndustrialClassification], [AbbreviatedName], [ShowAbbreviatedName], [SystemIndicator], [CustomSystemIndicatorText], [SystemIndicatorStyle], [ResponsibilityCenter], [CheckAvailPeriodCalc], [CheckAvailTimeBucket], [BaseCalendarCode], [CalConvergenceTimeFrame], [ABN], [TaxPeriod], [ABNDivisionPartNo], [IRDNo], [RDOCode], [VATRegistrationDate], [SignInvoiceName], [SignInvoiceDept], [InvoiceRemarks], [APPVersion], [FileFolder], [LoginImageName], [LogoFileName], [WallFileName], [SecurityCheck], [ConnectionString], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (N'ARPLogistic', N'ARPLogistic', N'ARP Logistic', N'', N'Mangga Dua', N'', N'Jakarta', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', N'', N'', N'', N'', N'', N'', N'Main', N'', N'', N'', N'', N'', N'INDONESIA', N'', N'', N'', N'', N'', 0, 0, N'', 0, N'', N'', 0, N'', N'', N'', 0, N'', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', N'', N'1.0.0.0', N'', N'logo.png', N'logodatar.png', N'wall_Development.jpg', N'CBB0MAJHNAPBPCOA', N'', 0, N'System', CAST(N'2015-10-04T22:11:02.940' AS DateTime), N'LAPTOP-ALVIN - Alvin Warouw', CAST(N'2020-10-27T12:03:00.187' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 
GO
INSERT [dbo].[Locations] ([LocationID], [LocationCode], [LocationName], [Name2], [Address], [Address2], [City], [PhoneNo], [PhoneNo2], [FaxNo], [Contact], [PostCode], [EMail], [HomePage], [CountryRegionCode], [UseAsInTransit], [RequirePutaway], [RequirePick], [CrossDockDueDateCalc], [UseCrossDocking], [RequireReceive], [RequireShipment], [BinMandatory], [DirectedPutawayandPick], [DefaultBinSelection], [OutboundWhseHandlingTime], [InboundWhseHandlingTime], [PutawayTemplateCode], [UsePutawayWorksheet], [PickAccordingtoFEFO], [AllowBreakbulk], [BinCapacityPolicy], [OpenShopFloorBinCode], [InboundProductionBinCode], [OutboundProductionBinCode], [AdjustmentBinCode], [AlwaysCreatePutawayLine], [AlwaysCreatePickLine], [SpecialEquipment], [ReceiptBinCode], [ShipmentBinCode], [CrossDockBinCode], [OutboundBOMBinCode], [InboundBOMBinCode], [BaseCalendarCode], [UseADCS], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'A004', N'Bogor', N'', N'Bogor', N'', N'Bogor', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', 0, 0, 0, N'', N'', N'', N'', N'', N'', 0, 0, N'LAPTOP-ALVIN - Admin', CAST(N'2020-12-16T21:16:25.767' AS DateTime), N'LAPTOP-ALVIN - Admin', CAST(N'2020-12-16T21:16:42.730' AS DateTime))
GO
INSERT [dbo].[Locations] ([LocationID], [LocationCode], [LocationName], [Name2], [Address], [Address2], [City], [PhoneNo], [PhoneNo2], [FaxNo], [Contact], [PostCode], [EMail], [HomePage], [CountryRegionCode], [UseAsInTransit], [RequirePutaway], [RequirePick], [CrossDockDueDateCalc], [UseCrossDocking], [RequireReceive], [RequireShipment], [BinMandatory], [DirectedPutawayandPick], [DefaultBinSelection], [OutboundWhseHandlingTime], [InboundWhseHandlingTime], [PutawayTemplateCode], [UsePutawayWorksheet], [PickAccordingtoFEFO], [AllowBreakbulk], [BinCapacityPolicy], [OpenShopFloorBinCode], [InboundProductionBinCode], [OutboundProductionBinCode], [AdjustmentBinCode], [AlwaysCreatePutawayLine], [AlwaysCreatePickLine], [SpecialEquipment], [ReceiptBinCode], [ShipmentBinCode], [CrossDockBinCode], [OutboundBOMBinCode], [InboundBOMBinCode], [BaseCalendarCode], [UseADCS], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'B002', N'Bandung', N'', N'Bandung', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', 0, 0, 0, N'', N'', N'', N'', N'', N'', 0, 0, N'LAPTOP-ALVIN - Admin', CAST(N'2020-12-16T21:16:51.717' AS DateTime), N'LAPTOP-ALVIN - Admin', CAST(N'2020-12-16T21:17:04.817' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[LookupField] ON 
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (17, N'EmployeeStatus', N'0', N'Active', 0, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (18, N'EmployeeStatus', N'1', N'InActive', 1, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (19, N'EmployeeStatus', N'2', N'Terminated', 2, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (14, N'Gender', N'0', N'', 0, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (15, N'Gender', N'1', N'Female', 1, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (16, N'Gender', N'2', N'Male', 2, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (8, N'MaritalStatus', N'0', N'', 0, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (9, N'MaritalStatus', N'1', N'TK', 1, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (10, N'MaritalStatus', N'2', N'K', 2, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (11, N'MaritalStatus', N'3', N'K1', 3, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (12, N'MaritalStatus', N'4', N'K2', 4, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (13, N'MaritalStatus', N'5', N'K3', 5, N'SeqNo', 0, N'System', CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'Religions', N'0', N'', 0, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'Religions', N'1', N'Kristen', 1, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (3, N'Religions', N'2', N'Islam', 2, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (4, N'Religions', N'3', N'Hindu', 3, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (5, N'Religions', N'4', N'Budha', 4, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (6, N'Religions', N'5', N'Katolik', 5, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[LookupField] ([LookupFieldID], [LookupGroup], [LookupCode], [LookupDescription], [SeqNo], [IndexBy], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (7, N'Religions', N'6', N'Konghucu', 6, N'SeqNo', 0, N'System', CAST(N'2018-11-12T00:00:00.000' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[LookupField] OFF
GO
SET IDENTITY_INSERT [dbo].[NoSeries] ON 
GO
INSERT [dbo].[NoSeries] ([NoSeriesID], [NoSeriesCode], [NoSeriesDescription], [NoSeriesDefaultNos], [NoSeriesManualNos], [NoSeriesDateOrder], [DistLocationPrefix], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'EMP', N'Employee', 1, 1, 0, 0, 0, N'System', CAST(N'2015-04-29T11:05:10.137' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[NoSeries] OFF
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (1, N'Main', N'Menu', N'Main Menu', N'', N'', N'Application', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-05-12T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (100000000, N'Setup', N'Menu', N'Setup', N'', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (101000000, N'Location', N'Form', N'Location', N'frmLocations', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (102000000, N'FixedAsset', N'Form', N'Finxed Asset', N'frmFixedAsset', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (103000000, N'Employee', N'Form', N'Employee', N'frmEmployee', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (104000000, N'Route', N'Form', N'Route', N'frmRoute', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (110000000, N'RouteTemplate', N'Form', N'Route Template', N'frmRouteTemplate', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (120000000, N'RouteTrx', N'Form', N'Route Transaction', N'frmRouteTrx', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[systempermission] ON 
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'ARPLogistic', N'Admin', 1, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'ARPLogistic', N'Admin', 100000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (3, N'ARPLogistic', N'Admin', 101000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (4, N'ARPLogistic', N'Admin', 102000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (5, N'ARPLogistic', N'Admin', 103000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (6, N'ARPLogistic', N'Admin', 104000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (7, N'ARPLogistic', N'Admin', 110000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (8, N'ARPLogistic', N'Admin', 120000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[systempermission] OFF
GO
SET IDENTITY_INSERT [dbo].[systemroles] ON 
GO
INSERT [dbo].[systemroles] ([SystemRolesID], [CompanyCode], [Role], [Descriptions], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'ARPLogistic', N'Admin', N'Admin', 0, NULL, CAST(N'2015-09-09T08:18:08.927' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[systemroles] OFF
GO
SET IDENTITY_INSERT [dbo].[systemusermenu] ON 
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'ARPLogistic', N'Admin', 1, 100000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'ARPLogistic', N'Admin', 1, 110000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (3, N'ARPLogistic', N'Admin', 1, 120000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (4, N'ARPLogistic', N'Admin', 100000000, 101000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (5, N'ARPLogistic', N'Admin', 100000000, 102000000, 2, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (6, N'ARPLogistic', N'Admin', 100000000, 103000000, 3, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (7, N'ARPLogistic', N'Admin', 100000000, 104000000, 4, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[systemusermenu] OFF
GO
SET IDENTITY_INSERT [dbo].[systemuserroles] ON 
GO
INSERT [dbo].[systemuserroles] ([SystemUserRolesID], [UserCode], [CompanyCode], [RoleID], [DefaultCompany], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [LastVersion]) VALUES (1, N'Admin', N'ARPLogistic', N'Admin', 1, 0, NULL, CAST(N'2015-09-09T08:49:17.063' AS DateTime), N'LAPTOP-ALVIN - Admin', CAST(N'2020-12-16T23:07:57.340' AS DateTime), N'1.0.0.0')
GO
SET IDENTITY_INSERT [dbo].[systemuserroles] OFF
GO
SET IDENTITY_INSERT [dbo].[systemusers] ON 
GO
INSERT [dbo].[systemusers] ([SystemUsersID], [UserCode], [UserName], [UserPassword], [AllowPostingFrom], [AllowPostingTo], [RegisterTime], [SalespersPurchCode], [ApproverID], [SalesAmountApprovalLimit], [PurchaseAmountApprovalLimit], [UnlimitedSalesApproval], [UnlimitedPurchaseApproval], [Substitute], [EMailAddress], [RequestAmountApprovalLimit], [UnlimitedRequestApproval], [AllowFAPostingFrom], [AllowFAPostingTo], [SalesRespCtrFilter], [PurchaseRespCtrFilter], [ServiceRespCtr_Filter], [DepartmentCode], [LocationCode], [Blocked], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'Admin', N'Admin', N'21232f297a57a5a743894a0e4a801fc3', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, N'', N'', 0, 0, 0, 0, N'', N'', 0, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', N'', N'Admin', N'', 0, 0, N'Alvin', CAST(N'2015-02-04T00:00:00.000' AS DateTime), N'Alvin', CAST(N'2017-06-13T09:26:32.387' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[systemusers] OFF
GO
/****** Object:  Index [IX_CauseofAbsence]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[CauseofAbsence] ADD  CONSTRAINT [IX_CauseofAbsence] UNIQUE NONCLUSTERED 
(
	[CauseofAbsenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_CauseofInactivity]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[CauseofInactivity] ADD  CONSTRAINT [IX_CauseofInactivity] UNIQUE NONCLUSTERED 
(
	[CauseofInactivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_CountryRegion]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[CountryRegion] ADD  CONSTRAINT [IX_CountryRegion] UNIQUE NONCLUSTERED 
(
	[CountryRegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_Dimension]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[Dimension] ADD  CONSTRAINT [IX_Dimension] UNIQUE NONCLUSTERED 
(
	[DimensionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_DimensionValue]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[DimensionValue] ADD  CONSTRAINT [IX_DimensionValue] UNIQUE NONCLUSTERED 
(
	[DimensionValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeStatisticsGroup]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[EmployeeStatisticsGroup] ADD  CONSTRAINT [IX_EmployeeStatisticsGroup] UNIQUE NONCLUSTERED 
(
	[EmployeeStatisticsGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmploymentContract]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[EmploymentContract] ADD  CONSTRAINT [IX_EmploymentContract] UNIQUE NONCLUSTERED 
(
	[EmploymentContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_FixedAsset]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[FixedAsset] ADD  CONSTRAINT [IX_FixedAsset] UNIQUE NONCLUSTERED 
(
	[FixedAssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroundsforTermination]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[GroundsforTermination] ADD  CONSTRAINT [IX_GroundsforTermination] UNIQUE NONCLUSTERED 
(
	[GroundsforTerminationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_Location]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[Locations] ADD  CONSTRAINT [IX_Location] UNIQUE NONCLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_LookupField]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[LookupField] ADD  CONSTRAINT [IX_LookupField] UNIQUE NONCLUSTERED 
(
	[LookupFieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NoSeries]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[NoSeries] ADD  CONSTRAINT [IX_NoSeries] UNIQUE NONCLUSTERED 
(
	[NoSeriesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_NoSeriesLine]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[NoSeriesLine] ADD  CONSTRAINT [IX_NoSeriesLine] UNIQUE NONCLUSTERED 
(
	[NoSeriesLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_Resource]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[Resource] ADD  CONSTRAINT [IX_Resource] UNIQUE NONCLUSTERED 
(
	[RecourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salesperson_Purchaser]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [IX_Salesperson_Purchaser] UNIQUE NONCLUSTERED 
(
	[SalesPerson_PurchaserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
GO
/****** Object:  Index [IX_systempermission]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [IX_systempermission] UNIQUE NONCLUSTERED 
(
	[SystemPermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SystemUserMenu]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [IX_SystemUserMenu] UNIQUE NONCLUSTERED 
(
	[SystemUserMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_systemuserroles]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[systemuserroles] ADD  CONSTRAINT [IX_systemuserroles] UNIQUE NONCLUSTERED 
(
	[SystemUserRolesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_systemusers]    Script Date: 12/17/2020 12:09:55 AM ******/
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [IX_systemusers] UNIQUE NONCLUSTERED 
(
	[SystemUsersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CauseofAbsence] ADD  CONSTRAINT [DF_CauseofAbsence_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[CauseofAbsence] ADD  CONSTRAINT [DF_CauseofAbsence_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[CauseofAbsence] ADD  CONSTRAINT [DF_CauseofAbsence_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[CauseofInactivity] ADD  CONSTRAINT [DF_CauseofInactivity_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[CauseofInactivity] ADD  CONSTRAINT [DF_CauseofInactivity_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[CauseofInactivity] ADD  CONSTRAINT [DF_CauseofInactivity_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[CompanyInformation] ADD  CONSTRAINT [DF_CompanyInformation_APPVersion]  DEFAULT ('') FOR [APPVersion]
GO
ALTER TABLE [dbo].[CompanyInformation] ADD  CONSTRAINT [DF_CompanyInformation_SecurityCheck]  DEFAULT ('') FOR [SecurityCheck]
GO
ALTER TABLE [dbo].[CompanyInformation] ADD  CONSTRAINT [DF_CompanyInformation_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[CompanyInformation] ADD  CONSTRAINT [DF_CompanyInformation_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[CountryRegion] ADD  CONSTRAINT [DF_CountryRegion_AddressFormat]  DEFAULT ((0)) FOR [AddressFormat]
GO
ALTER TABLE [dbo].[CountryRegion] ADD  CONSTRAINT [DF_CountryRegion_ContactAddressFormat]  DEFAULT ((0)) FOR [ContactAddressFormat]
GO
ALTER TABLE [dbo].[CountryRegion] ADD  CONSTRAINT [DF_CountryRegion_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[CountryRegion] ADD  CONSTRAINT [DF_CountryRegion_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Dimension] ADD  CONSTRAINT [DF_Dimension_Blocked]  DEFAULT ((0)) FOR [Blocked]
GO
ALTER TABLE [dbo].[DimensionValue] ADD  CONSTRAINT [DF_DimensionValue_Indentation]  DEFAULT ((0)) FOR [Indentation]
GO
ALTER TABLE [dbo].[DimensionValue] ADD  CONSTRAINT [DF_DimensionValue_Blocked]  DEFAULT ((0)) FOR [Blocked]
GO
ALTER TABLE [dbo].[EmployeePostingGroup] ADD  CONSTRAINT [DF_EmployeePostingGroup_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[EmployeePostingGroup] ADD  CONSTRAINT [DF_EmployeePostingGroup_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[EmployeePostingGroup] ADD  CONSTRAINT [DF_EmployeePostingGroup_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[EmployeeStatisticsGroup] ADD  CONSTRAINT [DF_EmployeeStatisticsGroup_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[EmployeeStatisticsGroup] ADD  CONSTRAINT [DF_EmployeeStatisticsGroup_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[EmployeeStatisticsGroup] ADD  CONSTRAINT [DF_EmployeeStatisticsGroup_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[EmploymentContract] ADD  CONSTRAINT [DF_EmploymentContract_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[EmploymentContract] ADD  CONSTRAINT [DF_EmploymentContract_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[EmploymentContract] ADD  CONSTRAINT [DF_EmploymentContract_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[FixedAsset] ADD  CONSTRAINT [DF_FixedAsset_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[FixedAsset] ADD  CONSTRAINT [DF_FixedAsset_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[GenLedgerSetup] ADD  CONSTRAINT [DF_GenLedgerSetup_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[GroundsforTermination] ADD  CONSTRAINT [DF_GroundsforTermination_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[GroundsforTermination] ADD  CONSTRAINT [DF_GroundsforTermination_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[GroundsforTermination] ADD  CONSTRAINT [DF_GroundsforTermination_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[LookupField] ADD  CONSTRAINT [DF_LookupField_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[LookupField] ADD  CONSTRAINT [DF_LookupField_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[LookupField] ADD  CONSTRAINT [DF_LookupField_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[NoSeries] ADD  CONSTRAINT [DF_NoSeries_NoSeriesDefaultNos]  DEFAULT ((0)) FOR [NoSeriesDefaultNos]
GO
ALTER TABLE [dbo].[NoSeries] ADD  CONSTRAINT [DF_NoSeries_NoSeriesManualNos]  DEFAULT ((0)) FOR [NoSeriesManualNos]
GO
ALTER TABLE [dbo].[NoSeries] ADD  CONSTRAINT [DF_NoSeries_NoSeriesDateOrder]  DEFAULT ((0)) FOR [NoSeriesDateOrder]
GO
ALTER TABLE [dbo].[NoSeries] ADD  CONSTRAINT [DF_NoSeries_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[NoSeries] ADD  CONSTRAINT [DF_NoSeries_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Resource] ADD  CONSTRAINT [DF_Resource_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[Resource] ADD  CONSTRAINT [DF_Resource_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Resource] ADD  CONSTRAINT [DF_Resource_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [DF_Salesperson_Purchaser_CommissionPercet]  DEFAULT ((0)) FOR [CommissionPercent]
GO
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [DF_Salesperson_Purchaser_FloatAmount]  DEFAULT ((0)) FOR [FloatAmount]
GO
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [DF_Salesperson_Purchaser_AccountType]  DEFAULT ((0)) FOR [AccountType]
GO
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [DF_Salesperson_Purchaser_RetailCommissionBlocked]  DEFAULT ((0)) FOR [RetailCommissionBlocked]
GO
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [DF_Salesperson_Purchaser_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[Salesperson_Purchaser] ADD  CONSTRAINT [DF_Salesperson_Purchaser_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[systemobject] ADD  CONSTRAINT [DF_systemobject_urlObjectName]  DEFAULT ('') FOR [urlObjectName]
GO
ALTER TABLE [dbo].[systemobject] ADD  CONSTRAINT [DF_systemobject_ObjectSeqNo]  DEFAULT ((1)) FOR [ObjectSeqNo]
GO
ALTER TABLE [dbo].[systemobject] ADD  CONSTRAINT [DF_systemobject_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[systemobject] ADD  CONSTRAINT [DF_systemobject_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[systemobject] ADD  CONSTRAINT [DF_systemobject_Icon]  DEFAULT ('') FOR [Icon]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_CompanyID]  DEFAULT ((1)) FOR [CompanyCode]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_ReadData]  DEFAULT ((1)) FOR [ReadData]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_InsertData]  DEFAULT ((0)) FOR [InsertData]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_ModifyData]  DEFAULT ((0)) FOR [ModifyData]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_DeleteData]  DEFAULT ((0)) FOR [DeleteData]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_ExecuteData]  DEFAULT ((1)) FOR [ExecuteData]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_ValueData]  DEFAULT ((0)) FOR [ValueData]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [DF_systempermission_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[systemroles] ADD  CONSTRAINT [DF_systemroles_CompanyID]  DEFAULT ((1)) FOR [CompanyCode]
GO
ALTER TABLE [dbo].[systemroles] ADD  CONSTRAINT [DF_systemroles_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[systemroles] ADD  CONSTRAINT [DF_systemroles_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [DF_systemusermenu_SeqNo]  DEFAULT ((0)) FOR [SeqNo]
GO
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [DF_SystemUserMenu_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [DF_SystemUserMenu_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[systemuserroles] ADD  CONSTRAINT [DF_systemuserroles_CompanyID]  DEFAULT ((1)) FOR [CompanyCode]
GO
ALTER TABLE [dbo].[systemuserroles] ADD  CONSTRAINT [DF_systemuserroles_DefaultCompanyID]  DEFAULT ((0)) FOR [DefaultCompany]
GO
ALTER TABLE [dbo].[systemuserroles] ADD  CONSTRAINT [DF_systemuserroles_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[systemuserroles] ADD  CONSTRAINT [DF_systemuserroles_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[systemuserroles] ADD  DEFAULT ('') FOR [LastVersion]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_RegisterTime]  DEFAULT ((0)) FOR [RegisterTime]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_SalesAmountApprovalLimit]  DEFAULT ((0)) FOR [SalesAmountApprovalLimit]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_PurchaseAmountApprovalLimit]  DEFAULT ((0)) FOR [PurchaseAmountApprovalLimit]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_UnlimitedSalesApproval]  DEFAULT ((0)) FOR [UnlimitedSalesApproval]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_UnlimitedPurchaseApproval]  DEFAULT ((0)) FOR [UnlimitedPurchaseApproval]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_RequestAmountApprovalLimit]  DEFAULT ((0)) FOR [RequestAmountApprovalLimit]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_UnlimitedRequestApproval]  DEFAULT ((0)) FOR [UnlimitedRequestApproval]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_systemusers_Blocked]  DEFAULT ((0)) FOR [Blocked]
GO
ALTER TABLE [dbo].[systemusers] ADD  CONSTRAINT [DF_Users_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[TransferRoute] ADD  CONSTRAINT [DF_TransferRoute_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[TransferRoute] ADD  CONSTRAINT [DF_TransferRoute_CreatedBy]  DEFAULT ('System') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[TransferRoute] ADD  CONSTRAINT [DF_TransferRoute_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
/****** Object:  StoredProcedure [dbo].[spCompanyInformationEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spCompanyInformationEdit] 
	-- Add the parameters for the stored procedure here
    @CompanyCode varchar(20) = ''
    , @ParentCompanyCode varchar(20) = ''
    , @CompanyName varchar(50) = ''
    , @CompanyName2 varchar(50) = ''
    , @CompanyAddress varchar(80) = ''
    , @CompanyAddress2 varchar(80) = ''
    , @CompanyCity varchar(30) = ''
    , @CompanyPhoneNo varchar(30) = ''
    , @CompanyPhoneNo2 varchar(30) = ''
    , @CompanyFaxNo varchar(30) = ''
    , @GiroNo varchar(20) = ''
    , @BankName varchar(50) = ''
    , @BankBranchNo varchar(50) = ''
    , @BankAccountNo varchar(30) = ''
    , @BankAccountName varchar(50) = ''
    , @BankAddress varchar(80) = ''
    , @PaymentRoutingNo varchar(20) = ''
    , @CustomsPermitNo varchar(20) = ''
    , @CustomsPermitDate datetime = ''
    , @VATRegistrationNo varchar(20) = ''
    , @RegistrationNo varchar(20) = ''
    , @ShiptoName varchar(50) = ''
    , @ShiptoName2 varchar(50) = ''
    , @ShiptoAddress varchar(50) = ''
    , @ShiptoAddress2 varchar(50) = ''
    , @ShiptoCity varchar(30) = ''
    , @ShiptoContact varchar(50) = ''
    , @LocationCode varchar(10) = ''
    , @ImageFolderName varchar(100) = ''
    , @PostCode varchar(20) = ''
    , @ShiptoPostCode varchar(20) = ''
    , @EMail varchar(80) = ''
    , @HomePage varchar(80) = ''
    , @CountryRegionCode varchar(10) = ''
    , @ShiptoCountryRegionCode varchar(10) = ''
    , @IBAN varchar(50) = ''
    , @SWIFTCode varchar(20) = ''
    , @IndustrialClassification varchar(30) = ''
    , @AbbreviatedName varchar(4) = ''
    , @ShowAbbreviatedName tinyint = 0
    , @SystemIndicator int = 0
    , @CustomSystemIndicatorText varchar(250) = ''
    , @SystemIndicatorStyle int = 0
    , @ResponsibilityCenter varchar(10) = ''
    , @CheckAvailPeriodCalc varchar(32) = ''
    , @CheckAvailTimeBucket int = 0
    , @BaseCalendarCode varchar(10) = ''
    , @CalConvergenceTimeFrame varchar(32) = ''
    , @ABN varchar(11) = ''
    , @TaxPeriod int = 0
    , @ABNDivisionPartNo varchar(3) = ''
    , @IRDNo varchar(30) = ''
    , @RDOCode varchar(3) = ''
    , @VATRegistrationDate datetime = ''
    , @SignInvoiceName varchar(50) = ''
    , @SignInvoiceDept varchar(50) = ''
    , @APPVersion varchar(50) = ''
    , @FileFolder varchar(250) = ''
    , @LoginImageName varchar(50) = ''
    , @LogoFileName varchar(50) = ''
    , @WallFileName varchar(50) = ''
    , @SecurityCheck varchar(50) = ''
    , @RowStatus smallint 
    , @CreatedBy varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@CompanyCode = '')
	BEGIN
		INSERT INTO [dbo].[CompanyInformation]
			   ([CompanyCode]
			   ,[ParentCompanyCode]
			   ,[CompanyName]
			   ,[CompanyName2]
			   ,[CompanyAddress]
			   ,[CompanyAddress2]
			   ,[CompanyCity]
			   ,[CompanyPhoneNo]
			   ,[CompanyPhoneNo2]
			   ,[CompanyFaxNo]
			   ,[GiroNo]
			   ,[BankName]
			   ,[BankBranchNo]
			   ,[BankAccountNo]
			   ,[BankAccountName]
			   ,[BankAddress]
			   ,[PaymentRoutingNo]
			   ,[CustomsPermitNo]
			   ,[CustomsPermitDate]
			   ,[VATRegistrationNo]
			   ,[RegistrationNo]
			   ,[ShiptoName]
			   ,[ShiptoName2]
			   ,[ShiptoAddress]
			   ,[ShiptoAddress2]
			   ,[ShiptoCity]
			   ,[ShiptoContact]
			   ,[LocationCode]
			   ,[ImageFolderName]
			   ,[PostCode]
			   ,[ShiptoPostCode]
			   ,[EMail]
			   ,[HomePage]
			   ,[CountryRegionCode]
			   ,[ShiptoCountryRegionCode]
			   ,[IBAN]
			   ,[SWIFTCode]
			   ,[IndustrialClassification]
			   ,[AbbreviatedName]
			   ,[ShowAbbreviatedName]
			   ,[SystemIndicator]
			   ,[CustomSystemIndicatorText]
			   ,[SystemIndicatorStyle]
			   ,[ResponsibilityCenter]
			   ,[CheckAvailPeriodCalc]
			   ,[CheckAvailTimeBucket]
			   ,[BaseCalendarCode]
			   ,[CalConvergenceTimeFrame]
			   ,[ABN]
			   ,[TaxPeriod]
			   ,[ABNDivisionPartNo]
			   ,[IRDNo]
			   ,[RDOCode]
			   ,[VATRegistrationDate]
			   ,[SignInvoiceName]
			   ,[SignInvoiceDept]
			   ,[APPVersion]
			   ,[FileFolder]
			   ,[LoginImageName]
			   ,[LogoFileName]
			   ,[WallFileName]
			   ,[SecurityCheck]
			   ,[RowStatus]
			   ,[CreatedBy]
			   ,[CreatedTime])
		 VALUES
			   ( @CompanyCode
			   , @ParentCompanyCode
			   , @CompanyName
			   , @CompanyName2
			   , @CompanyAddress
			   , @CompanyAddress2
			   , @CompanyCity
			   , @CompanyPhoneNo
			   , @CompanyPhoneNo2
			   , @CompanyFaxNo
			   , @GiroNo
			   , @BankName
			   , @BankBranchNo
			   , @BankAccountNo
			   , @BankAccountName
			   , @BankAddress
			   , @PaymentRoutingNo
			   , @CustomsPermitNo
			   , @CustomsPermitDate
			   , @VATRegistrationNo
			   , @RegistrationNo
			   , @ShiptoName
			   , @ShiptoName2
			   , @ShiptoAddress
			   , @ShiptoAddress2
			   , @ShiptoCity
			   , @ShiptoContact
			   , @LocationCode
			   , @ImageFolderName
			   , @PostCode
			   , @ShiptoPostCode
			   , @EMail
			   , @HomePage
			   , @CountryRegionCode
			   , @ShiptoCountryRegionCode
			   , @IBAN
			   , @SWIFTCode
			   , @IndustrialClassification
			   , @AbbreviatedName
			   , @ShowAbbreviatedName
			   , @SystemIndicator
			   , @CustomSystemIndicatorText
			   , @SystemIndicatorStyle
			   , @ResponsibilityCenter
			   , @CheckAvailPeriodCalc
			   , @CheckAvailTimeBucket
			   , @BaseCalendarCode
			   , @CalConvergenceTimeFrame
			   , @ABN
			   , @TaxPeriod
			   , @ABNDivisionPartNo
			   , @IRDNo
			   , @RDOCode
			   , @VATRegistrationDate
			   , @SignInvoiceName
			   , @SignInvoiceDept
			   , @APPVersion
			   , @FileFolder
			   , @LoginImageName
			   , @LogoFileName
			   , @WallFileName
			   , @SecurityCheck
			   , @RowStatus 
			   , @CreatedBy
			   , GETDATE())
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CompanyInformation]
		   SET [CompanyCode] = @CompanyCode
			  ,[ParentCompanyCode] = @ParentCompanyCode
			  ,[CompanyName] = @CompanyName
			  ,[CompanyName2] = @CompanyName2
			  ,[CompanyAddress] = @CompanyAddress
			  ,[CompanyAddress2] = @CompanyAddress2
			  ,[CompanyCity] = @CompanyCity
			  ,[CompanyPhoneNo] = @CompanyPhoneNo
			  ,[CompanyPhoneNo2] = @CompanyPhoneNo2
			  ,[CompanyFaxNo] = @CompanyFaxNo
			  ,[GiroNo] = @GiroNo
			  ,[BankName] = @BankName
			  ,[BankBranchNo] = @BankBranchNo
			  ,[BankAccountNo] = @BankAccountNo
			  ,[BankAccountName] = @BankAccountName
			  ,[BankAddress] = @BankAddress
			  ,[PaymentRoutingNo] = @PaymentRoutingNo
			  ,[CustomsPermitNo] = @CustomsPermitNo
			  ,[CustomsPermitDate] = @CustomsPermitDate
			  ,[VATRegistrationNo] = @VATRegistrationNo
			  ,[RegistrationNo] = @RegistrationNo
			  ,[ShiptoName] = @ShiptoName
			  ,[ShiptoName2] = @ShiptoName2
			  ,[ShiptoAddress] = @ShiptoAddress
			  ,[ShiptoAddress2] = @ShiptoAddress2
			  ,[ShiptoCity] = @ShiptoCity
			  ,[ShiptoContact] = @ShiptoContact
			  ,[LocationCode] = @LocationCode
			  , ImageFolderName = @ImageFolderName
			  ,[PostCode] = @PostCode
			  ,[ShiptoPostCode] = @ShiptoPostCode
			  ,[EMail] = @EMail
			  ,[HomePage] = @HomePage
			  ,[CountryRegionCode] = @CountryRegionCode
			  ,[ShiptoCountryRegionCode] = @ShiptoCountryRegionCode
			  ,[IBAN] = @IBAN
			  ,[SWIFTCode] = @SWIFTCode
			  ,[IndustrialClassification] = @IndustrialClassification
			  ,[AbbreviatedName] = @AbbreviatedName
			  ,[ShowAbbreviatedName] = @ShowAbbreviatedName
			  ,[SystemIndicator] = @SystemIndicator
			  ,[CustomSystemIndicatorText] = @CustomSystemIndicatorText
			  ,[SystemIndicatorStyle] = @SystemIndicatorStyle
			  ,[ResponsibilityCenter] = @ResponsibilityCenter
			  ,[CheckAvailPeriodCalc] = @CheckAvailPeriodCalc
			  ,[CheckAvailTimeBucket] = @CheckAvailTimeBucket
			  ,[BaseCalendarCode] = @BaseCalendarCode
			  ,[CalConvergenceTimeFrame] = @CalConvergenceTimeFrame
			  ,[ABN] = @ABN
			  ,[TaxPeriod] = @TaxPeriod
			  ,[ABNDivisionPartNo] = @ABNDivisionPartNo
			  ,[IRDNo] = @IRDNo
			  ,[RDOCode] = @RDOCode
			  ,[VATRegistrationDate] = @VATRegistrationDate
			  ,[SignInvoiceName] = @SignInvoiceName
			  ,[SignInvoiceDept] = @SignInvoiceDept
			  ,[APPVersion] = @APPVersion
			  ,[FileFolder] = @FileFolder
			   , [LoginImageName]= @LoginImageName
			   , [LogoFileName] = @LogoFileName
			   , [WallFileName] = @WallFileName
			   ,[SecurityCheck] = @SecurityCheck
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GETDATE()
		WHERE CompanyCode = @CompanyCode

	END
	
	SELECT @CompanyCode as CompanyCode
END
GO
/****** Object:  StoredProcedure [dbo].[spCountryRegionEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCountryRegionEdit] 
	-- Add the parameters for the stored procedure here
	@CountryRegionID int = 0
    , @Code varchar(10) 
    , @Name varchar(50) 
    , @EUCountryRegionCode varchar(10) = ''
    , @IntrastatCode varchar(10) = ''
    , @AddressFormat int = 0
    , @ContactAddressFormat int = 0
    , @RowStatus smallint 
    , @CreatedBy varchar(50) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @CountryRegionID > 0
	BEGIN
		UPDATE [dbo].[CountryRegion]
		   SET [Code] = @Code 
			  ,[Name] = @Name 
			  ,[EUCountryRegionCode] = @EUCountryRegionCode 
			  ,[IntrastatCode] = @IntrastatCode 
			  ,[AddressFormat] = @AddressFormat 
			  ,[ContactAddressFormat] = @ContactAddressFormat 
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy 
			  ,[LastModifiedTime] = GetDate()
		Where CountryRegionID = @CountryRegionID
		
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[CountryRegion]
           ([Code]
           ,[Name]
           ,[EUCountryRegionCode]
           ,[IntrastatCode]
           ,[AddressFormat]
           ,[ContactAddressFormat]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime] )
		VALUES
           (@Code 
           ,@Name 
           ,@EUCountryRegionCode 
           ,@IntrastatCode 
           ,@AddressFormat 
           ,@ContactAddressFormat 
           ,@RowStatus 
           ,@CreatedBy 
           ,GETDATE())
           
        SELECT @CountryRegionID = @@IDENTITY 
	END
	
	Select @CountryRegionID
END
GO
/****** Object:  StoredProcedure [dbo].[spEmployeeEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spEmployeeEdit] 
	-- Add the parameters for the stored procedure here
	@EmployeeID int = 0
	, @No varchar(20) = ''
	, @FirstName varchar(30) = ''
	, @MiddleName varchar(30) = ''
	, @LastName varchar(30) = ''
	, @Initials varchar(30) = ''
	, @JobTitle varchar(30) = ''
	, @Address varchar(50) = ''
	, @Address2 varchar(50) = ''
	, @City varchar(30) = ''
	, @PostCode varchar(20) = ''
	, @BloodType varchar(2) = ''
	, @PhoneNo varchar(30) = ''
	, @MobilePhoneNo varchar(30) = ''
	, @EMail varchar(80) = ''
	, @ReligionCode varchar(20) = ''
	, @JamsostekNo varchar(20) = ''
	, @BPJSKesehatanNo varchar(20) = ''
	, @FilePicture varchar(80) = ''
	, @BirthDate datetime = ''
	, @SocialSecurityNo varchar(30) = ''
	, @TaxCode varchar(30) = ''
	, @PlaceofBirth varchar(30) = ''
	, @MaritalStatus varchar(30) = ''
	, @TaxStatusCode varchar(30) = ''
	, @BankAccountNo varchar(30) = ''
	, @BankAccountName varchar(30) = ''
	, @Gender int = 0
	, @Country varchar(10) = ''
	, @ManagerNo varchar(20) = ''
	, @EmplymtContractCode varchar(10) = ''
	, @StatisticsGroupCode varchar(10) = ''
	, @EmployeePostingGroup varchar(20) = ''
	, @EmploymentDate datetime = ''
	, @Status int = 0
	, @InactiveDate datetime = ''
	, @CauseofInactivityCode varchar(10) = ''
	, @TerminationDate datetime = ''
	, @GroundsforTermCode varchar(10) = ''
	, @GlobalDimension1Code varchar(20) = ''
	, @GlobalDimension2Code varchar(20) = ''
	, @ResourceNo varchar(20) = ''
	, @FaxNo varchar(30) = ''
	, @CompanyEmail varchar(80) = ''
	, @Title varchar(30) = ''
	, @SalespersPurchCode varchar(10) = ''
	, @NoSeries varchar(10) = ''
	, @RowStatus smallint 
	, @CreatedBy varchar(50)  

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @EmployeeID > 0 
	BEGIN
		UPDATE [dbo].[Employee]
		   SET [No] = @No
			  ,[FirstName] = @FirstName
			  ,[MiddleName] = @MiddleName
			  ,[LastName] = @LastName
			  ,[Initials] = @Initials
			  ,[JobTitle] = @JobTitle
			  ,[Address] = @Address
			  ,[Address2] = @Address2
			  ,[City] = @City
			  ,[PostCode] = @PostCode
			  ,[BloodType] = @BloodType
			  ,[PhoneNo] = @PhoneNo
			  ,[MobilePhoneNo] = @MobilePhoneNo
			  ,[EMail] = @EMail
			  ,[ReligionCode] = @ReligionCode
			  ,[JamsostekNo] = @JamsostekNo
			  ,[BPJSKesehatanNo] = @BPJSKesehatanNo
			  ,[FilePicture] = @FilePicture
			  ,[BirthDate] = @BirthDate
			  ,[SocialSecurityNo] = @SocialSecurityNo
			  ,[TaxCode] = @TaxCode
			  ,[PlaceofBirth] = @PlaceofBirth
			  ,[MaritalStatus] = @MaritalStatus
			  ,[TaxStatusCode] = @TaxStatusCode
			  ,[BankAccountNo] = @BankAccountNo
			  ,[BankAccountName] = @BankAccountName
			  ,[Gender] = @Gender
			  ,[Country] = @Country
			  ,[ManagerNo] = @ManagerNo
			  ,[EmplymtContractCode] = @EmplymtContractCode
			  ,[StatisticsGroupCode] = @StatisticsGroupCode
			  ,[EmployeePostingGroup] = @EmployeePostingGroup
			  ,[EmploymentDate] = @EmploymentDate
			  ,[Status] = @Status
			  ,[InactiveDate] = @InactiveDate
			  ,[CauseofInactivityCode] = @CauseofInactivityCode
			  ,[TerminationDate] = @TerminationDate
			  ,[GroundsforTermCode] = @GroundsforTermCode
			  ,[GlobalDimension1Code] = @GlobalDimension1Code
			  ,[GlobalDimension2Code] = @GlobalDimension2Code
			  ,[ResourceNo] = @ResourceNo
			  ,[FaxNo] = @FaxNo
			  ,[CompanyEmail] = @CompanyEmail
			  ,[Title] = @Title
			  ,[SalespersPurchCode] = @SalespersPurchCode
			  ,[NoSeries] = @NoSeries
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GetDate()

		WHERE EmployeeID = @EmployeeID

	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Employee]
           ([No]
           ,[FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Initials]
           ,[JobTitle]
           ,[Address]
           ,[Address2]
           ,[City]
           ,[PostCode]
           ,[BloodType]
           ,[PhoneNo]
           ,[MobilePhoneNo]
           ,[EMail]
           ,[ReligionCode]
           ,[JamsostekNo]
           ,[BPJSKesehatanNo]
           ,[FilePicture]
           ,[BirthDate]
           ,[SocialSecurityNo]
           ,[TaxCode]
           ,[PlaceofBirth]
		   ,[MaritalStatus]  
		   ,[TaxStatusCode]  
		   ,[BankAccountNo]  
		   ,[BankAccountName]  
           ,[Gender]
           ,[Country]
           ,[ManagerNo]
           ,[EmplymtContractCode]
           ,[StatisticsGroupCode]
           ,[EmployeePostingGroup]
           ,[EmploymentDate]
           ,[Status]
           ,[InactiveDate]
           ,[CauseofInactivityCode]
           ,[TerminationDate]
           ,[GroundsforTermCode]
           ,[GlobalDimension1Code]
           ,[GlobalDimension2Code]
           ,[ResourceNo]
           ,[FaxNo]
           ,[CompanyEmail]
           ,[Title]
           ,[SalespersPurchCode]
           ,[NoSeries]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
     VALUES
           ( @No
           , @FirstName
           , @MiddleName
           , @LastName
           , @Initials
           , @JobTitle
           , @Address
           , @Address2
           , @City
           , @PostCode
           , @BloodType
           , @PhoneNo
           , @MobilePhoneNo
           , @EMail
           , @ReligionCode
           , @JamsostekNo
           , @BPJSKesehatanNo
           , @FilePicture
           , @BirthDate
           , @SocialSecurityNo
           , @TaxCode
           , @PlaceofBirth
           , @MaritalStatus 
           , @TaxStatusCode 
           , @BankAccountNo 
           , @BankAccountName 
           , @Gender
           , @Country
           , @ManagerNo
           , @EmplymtContractCode
           , @StatisticsGroupCode
           , @EmployeePostingGroup
           , @EmploymentDate
           , @Status
           , @InactiveDate
           , @CauseofInactivityCode
           , @TerminationDate
           , @GroundsforTermCode
           , @GlobalDimension1Code
           , @GlobalDimension2Code
           , @ResourceNo
           , @FaxNo
           , @CompanyEmail
           , @Title
           , @SalespersPurchCode
           , @NoSeries
           , @RowStatus 
           , @CreatedBy
           , GetDate())
		   
		   SET @EmployeeID = @@IDENTITY
	END

	SELECT @EmployeeID

END
GO
/****** Object:  StoredProcedure [dbo].[spLocationsEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spLocationsEdit] 
	-- Add the parameters for the stored procedure here
	@LocationID int = 0
    , @LocationCode varchar(10) = ''
    , @LocationName varchar(30) = ''
    , @Name2 varchar(30) = ''
    , @Address varchar(50) = ''
    , @Address2 varchar(50) = ''
    , @City varchar(30) = ''
    , @PhoneNo varchar(30) = ''
    , @PhoneNo2 varchar(30) = ''
    , @FaxNo varchar(30) = ''
    , @Contact varchar(50) = ''
    , @PostCode varchar(20) = ''
    , @EMail varchar(80) = ''
    , @HomePage varchar(90) = ''
    , @CountryRegionCode varchar(10) = ''
    , @UseAsInTransit tinyint = 0
    , @RequirePutaway tinyint = 0
    , @RequirePick tinyint = 0
    , @CrossDockDueDateCalc varchar(32) = ''
    , @UseCrossDocking tinyint = 0
    , @RequireReceive tinyint = 0
    , @RequireShipment tinyint = 0
    , @BinMandatory tinyint = 0
    , @DirectedPutawayandPick tinyint = 0
    , @DefaultBinSelection int = 0
    , @OutboundWhseHandlingTime varchar(32) = ''
    , @InboundWhseHandlingTime varchar(32) = ''
    , @PutawayTemplateCode varchar(10) = ''
    , @UsePutawayWorksheet tinyint = 0
    , @PickAccordingtoFEFO tinyint = 0
    , @AllowBreakbulk tinyint = 0
    , @BinCapacityPolicy int = 0
    , @OpenShopFloorBinCode varchar(20) = ''
    , @InboundProductionBinCode varchar(20) = ''
    , @OutboundProductionBinCode varchar(20) = ''
    , @AdjustmentBinCode varchar(20) = ''
    , @AlwaysCreatePutawayLine tinyint = 0
    , @AlwaysCreatePickLine tinyint = 0
    , @SpecialEquipment int = 0
    , @ReceiptBinCode varchar(20) = ''
    , @ShipmentBinCode varchar(20) = ''
    , @CrossDockBinCode varchar(20) = ''
    , @OutboundBOMBinCode varchar(20) = ''
    , @InboundBOMBinCode varchar(20) = ''
    , @BaseCalendarCode varchar(10) = ''
    , @UseADCS tinyint = 0
    , @RowStatus smallint 
    , @CreatedBy varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @LocationID = 0
	BEGIN
		INSERT INTO [dbo].[Locations]
           ([LocationCode]
           ,[LocationName]
           ,[Name2]
           ,[Address]
           ,[Address2]
           ,[City]
           ,[PhoneNo]
           ,[PhoneNo2]
           ,[FaxNo]
           ,[Contact]
           ,[PostCode]
           ,[EMail]
           ,[HomePage]
           ,[CountryRegionCode]
           ,[UseAsInTransit]
           ,[RequirePutaway]
           ,[RequirePick]
           ,[CrossDockDueDateCalc]
           ,[UseCrossDocking]
           ,[RequireReceive]
           ,[RequireShipment]
           ,[BinMandatory]
           ,[DirectedPutawayandPick]
           ,[DefaultBinSelection]
           ,[OutboundWhseHandlingTime]
           ,[InboundWhseHandlingTime]
           ,[PutawayTemplateCode]
           ,[UsePutawayWorksheet]
           ,[PickAccordingtoFEFO]
           ,[AllowBreakbulk]
           ,[BinCapacityPolicy]
           ,[OpenShopFloorBinCode]
           ,[InboundProductionBinCode]
           ,[OutboundProductionBinCode]
           ,[AdjustmentBinCode]
           ,[AlwaysCreatePutawayLine]
           ,[AlwaysCreatePickLine]
           ,[SpecialEquipment]
           ,[ReceiptBinCode]
           ,[ShipmentBinCode]
           ,[CrossDockBinCode]
           ,[OutboundBOMBinCode]
           ,[InboundBOMBinCode]
           ,[BaseCalendarCode]
           ,[UseADCS]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
     VALUES
           (@LocationCode
           ,@LocationName
           ,@Name2
           ,@Address
           ,@Address2
           ,@City
           ,@PhoneNo
           ,@PhoneNo2
           ,@FaxNo
           ,@Contact
           ,@PostCode
           ,@EMail
           ,@HomePage
           ,@CountryRegionCode
           ,@UseAsInTransit
           ,@RequirePutaway
           ,@RequirePick
           ,@CrossDockDueDateCalc
           ,@UseCrossDocking
           ,@RequireReceive
           ,@RequireShipment
           ,@BinMandatory
           ,@DirectedPutawayandPick
           ,@DefaultBinSelection
           ,@OutboundWhseHandlingTime
           ,@InboundWhseHandlingTime
           ,@PutawayTemplateCode
           ,@UsePutawayWorksheet
           ,@PickAccordingtoFEFO
           ,@AllowBreakbulk
           ,@BinCapacityPolicy
           ,@OpenShopFloorBinCode
           ,@InboundProductionBinCode
           ,@OutboundProductionBinCode
           ,@AdjustmentBinCode
           ,@AlwaysCreatePutawayLine
           ,@AlwaysCreatePickLine
           ,@SpecialEquipment
           ,@ReceiptBinCode
           ,@ShipmentBinCode
           ,@CrossDockBinCode
           ,@OutboundBOMBinCode
           ,@InboundBOMBinCode
           ,@BaseCalendarCode
           ,@UseADCS
           ,@RowStatus
           ,@CreatedBy
           ,GetDate())
           
		Set @LocationID = @@Identity
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Locations]
		   SET [LocationCode] = @LocationCode
			  ,[LocationName] = @LocationName
			  ,[Name2] = @Name2
			  ,[Address] = @Address
			  ,[Address2] = @Address2
			  ,[City] = @City
			  ,[PhoneNo] = @PhoneNo
			  ,[PhoneNo2] = @PhoneNo2
			  ,[FaxNo] = @FaxNo
			  ,[Contact] = @Contact
			  ,[PostCode] = @PostCode
			  ,[EMail] = @EMail
			  ,[HomePage] = @HomePage
			  ,[CountryRegionCode] = @CountryRegionCode
			  ,[UseAsInTransit] = @UseAsInTransit
			  ,[RequirePutaway] = @RequirePutaway
			  ,[RequirePick] = @RequirePick
			  ,[CrossDockDueDateCalc] = @CrossDockDueDateCalc
			  ,[UseCrossDocking] = @UseCrossDocking
			  ,[RequireReceive] = @RequireReceive
			  ,[RequireShipment] = @RequireShipment
			  ,[BinMandatory] = @BinMandatory
			  ,[DirectedPutawayandPick] = @DirectedPutawayandPick
			  ,[DefaultBinSelection] = @DefaultBinSelection
			  ,[OutboundWhseHandlingTime] = @OutboundWhseHandlingTime
			  ,[InboundWhseHandlingTime] = @InboundWhseHandlingTime
			  ,[PutawayTemplateCode] = @PutawayTemplateCode
			  ,[UsePutawayWorksheet] = @UsePutawayWorksheet
			  ,[PickAccordingtoFEFO] = @PickAccordingtoFEFO
			  ,[AllowBreakbulk] = @AllowBreakbulk
			  ,[BinCapacityPolicy] = @BinCapacityPolicy
			  ,[OpenShopFloorBinCode] = @OpenShopFloorBinCode
			  ,[InboundProductionBinCode] = @InboundProductionBinCode
			  ,[OutboundProductionBinCode] = @OutboundProductionBinCode
			  ,[AdjustmentBinCode] = @AdjustmentBinCode
			  ,[AlwaysCreatePutawayLine] = @AlwaysCreatePutawayLine
			  ,[AlwaysCreatePickLine] = @AlwaysCreatePickLine
			  ,[SpecialEquipment] = @SpecialEquipment
			  ,[ReceiptBinCode] = @ReceiptBinCode
			  ,[ShipmentBinCode] = @ShipmentBinCode
			  ,[CrossDockBinCode] = @CrossDockBinCode
			  ,[OutboundBOMBinCode] = @OutboundBOMBinCode
			  ,[InboundBOMBinCode] = @InboundBOMBinCode
			  ,[BaseCalendarCode] = @BaseCalendarCode
			  ,[UseADCS] = @UseADCS
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GetDate()
		Where LocationID = @LocationID
		
		Select @LocationID		
	END
	SELECT @LocationID 
END
GO
/****** Object:  StoredProcedure [dbo].[spNoSeriesLineEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spNoSeriesLineEdit] 
	-- Add the parameters for the stored procedure here
	@NoSeriesLineID int = 0
    , @NoSeriesCode varchar(10)  
    , @SeqLineNo int = 0
    , @StartingDate datetime = ''
    , @StartingNo varchar(20) = ''
    , @EndingNo varchar(20) = ''
    , @WarningNo varchar(20) = ''
    , @IncrementbyNo int = 0
    , @LastNoUsed varchar(20) = ''
    , @isOpen tinyint = 0
    , @LastDateUsed datetime = ''
    , @RowStatus smallint = 0
    , @CreatedBy varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @NoSeriesLineID = 0 
	BEGIN
		INSERT INTO [dbo].[NoSeriesLine]
			   ([NoSeriesCode]
			   ,[SeqLineNo]
			   ,[StartingDate]
			   ,[StartingNo]
			   ,[EndingNo]
			   ,[WarningNo]
			   ,[IncrementbyNo]
			   ,[LastNoUsed]
			   ,[isOpen]
			   ,[LastDateUsed]
			   ,[RowStatus]
			   ,[CreatedBy]
			   ,[CreatedTime])
		 VALUES
			   ( @NoSeriesCode 
			   , @SeqLineNo 
			   , @StartingDate 
			   , @StartingNo 
			   , @EndingNo 
			   , @WarningNo 
			   , @IncrementbyNo 
			   , @LastNoUsed 
			   , @isOpen 
			   , @LastDateUsed 
			   , @RowStatus 
			   , @CreatedBy 
			   , GetDate()) 
		Set @NoSeriesLineID = @@Identity
	END
	ELSE
	BEGIn
		UPDATE [dbo].[NoSeriesLine]
		   SET [NoSeriesCode]  = @NoSeriesCode 
			  ,[SeqLineNo] = @SeqLineNo 
			  ,[StartingDate] = @StartingDate 
			  ,[StartingNo] = @StartingNo 
			  ,[EndingNo] = @EndingNo 
			  ,[WarningNo] = @WarningNo 
			  ,[IncrementbyNo] = @IncrementbyNo 
			  ,[LastNoUsed] = @LastNoUsed 
			  ,[isOpen] = @isOpen 
			  ,[LastDateUsed] = @LastDateUsed 
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GetDate()
		 WHERE NoSeriesLineID = @NoSeriesLineID
	END
	Select @NoSeriesLineID
END
GO
/****** Object:  StoredProcedure [dbo].[spSystemObjectEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSystemObjectEdit] 
	-- Add the parameters for the stored procedure here
	 
	 @SystemObjectID varchar(10) = ''
	 ,@ObjectType varchar(20) = ''
	 ,@ObjectDesc varchar(50) = ''
	 ,@ObjectSystemName varchar(50) = ''
	 ,@ObjectSystemArg varchar(50) = ''
	 ,@ObjectSystemImageFileName varchar(50) = ''
	 ,@urlObjectName varchar(150) = ''
	 ,@ObjectSeqNo tinyint = 0
	 ,@RowStatus smallint = 0
	 ,@CreatedBy varchar(50) = ''



					 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	IF EXISTS (SELECT * FROM systemobject WHERE SystemObjectID = @SystemObjectID)
	BEGIN
	UPDATE [dbo].[systemobject]
		   SET [ObjectType] = @ObjectType 
           ,[ObjectDesc] = @ObjectDesc 
           ,[ObjectSystemName] = @ObjectSystemName 
           ,[ObjectSystemArg] = @ObjectSystemArg 
           ,[ObjectSystemImageFileName] = @ObjectSystemImageFileName 
           ,[urlObjectName] = @urlObjectName 
           ,[ObjectSeqNo] = @ObjectSeqNo 
           ,[RowStatus] = @RowStatus
           ,[LastModifiedBy] = @CreatedBy 
           ,[LastModifiedTime] = GetDate()
					 
		WHERE SystemObjectID = @SystemObjectID
				 	 
	
	END
	
	ELSE
	BEGIN
	INSERT INTO [dbo].[systemobject]
           ([SystemObjectID]
           ,[ObjectType]
           ,[ObjectDesc]
           ,[ObjectSystemName]
           ,[ObjectSystemArg]
           ,[ObjectSystemImageFileName]
           ,[urlObjectName]
           ,[ObjectSeqNo]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
		VALUES
           ( @SystemObjectID 
						 ,@ObjectType 
						 ,@ObjectDesc 
						 ,@ObjectSystemName 
						 ,@ObjectSystemArg 
						 ,@ObjectSystemImageFileName 
						 ,@urlObjectName 
						 ,@ObjectSeqNo 
						 ,@RowStatus
						 ,@CreatedBy 
					 ,GetDate())	
		
		
	END
	Select @SystemObjectID
END
GO
/****** Object:  StoredProcedure [dbo].[spSystemPermissionEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSystemPermissionEdit] 
	-- Add the parameters for the stored procedure here
	 @SystemPermissionID int = 0
	 ,@CompanyCode varchar(20) = ''
	 ,@Role varchar(20) = '' 
	 ,@ObjectID varchar(10) = ''
	 ,@ReadData smallint = 0
	 ,@InsertData smallint = 0
	 ,@ModifyData smallint = 0
	 ,@DeleteData smallint = 0
	 ,@ExecuteData smallint = 0
	 ,@ValueData smallint = 0
	 ,@RowStatus smallint = 0
	 ,@CreatedBy varchar(50) = ''
 


					 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@SystemPermissionID = 0)
	BEGIN
		INSERT INTO [dbo].[systempermission]
           ([CompanyCode]
           ,[RoleID]
           ,[ObjectID]
           ,[ReadData]
           ,[InsertData]
           ,[ModifyData]
           ,[DeleteData]
           ,[ExecuteData]
           ,[ValueData]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
		VALUES
           ( @CompanyCode
						 ,@Role 
						 ,@ObjectID
						 ,@ReadData 
						 ,@InsertData 
						 ,@ModifyData 
						 ,@DeleteData 
						 ,@ExecuteData 
						 ,@ValueData 
						 ,@RowStatus 
						 ,@CreatedBy 
							,GetDate())		
					 
		Set @SystemPermissionID = @@Identity			 
	
	END
	ELSE
	BEGIN
		UPDATE [dbo].[systempermission]
		   SET [CompanyCode] = @CompanyCode
           ,[RoleID] = @Role 
           ,[ObjectID] = @ObjectID
           ,[ReadData] = @ReadData 
           ,[InsertData] = @InsertData 
           ,[ModifyData] = @ModifyData 
           ,[DeleteData] = @DeleteData 
           ,[ExecuteData] = @ExecuteData 
           ,[ValueData] = @ValueData 
           ,[RowStatus] = @RowStatus 
           ,[LastModifiedBy] = @CreatedBy 
           ,[LastModifiedTime] = GetDate()
					 
		WHERE SystemPermissionID = @SystemPermissionID
	END
	Select @SystemPermissionID
END
GO
/****** Object:  StoredProcedure [dbo].[spSystemRolesEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSystemRolesEdit] 
	-- Add the parameters for the stored procedure here
	@SystemRolesID int = 0
		,@Role varchar(20) = ''
	 ,@Descriptions varchar(50) = ''
	 ,@RowStatus smallint = 0
	 ,@CreatedBy varchar(50) = ''

					 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@SystemRolesID = 0)
	BEGIN
		INSERT INTO [dbo].[systemroles]
           ([Role]
           ,[Descriptions]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
		VALUES
           ( @Role
           ,@Descriptions 
					 ,@RowStatus 
					 ,@CreatedBy 
					 ,GetDate())			 	 

		Set @SystemRolesID = @@Identity
	END
	ELSE
	BEGIN
		UPDATE [dbo].[systemroles]
		   SET [Role] =  @Role
           ,[Descriptions] = @Descriptions 
           ,[RowStatus] = @RowStatus 
           ,[LastModifiedBy] = @CreatedBy 
           ,[LastModifiedTime] = GetDate()
					 
		WHERE SystemRolesID = @SystemRolesID
	END
	Select @SystemRolesID
END
GO
/****** Object:  StoredProcedure [dbo].[spSystemUserMenuEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSystemUserMenuEdit] 
	-- Add the parameters for the stored procedure here
	@SystemUserMenuID int = 0
	,@CompanyCode varchar(20) = ''
	 ,@RoleID varchar(20) = ''
	 ,@ParentID varchar(10) = ''
	 ,@ChildID varchar(10) = ''
	 ,@SeqNo int = 0
	 ,@RowStatus smallint = 0
	 ,@CreatedBy varchar(50) = ''
	 ,@CreatedTime datetime = ''
	 ,@LastModifiedBy varchar(50) = ''
	 ,@LastModifiedTime datetime = ''
 
					 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@SystemUserMenuID = 0)
	BEGIN
		INSERT INTO [dbo].[systemusermenu]
           ([CompanyCode]
           ,[RoleID]
           ,[ParentID]
           ,[ChildID]
           ,[SeqNo]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
		VALUES
           ( @CompanyCode
					 ,@RoleID
					 ,@ParentID
					 ,@ChildID 
					 ,@SeqNo 
					 ,@RowStatus
           ,@CreatedBy
					 ,GetDate())			 	 

		Set @SystemUserMenuID = @@Identity
	END
	ELSE
	BEGIN
		UPDATE [dbo].[systemusermenu]
		   SET [CompanyCode] = @CompanyCode
           ,[RoleID] = @RoleID
           ,[ParentID] = @ParentID
           ,[ChildID] = @ChildID 
           ,[SeqNo] = @SeqNo 
           ,[RowStatus] = @RowStatus
           ,[LastModifiedBy] = @CreatedBy
           ,[LastModifiedTime] = GetDate()
					 
		WHERE SystemUserMenuID = @SystemUserMenuID
	END
	Select @SystemUserMenuID
END
GO
/****** Object:  StoredProcedure [dbo].[spSystemUserRolesEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSystemUserRolesEdit] 
	-- Add the parameters for the stored procedure here
	@SystemUserRolesID int = 0
	,@UserCode varchar(10)  = ''
	,@CompanyCode varchar(20) = ''
	,@RoleID varchar(20) = ''
	,@DefaultCompany tinyint = 0
	,@RowStatus smallint = 0
	,@CreatedBy varchar(50) = ''
	,@LastVersion varchar(20) = ''
					 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@SystemUserRolesID = 0)
	BEGIN
		INSERT INTO [dbo].[systemuserroles]
           ([UserCode]
           ,[CompanyCode]
           ,[RoleID]
           ,[DefaultCompany]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime]
		   ,[LastVersion])
		VALUES
           ( @UserCode
           ,@CompanyCode
           ,@RoleID
           ,@DefaultCompany
           ,@RowStatus
           ,@CreatedBy
		   ,GetDate()
		   ,@LastVersion)			 	 

		Set @SystemUserRolesID = @@Identity
	END
	ELSE
	BEGIN
		UPDATE [dbo].[systemuserroles]
		   SET [UserCode] = @UserCode
           ,[CompanyCode] = @CompanyCode
           ,[RoleID] = @RoleID
           ,[DefaultCompany] = @DefaultCompany
           ,[RowStatus] = @RowStatus
		   ,[LastModifiedBy] = @CreatedBy
           ,[LastModifiedTime] = GetDate()
		   ,[LastVersion] = @LastVersion
					 
		WHERE SystemUserRolesID = @SystemUserRolesID
	END
	Select @SystemUserRolesID
END
GO
/****** Object:  StoredProcedure [dbo].[spSystemUsersEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spSystemUsersEdit] 
	-- Add the parameters for the stored procedure here
	@SystemUsersID int = 0
    , @UserCode varchar(10)
    , @UserName varchar(50) = ''
    , @UserPassword varchar(50) = ''
    , @AllowPostingFrom datetime = ''
    , @AllowPostingTo datetime = ''
    , @RegisterTime tinyint = 0
    , @SalespersPurchCode varchar(10) = ''
    , @ApproverID varchar(20) = ''
    , @SalesAmountApprovalLimit int = 0
    , @PurchaseAmountApprovalLimit int = 0
    , @UnlimitedSalesApproval tinyint = 0
    , @UnlimitedPurchaseApproval tinyint = 0
    , @Substitute varchar(20) = ''
    , @EMailAddress varchar(100) = ''
    , @RequestAmountApprovalLimit int = 0
    , @UnlimitedRequestApproval tinyint = 0
    , @AllowFAPostingFrom datetime = ''
    , @AllowFAPostingTo datetime = ''
    , @SalesRespCtrFilter varchar(10) = ''
    , @PurchaseRespCtrFilter varchar(10) = ''
    , @ServiceRespCtr_Filter varchar(10) = ''
    , @DepartmentCode varchar(20) = ''
    , @LocationCode varchar(20) = ''
    , @RowStatus smallint = 0
    , @CreatedBy varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@SystemUsersID = 0)
	BEGIN
		INSERT INTO [dbo].[systemusers]
           ([UserCode]
           ,[UserName]
           ,[UserPassword]
           ,[AllowPostingFrom]
           ,[AllowPostingTo]
           ,[RegisterTime]
           ,[SalespersPurchCode]
           ,[ApproverID]
           ,[SalesAmountApprovalLimit]
           ,[PurchaseAmountApprovalLimit]
           ,[UnlimitedSalesApproval]
           ,[UnlimitedPurchaseApproval]
           ,[Substitute]
           ,[EMailAddress]
           ,[RequestAmountApprovalLimit]
           ,[UnlimitedRequestApproval]
           ,[AllowFAPostingFrom]
           ,[AllowFAPostingTo]
           ,[SalesRespCtrFilter]
           ,[PurchaseRespCtrFilter]
           ,[ServiceRespCtr_Filter]
           ,[DepartmentCode]
           ,[LocationCode]
           ,[RowStatus]
           ,[CreatedBy]
           ,[CreatedTime])
		VALUES
           ( @UserCode
           , @UserName
           , @UserPassword
           , @AllowPostingFrom
           , @AllowPostingTo
           , @RegisterTime
           , @SalespersPurchCode
           , @ApproverID
           , @SalesAmountApprovalLimit
           , @PurchaseAmountApprovalLimit
           , @UnlimitedSalesApproval
           , @UnlimitedPurchaseApproval
           , @Substitute
           , @EMailAddress
           , @RequestAmountApprovalLimit
           , @UnlimitedRequestApproval
           , @AllowFAPostingFrom
           , @AllowFAPostingTo
           , @SalesRespCtrFilter
           , @PurchaseRespCtrFilter
           , @ServiceRespCtr_Filter
           , @DepartmentCode
           , @LocationCode
           , @RowStatus 
           , @CreatedBy
           ,GetDate())

		Set @SystemUsersID = @@Identity
	END
	ELSE
	BEGIN
		UPDATE [dbo].[systemusers]
		   SET [UserCode] = @UserCode
			  ,[UserName] = @UserName
			  ,[UserPassword] = @UserPassword
			  ,[AllowPostingFrom] = @AllowPostingFrom
			  ,[AllowPostingTo] = @AllowPostingTo
			  ,[RegisterTime] = @RegisterTime
			  ,[SalespersPurchCode] = @SalespersPurchCode
			  ,[ApproverID] = @ApproverID
			  ,[SalesAmountApprovalLimit] = @SalesAmountApprovalLimit
			  ,[PurchaseAmountApprovalLimit] = @PurchaseAmountApprovalLimit
			  ,[UnlimitedSalesApproval] = @UnlimitedSalesApproval
			  ,[UnlimitedPurchaseApproval] = @UnlimitedPurchaseApproval
			  ,[Substitute] = @Substitute
			  ,[EMailAddress] = @EMailAddress
			  ,[RequestAmountApprovalLimit] = @RequestAmountApprovalLimit
			  ,[UnlimitedRequestApproval] = @UnlimitedRequestApproval
			  ,[AllowFAPostingFrom] = @AllowFAPostingFrom
			  ,[AllowFAPostingTo] = @AllowFAPostingTo
			  ,[SalesRespCtrFilter] = @SalesRespCtrFilter
			  ,[PurchaseRespCtrFilter] = @PurchaseRespCtrFilter
			  ,[ServiceRespCtr_Filter] = @ServiceRespCtr_Filter
			  ,[DepartmentCode] = @DepartmentCode
			  ,[LocationCode] = @LocationCode
			  ,[RowStatus] = @RowStatus
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GetDate()
		WHERE SystemUsersID = @SystemUsersID
	END
	Select @SystemUsersID
END
GO
/****** Object:  StoredProcedure [dbo].[spTransferRouteEdit]    Script Date: 12/17/2020 12:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spTransferRouteEdit]
	-- Add the parameters for the stored procedure here
	@TransferRouteID int = 0
	, @TransferfromCode varchar(10) = ''
	, @TransfertoCode varchar(10) = ''
	, @InTransitCode varchar(10) = ''
	, @ShippingAgentCode varchar(10) = ''
	, @ShippingAgentServiceCode varchar(10) = ''
	, @RowStatus smallint 
	, @CreatedBy varchar(50) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @TransferRouteID > 0
	BEGIN
		UPDATE [dbo].[TransferRoute]
		   SET [TransferfromCode] = @TransferfromCode 
			  ,[TransfertoCode] = @TransfertoCode 
			  ,[InTransitCode] = @InTransitCode 
			  ,[ShippingAgentCode] = @ShippingAgentCode 
			  ,[ShippingAgentServiceCode] = @ShippingAgentServiceCode 
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GetDate()

		WHERE TransferRouteID = @TransferRouteID

	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[TransferRoute]
			([TransferfromCode]
			,[TransfertoCode]
			,[InTransitCode]
			,[ShippingAgentCode]
			,[ShippingAgentServiceCode]
			,[RowStatus]
			,[CreatedBy]
			,[CreatedTime] )
		VALUES
			( @TransferfromCode 
			, @TransfertoCode 
			, @InTransitCode 
			, @ShippingAgentCode 
			, @ShippingAgentServiceCode 
			, @RowStatus 
			, @CreatedBy 
			, GetDate()  )
		Set @TransferRouteID = @@Identity

	END

	SELECT @TransferRouteID
END
GO
USE [master]
GO
ALTER DATABASE [ARPLogistic] SET  READ_WRITE 
GO
