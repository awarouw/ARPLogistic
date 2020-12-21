

/****** Object:  Table [dbo].[RouteTrx]    Script Date: 12/21/2020 9:57:56 AM ******/
USE [ARPLogistic]
GO
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RouteTrx](
	[RouteTrxID] [int] IDENTITY(1,1) NOT NULL,
	[No] [varchar](20) NOT NULL,
	[Description] [varchar](80) NULL,
	[TrxDate] [datetime] NOT NULL,
	[StaffNo] [varchar](20) NOT NULL,
	[FixedAssetNo] [varchar](20) NOT NULL,
	[Blocked] [tinyint] NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [RouteTrx$0] PRIMARY KEY CLUSTERED 
(
	[RouteTrxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO


