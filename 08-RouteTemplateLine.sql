USE [ARPLogistic]
GO

/****** Object:  Table [dbo].[RouteTemplateLine]    Script Date: 12/21/2020 9:59:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RouteTemplateLine](
	[RouteTemplateLineID] [int] IDENTITY(1,1) NOT NULL,
	[RouteTemplateID] [int] NOT NULL,
	[RouteTemplateCode] [varchar](20) NOT NULL,
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
 CONSTRAINT [RouteTemplateLine$0] PRIMARY KEY CLUSTERED 
(
	[RouteTemplateCode] ASC,
	[SeqLineNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY],
 CONSTRAINT [IX_RouteTemplateLine] UNIQUE NONCLUSTERED 
(
	[RouteTemplateLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY],
 CONSTRAINT [IX_RouteTemplateLine_1] UNIQUE NONCLUSTERED 
(
	[RouteTemplateID] ASC,
	[SeqLineNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RouteTemplateLine] ADD  CONSTRAINT [DF_RouteTemplateLine_JarakTempuh]  DEFAULT ((0)) FOR [JarakTempuh]
GO

ALTER TABLE [dbo].[RouteTemplateLine] ADD  CONSTRAINT [DF_RouteTemplateLine_BiayaToll]  DEFAULT ((0)) FOR [BiayaToll]
GO

ALTER TABLE [dbo].[RouteTemplateLine] ADD  CONSTRAINT [DF_RouteTemplateLine_BiayaBBM]  DEFAULT ((0)) FOR [BiayaBBM]
GO

ALTER TABLE [dbo].[RouteTemplateLine] ADD  CONSTRAINT [DF_RouteTemplateLine_Retribusi]  DEFAULT ((0)) FOR [Retribusi]
GO

ALTER TABLE [dbo].[RouteTemplateLine] ADD  CONSTRAINT [DF_RouteTemplateLine_BiayaLainLain]  DEFAULT ((0)) FOR [BiayaLainLain]
GO


