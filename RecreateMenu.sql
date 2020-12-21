USE [ARPLogistic]
GO
ALTER TABLE [dbo].[systemusermenu] DROP CONSTRAINT [DF_SystemUserMenu_CreatedTime]
GO
ALTER TABLE [dbo].[systemusermenu] DROP CONSTRAINT [DF_SystemUserMenu_RowStatus]
GO
ALTER TABLE [dbo].[systemusermenu] DROP CONSTRAINT [DF_systemusermenu_SeqNo]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_CreatedTime]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_RowStatus]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_ValueData]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_ExecuteData]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_DeleteData]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_ModifyData]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_InsertData]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_ReadData]
GO
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [DF_systempermission_CompanyID]
GO
ALTER TABLE [dbo].[systemobject] DROP CONSTRAINT [DF_systemobject_Icon]
GO
ALTER TABLE [dbo].[systemobject] DROP CONSTRAINT [DF_systemobject_CreatedTime]
GO
ALTER TABLE [dbo].[systemobject] DROP CONSTRAINT [DF_systemobject_RowStatus]
GO
ALTER TABLE [dbo].[systemobject] DROP CONSTRAINT [DF_systemobject_ObjectSeqNo]
GO
ALTER TABLE [dbo].[systemobject] DROP CONSTRAINT [DF_systemobject_urlObjectName]
GO
/****** Object:  Index [IX_SystemUserMenu]    Script Date: 12/21/2020 10:42:25 PM ******/
ALTER TABLE [dbo].[systemusermenu] DROP CONSTRAINT [IX_SystemUserMenu]
GO
/****** Object:  Index [IX_systempermission]    Script Date: 12/21/2020 10:42:25 PM ******/
ALTER TABLE [dbo].[systempermission] DROP CONSTRAINT [IX_systempermission]
GO
/****** Object:  Table [dbo].[systemusermenu]    Script Date: 12/21/2020 10:42:25 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[systemusermenu]') AND type in (N'U'))
DROP TABLE [dbo].[systemusermenu]
GO
/****** Object:  Table [dbo].[systempermission]    Script Date: 12/21/2020 10:42:25 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[systempermission]') AND type in (N'U'))
DROP TABLE [dbo].[systempermission]
GO
/****** Object:  Table [dbo].[systemobject]    Script Date: 12/21/2020 10:42:25 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[systemobject]') AND type in (N'U'))
DROP TABLE [dbo].[systemobject]
GO
/****** Object:  Table [dbo].[systemobject]    Script Date: 12/21/2020 10:42:25 PM ******/
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
/****** Object:  Table [dbo].[systempermission]    Script Date: 12/21/2020 10:42:25 PM ******/
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
/****** Object:  Table [dbo].[systemusermenu]    Script Date: 12/21/2020 10:42:25 PM ******/
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
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (200000000, N'Trx', N'Menu', N'Transaction', N'', N'', N'', N'#', 1, N'Home', N'Privacy', 0, N'System', CAST(N'2015-10-05T00:18:34.510' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[systemobject] ([SystemObjectID], [ObjectName], [ObjectType], [ObjectDesc], [ObjectSystemName], [ObjectSystemArg], [ObjectSystemImageFileName], [urlObjectName], [ObjectSeqNo], [ControllerName], [ActionName], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime], [Icon]) VALUES (999999999, N'LogOff', N'Menu', N'LogOff', N'', N'', N'', N'', 0, N'Home', N'Privacy', 0, N'System', CAST(N'2016-05-13T09:39:01.683' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
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
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (10, N'ARPLogistic', N'Admin', 200000000, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
INSERT [dbo].[systempermission] ([SystemPermissionID], [CompanyCode], [RoleID], [ObjectID], [ReadData], [InsertData], [ModifyData], [DeleteData], [ExecuteData], [ValueData], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (9, N'ARPLogistic', N'Admin', 999999999, 1, 1, 1, 1, 1, 0, 0, N'System', CAST(N'2015-09-09T00:00:00.000' AS DateTime), N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[systempermission] OFF
GO
SET IDENTITY_INSERT [dbo].[systemusermenu] ON 
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (1, N'ARPLogistic', N'Admin', 1, 100000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (2, N'ARPLogistic', N'Admin', 1, 200000000, 2, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (9, N'ARPLogistic', N'Admin', 1, 999999999, 9, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (4, N'ARPLogistic', N'Admin', 100000000, 101000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (5, N'ARPLogistic', N'Admin', 100000000, 102000000, 2, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (6, N'ARPLogistic', N'Admin', 100000000, 103000000, 3, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (7, N'ARPLogistic', N'Admin', 100000000, 104000000, 4, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (8, N'ARPLogistic', N'Admin', 200000000, 110000000, 1, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[systemusermenu] ([SystemUserMenuID], [CompanyCode], [RoleID], [ParentID], [ChildID], [SeqNo], [RowStatus], [CreatedBy], [CreatedTime], [LastModifiedBy], [LastModifiedTime]) VALUES (3, N'ARPLogistic', N'Admin', 200000000, 120000000, 2, 0, N'System', CAST(N'2015-10-05T00:00:00.000' AS DateTime), N'System', CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[systemusermenu] OFF
GO
/****** Object:  Index [IX_systempermission]    Script Date: 12/21/2020 10:42:25 PM ******/
ALTER TABLE [dbo].[systempermission] ADD  CONSTRAINT [IX_systempermission] UNIQUE NONCLUSTERED 
(
	[SystemPermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SystemUserMenu]    Script Date: 12/21/2020 10:42:25 PM ******/
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [IX_SystemUserMenu] UNIQUE NONCLUSTERED 
(
	[SystemUserMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [DF_systemusermenu_SeqNo]  DEFAULT ((0)) FOR [SeqNo]
GO
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [DF_SystemUserMenu_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
GO
ALTER TABLE [dbo].[systemusermenu] ADD  CONSTRAINT [DF_SystemUserMenu_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
