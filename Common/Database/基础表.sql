USE [Kaimjz]
GO
/****** Object:  Table [dbo].[Sys_RoleOperating]    Script Date: 10/13/2016 14:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_RoleOperating](
	[RoleID] [nvarchar](50) NOT NULL,
	[OperatingID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sys_RoleOperating] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[OperatingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PK Sys_Role' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleOperating', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK Sys_Operating' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleOperating', @level2type=N'COLUMN',@level2name=N'OperatingID'
GO
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 10/13/2016 14:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Role](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[RoleLevel] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Sys_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'RoleLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'Status'
GO
INSERT [dbo].[Sys_Role] ([ID], [Name], [RoleLevel], [CreateDate], [Status]) VALUES (N'701dc798-9ef2-45f1-91c6-0ad8e6fb072f', N'后台管理员', 1, CAST(0x0000A63B017F82E5 AS DateTime), 1)
/****** Object:  Table [dbo].[Sys_Operating]    Script Date: 10/13/2016 14:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Operating](
	[ID] [uniqueidentifier] NOT NULL,
	[ParentID] [uniqueidentifier] NULL,
	[OpName] [nvarchar](50) NULL,
	[OpLevel] [int] NULL,
	[Url] [nvarchar](100) NULL,
	[Sort] [int] NULL,
	[IsPublic] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Sys_Operating] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'OpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级 数值越小   级别越高   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'OpLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序   数值越小   越靠前' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显隐  1显示，0隐藏' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'IsPublic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Operating', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
/****** Object:  Table [dbo].[Sys_Log]    Script Date: 10/13/2016 14:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Log](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[LogType] [nvarchar](50) NULL,
	[LogModelID] [uniqueidentifier] NULL,
	[LogContent] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Sys_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK Sys_User' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际业务  枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作页面ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'LogModelID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'LogContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 10/13/2016 14:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_User](
	[ID] [uniqueidentifier] NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[LoginPwd] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[RoleID] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Sys_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'LoginPwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0未激活，1激活，2停用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Status'
GO
INSERT [dbo].[Sys_User] ([ID], [LoginName], [LoginPwd], [UserName], [RoleID], [CreateDate], [Status]) VALUES (N'711efe79-65d8-4da4-9183-1573df3888d1', N'admin', N'96e79218965eb72c92a549dd5a330112', N'凯哥', N'701dc798-9ef2-45f1-91c6-0ad8e6fb072f', CAST(0x0000A63B017FACB8 AS DateTime), 1)
/****** Object:  Default [DF_Sys_Role_ID]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Role] ADD  CONSTRAINT [DF_Sys_Role_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_Sys_Role_CreateDate]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Role] ADD  CONSTRAINT [DF_Sys_Role_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_Sys_Role_Status]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Role] ADD  CONSTRAINT [DF_Sys_Role_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_Sys_Operating_ID]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Operating] ADD  CONSTRAINT [DF_Sys_Operating_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_Sys_Operating_Sort]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Operating] ADD  CONSTRAINT [DF_Sys_Operating_Sort]  DEFAULT ((0)) FOR [Sort]
GO
/****** Object:  Default [DF_Sys_Operating_IsPublic]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Operating] ADD  CONSTRAINT [DF_Sys_Operating_IsPublic]  DEFAULT ((1)) FOR [IsPublic]
GO
/****** Object:  Default [DF_Sys_Operating_CreateDate]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Operating] ADD  CONSTRAINT [DF_Sys_Operating_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_Sys_Log_ID]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_Log] ADD  CONSTRAINT [DF_Sys_Log_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_Sys_User_ID]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_User] ADD  CONSTRAINT [DF_Sys_User_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_Sys_User_CreateDate]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_User] ADD  CONSTRAINT [DF_Sys_User_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_Sys_User_Status]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_User] ADD  CONSTRAINT [DF_Sys_User_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  ForeignKey [FK_Sys_User_Sys_Role]    Script Date: 10/13/2016 14:52:48 ******/
ALTER TABLE [dbo].[Sys_User]  WITH CHECK ADD  CONSTRAINT [FK_Sys_User_Sys_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Sys_Role] ([ID])
GO
ALTER TABLE [dbo].[Sys_User] CHECK CONSTRAINT [FK_Sys_User_Sys_Role]
GO
