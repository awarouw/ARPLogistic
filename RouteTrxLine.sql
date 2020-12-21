USE [ARPLogistic]
GO

/****** Object:  Table [dbo].[RouteTrxLine]    Script Date: 12/21/2020 9:59:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RouteTrxLine](
	[RouteTrxLineID] [int] IDENTITY(1,1) NOT NULL,
	[RouteTrxID] [int] NOT NULL,
	[RouteTrxCode] [varchar](20) NOT NULL,
	[SeqLineNo] [int] NOT NULL,
	[TransferFromCode] [varchar](20) NOT NULL,
	[TransferToCode] [varchar](20) NOT NULL,
	[JarakTempuh] [decimal](18, 5) NULL,
	[BiayaToll] [decimal](18, 5) NULL,
	[BiayaBBM] [decimal](18, 5) NULL,
	[Retribusi] [decimal](18, 5) NULL,
	[BiayaLainLain] [decimal](18, 5) NULL,
	[RowStatus] [smallint] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [RouteTrxLine$0] PRIMARY KEY CLUSTERED 
(
	[RouteTrxCode] ASC,
	[SeqLineNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY],
 CONSTRAINT [IX_RouteTrxLine] UNIQUE NONCLUSTERED 
(
	[RouteTrxLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY],
 CONSTRAINT [IX_RouteTrxLine_1] UNIQUE NONCLUSTERED 
(
	[RouteTrxID] ASC,
	[SeqLineNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RouteTrxLine] ADD  CONSTRAINT [DF_RouteTrxLine_JarakTempuh]  DEFAULT ((0)) FOR [JarakTempuh]
GO

ALTER TABLE [dbo].[RouteTrxLine] ADD  CONSTRAINT [DF_RouteTrxLine_BiayaToll]  DEFAULT ((0)) FOR [BiayaToll]
GO

ALTER TABLE [dbo].[RouteTrxLine] ADD  CONSTRAINT [DF_RouteTrxLine_BiayaBBM]  DEFAULT ((0)) FOR [BiayaBBM]
GO

ALTER TABLE [dbo].[RouteTrxLine] ADD  CONSTRAINT [DF_RouteTrxLine_Retribusi]  DEFAULT ((0)) FOR [Retribusi]
GO

ALTER TABLE [dbo].[RouteTrxLine] ADD  CONSTRAINT [DF_RouteTrxLine_BiayaLainLain]  DEFAULT ((0)) FOR [BiayaLainLain]
GO


