USE [EMS]
GO
/****** Object:  Table [dbo].[AppSettings]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LastLoggedDomainName] [varchar](50) NULL,
	[LastLoggedUser] [varchar](50) NULL,
	[ConnectionStrings] [varchar](max) NULL,
	[UrlUpdate] [varchar](max) NULL,
	[AllowUserSynchronized] [bit] NOT NULL,
	[MachineName] [varchar](50) NOT NULL,
	[AppVersion] [varchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AppSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppVersion]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppVersion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](20) NOT NULL,
	[ComputerName] [varchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_AppVersion_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
 CONSTRAINT [PK_AppVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Budget]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Budget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Year] [date] NOT NULL,
	[Note] [varchar](500) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Budget] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BudgetPosition]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetPosition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[WareCategoryId] [int] NOT NULL,
	[Month] [date] NOT NULL,
	[Value] [decimal](10, 2) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_BudgetPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNum] [varchar](50) NOT NULL,
	[RecId] [bigint] NOT NULL,
	[RegionId] [varchar](50) NULL,
	[ClassificationId] [varchar](50) NULL,
	[Name] [varchar](150) NOT NULL,
	[NIP] [varchar](20) NULL,
	[ZipCode] [varchar](10) NULL,
	[City] [varchar](150) NULL,
	[Address] [varchar](max) NULL,
	[Budgeted] [varchar](50) NULL CONSTRAINT [DF_Customer_Budgeted]  DEFAULT ('Nie określony'),
	[Active] [bit] NOT NULL CONSTRAINT [DF_Customer_Active]  DEFAULT ((1)),
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_Customer_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Customer_AccountNumb_recId] UNIQUE NONCLUSTERED 
(
	[RecId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeId] [int] NOT NULL,
	[ComputerName] [varchar](50) NOT NULL,
	[Description] [varchar](MAX) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [int] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogType]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_LogType_Active]  DEFAULT ((1)),
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_LogType_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
 CONSTRAINT [PK_LogType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_Permission_Active]  DEFAULT ((1)),
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_Permission_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScheduledTask]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduledTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [varchar](100) NOT NULL,
	[ObjectId] [int] NULL,
	[QueryStatus] [bit] NULL,
	[OldValue] [nvarchar](max) NULL,
	[NewValue] [nvarchar](max) NULL,
	[MachineName] [varchar](50) NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [int] NOT NULL,
 CONSTRAINT [PK_ScheduledTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ScheduledTask_SessionId] UNIQUE NONCLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SynchronizationCustomers]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SynchronizationCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [varchar](100) NULL,
	[RecId] [bigint] NOT NULL,
	[isExists] [bit] NOT NULL,
	[AccountNum] [varchar](50) NULL,
	[RegionId] [varchar](50) NULL,
	[ClassificationId] [varchar](50) NULL,
	[Name] [varchar](150) NULL,
	[NIP] [varchar](20) NULL,
	[ZipCode] [varchar](10) NULL,
	[City] [varchar](150) NULL,
	[Address] [varchar](max) NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_SynchronizationCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_User_Active]  DEFAULT ((1)),
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_User_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserCustomer]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_UserCustomer_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_UserCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_UserCustomer_CustomerId_UserId] UNIQUE NONCLUSTERED 
(
	[CustomerId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WareCategory]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WareCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_WareCategory_Active]  DEFAULT ((1)),
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_WareCategory_CreationDate]  DEFAULT (getdate()),
	[CreationUserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ModificationUserId] [int] NULL,
	[rowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_WareCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_WareCategory_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AppSettings] ADD  CONSTRAINT [DF_AppSettings_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Budget] ADD  CONSTRAINT [DF_Budget_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[BudgetPosition] ADD  CONSTRAINT [DF_BudgetPosition_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[SynchronizationCustomers] ADD  CONSTRAINT [DF_SynchronizationCustomers_isExists]  DEFAULT ((0)) FOR [isExists]
GO
ALTER TABLE [dbo].[UserPermission] ADD  CONSTRAINT [DF_UserPermission_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Budget]  WITH CHECK ADD  CONSTRAINT [FK_Budget_Budget] FOREIGN KEY([Id])
REFERENCES [dbo].[Budget] ([Id])
GO
ALTER TABLE [dbo].[Budget] CHECK CONSTRAINT [FK_Budget_Budget]
GO
ALTER TABLE [dbo].[Budget]  WITH CHECK ADD  CONSTRAINT [FK_Budget_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Budget] CHECK CONSTRAINT [FK_Budget_User]
GO
ALTER TABLE [dbo].[BudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_BudgetPosition_BudgetPosition] FOREIGN KEY([BudgetId])
REFERENCES [dbo].[Budget] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BudgetPosition] CHECK CONSTRAINT [FK_BudgetPosition_BudgetPosition]
GO
ALTER TABLE [dbo].[BudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_BudgetPosition_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[BudgetPosition] CHECK CONSTRAINT [FK_BudgetPosition_CustomerId]
GO
ALTER TABLE [dbo].[BudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_BudgetPosition_WareCategory] FOREIGN KEY([WareCategoryId])
REFERENCES [dbo].[WareCategory] ([Id])
GO
ALTER TABLE [dbo].[BudgetPosition] CHECK CONSTRAINT [FK_BudgetPosition_WareCategory]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_LogType] FOREIGN KEY([LogTypeId])
REFERENCES [dbo].[LogType] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_LogType]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Permission] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Permission]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([ParentId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
ALTER TABLE [dbo].[UserCustomer]  WITH CHECK ADD  CONSTRAINT [FK_UserCustomer_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([RecId])
GO
ALTER TABLE [dbo].[UserCustomer] CHECK CONSTRAINT [FK_UserCustomer_Customer]
GO
ALTER TABLE [dbo].[UserCustomer]  WITH CHECK ADD  CONSTRAINT [FK_UserCustomer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserCustomer] CHECK CONSTRAINT [FK_UserCustomer_User]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_Permission]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_UserPermission] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_UserPermission]
GO
/****** Object:  StoredProcedure [dbo].[LoadScheduleBudget]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[LoadScheduleBudget]
	@budgetId int =0
AS
BEGIN
	/****** Script for SelectTopNRows command from SSMS  ******/

SELECT	pvt.BudgetId,pvt.CustomerId,pvt.WareCategoryId
		,c.Name as Customer,d.Name as WareCategory,YEAR(b.[Year]) as [Year]
		,pvt.[1] as'Styczeń'
		,pvt.[2]as'Luty'
		,pvt.[3]as'Marzec'
		,pvt.[4]as'Kwiecień'
		,pvt.[5]as'Maj'
		,pvt.[6]as'Czerwiec'
		,pvt.[7]as'Lipiec'
		,pvt.[8] as'Sierpień'
		,pvt.[9]as'Wrzesień'
		,pvt.[10]as'Październik'
		,pvt.[11]as'Listopad'
		,pvt.[12]as'Grudzień'
FROM (
    SELECT 
        a.BudgetId,a.CustomerId,a.WareCategoryId,MONTH(a.Month)as [month], 
        a.Value  as MonthValue
    FROM BudgetPosition a
 
) as s
PIVOT
(

	MAX(MonthValue)
    FOR [month] IN ([1], [2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
    
)AS pvt  
 JOIN Budget b WITH(NOLOCK) on pvt.BudgetId = b.Id
  JOIN Customer c WITH(NOLOCK) on pvt.CustomerId = c.Id
  JOIN WareCategory d WITH(NOLOCK) on pvt.WareCategoryId = d.Id 
  where pvt.BudgetId = @budgetId

 
END

GO
/****** Object:  StoredProcedure [dbo].[SynchronizedCustomersAddNew]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SynchronizedCustomersAddNew]
	@sessionId varchar(100) = ''
AS
BEGIN

	DECLARE @countNewCustomer int =0
	SELECT @countNewCustomer = count(a.RecId) FROm SynchronizationCustomers a where isExists = 0 and a.SessionId = @sessionId
	IF @countNewCustomer > 0
		BEGIN
			INSERT INTO [dbo].[Customer]
					   ([AccountNum]
					   ,RecId
					   ,[RegionId]
					   ,[ClassificationId]
					   ,[Name]
					   ,[NIP]
					   ,[ZipCode]
					   ,[City]
					   ,[Address]
					   ,[CreationDate]
					   ,[CreationUserId])
          
			SELECT   d.AccountNum
					,d.RecId
					,d.RegionId
					,d.ClassificationId
					,d.Name
					,d.NIP
					,d.ZipCode
					,d.City
					,d.Address
					,GETDATE()
					,0
					 FROM  dbo.SynchronizationCustomers d WITH (NOLOCK) where d.RecId in (SELECT a.RecId FROm SynchronizationCustomers a where isExists = 0 and a.SessionId = @sessionId)
		end

		DELETE FROM dbo.SynchronizationCustomers where SessionId = @sessionId
	 
END

GO
/****** Object:  StoredProcedure [dbo].[SynchronizedCustomersUpdate]    Script Date: 22.04.2016 03:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SynchronizedCustomersUpdate]
	@sessionId varchar(100) = '',
	@success bit = 0
AS
BEGIN
	IF @sessionId != ''
		BEGIN

				UPDATE [dbo].[SynchronizationCustomers] SET [isExists] = 1 From dbo.Customer a
				JOIN SynchronizationCustomers b WITH (NOLOCK) on a.RecId = b.RecId

				SET @success = 1;
		END
	IF @success > 0 
		BEGIN

				UPDATE dbo.Customer SET  AccountNum = a.AccountNum
										, Address = a.Address
										, City = a.City
										, ZipCode = a.ZipCode
										, ClassificationId = a.ClassificationId
										, RegionId = a.RegionId
										, Name = a.Name
										,ModificationDate = GETDATE()
										,ModificationUserId = 0
										FROM dbo.SynchronizationCustomers a
				JOIN dbo.Customer b WITH (NOLOCK) on a.RecId = b.RecId WHERE [isExists] = 1
		
		END
	 
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numer wersji aplikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwa komputera' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'ComputerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wersja aplikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AppVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rok - np. 2016-01-01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'Year'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notatka' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'Note'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nagłówki budżetów' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator klienta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'CustomerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator kategorii towaru' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'WareCategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Miesiąc w formie daty np. 2016-06-01 czyli czerwiec' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'Month'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wartość w PLN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pozycje budżetów' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetPosition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu źródłowego' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'RecId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NIP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'NIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kod pocztowy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'ZipCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Miejscowość' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ulica' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Budżetowany: 1 - tak, 0 - nie, NULL - nieokreślony' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Budgeted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktywny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Active'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Klienci' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator typu logu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log', @level2type=N'COLUMN',@level2name=N'LogTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwa komputera' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log', @level2type=N'COLUMN',@level2name=N'ComputerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Opis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Logi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kod' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktywny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'Active'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typy logów' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu nadrzędnego' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kod' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktywny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Active'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Słownik uprawnień' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu nadrzędnego' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Login użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Login'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hasło' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Imię użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwisko użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktywny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Active'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Użytkownicy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator klienta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'CustomerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Klienci użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator uprawnienia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'PermissionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Uprawnienia użytkownika' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserPermission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identyfikator rekordu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kod' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nazwa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktywny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'Active'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data utworzenia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Utworzył' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'CreationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data modyfikacji' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zmodyfikował' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory', @level2type=N'COLUMN',@level2name=N'ModificationUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kategorie towarów' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WareCategory'
GO


INSERT [dbo].[User] ([ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES (NULL, N'Admin', N'c3AzM2RTeXN0ZW0uQ2hhcltd', N'Admin', N'Admin', 1, CAST(N'2016-04-10 19:27:18.003' AS DateTime), 1, NULL, NULL)


---- Permision
INSERT [dbo].[Permission] ( [ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES (NULL, N'Budge', N'Budżety', 1, CAST(N'2016-04-10 21:59:56.793' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Permission] ( [ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Config', N'Konfiguracja', 1, CAST(N'2016-04-10 22:00:13.250' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Permission] ( [ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Managment', N'Zarządzanie', 1, CAST(N'2016-04-10 22:00:26.903' AS DateTime), 1, NULL, NULL)

DECLARE @budgetId int =0
DECLARE @configId int =0
DECLARE @managmentId int =0

SELECT @budgetId =  Id FROM Permission where Code = 'Budge'
SELECT @configId =  Id FROM Permission where Code = 'Config'
SELECT @managmentId =  Id FROM Permission where Code = 'Managment'

INSERT [dbo].[Permission] ( [ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( @budgetId , N'Own', N'Własne', 1, CAST(N'2016-04-10 22:04:11.530' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Permission] ( [ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( @budgetId , N'Others', N'Pozostałe', 1, CAST(N'2016-04-10 22:06:10.633' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Permission] ( [ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( @configId, N'UserList', N'Użytkownicy', 1, CAST(N'2016-04-10 22:06:24.620' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Permission] (	[ParentId], [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES( @managmentId, N'ProductCategory', N'Kategorie Towarów', 1, CAST(N'2016-04-10 22:06:47.690' AS DateTime), 0, NULL, NULL)

--- AppVersion

INSERT [dbo].[AppVersion] ([Number], [ComputerName], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES (N'1.0.0.0', N'ADMIN', CAST(N'2016-04-10 19:26:44.947' AS DateTime), 1, NULL, NULL)

---- USER

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Adi', N'YVN5c3RlbS5DaGFyW10=', N'Adam', N'Ślązak', 1, CAST(N'2016-04-12 20:55:48.250' AS DateTime), 1, CAST(N'2016-04-12 20:57:55.477' AS DateTime), 1)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Rafko', N'YVN5c3RlbS5DaGFyW10=', N'Rafał', N'Konewka', 1, CAST(N'2016-04-12 20:56:21.240' AS DateTime), 1, CAST(N'2016-04-12 21:02:06.887' AS DateTime), 1)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Garibo', N'YVN5c3RlbS5DaGFyW10=', N'Garib', N'Tigranyan', 1, CAST(N'2016-04-12 20:56:35.990' AS DateTime), 1, CAST(N'2016-04-12 20:59:14.560' AS DateTime), 1)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Polek', N'YVN5c3RlbS5DaGFyW10=', N'Paulina', N'Dajcz', 1, CAST(N'2016-04-12 20:56:50.510' AS DateTime), 1, CAST(N'2016-04-12 20:59:07.453' AS DateTime), 1)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Korni', N'YVN5c3RlbS5DaGFyW10=', N'Kornel', N'Zdziwchowski', 1, CAST(N'2016-04-12 20:57:07.023' AS DateTime), 1, CAST(N'2016-04-12 20:59:03.880' AS DateTime), 1)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Prezes', N'YVN5c3RlbS5DaGFyW10=', N'Janusz', N'Konopka', 1, CAST(N'2016-04-12 20:57:25.760' AS DateTime), 1, NULL, NULL)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Arek', N'YVN5c3RlbS5DaGFyW10=', N'Arkadiusz', N'Bański', 1, CAST(N'2016-04-12 20:58:35.053' AS DateTime), 1, CAST(N'2016-04-12 20:59:19.600' AS DateTime), 1)

INSERT [dbo].[User] ( [ParentId], [Login], [Password], [FirstName], [LastName], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( NULL, N'Dyrektor', N'YVN5c3RlbS5DaGFyW10=', N'Marek', N'Witczak', 1, CAST(N'2016-04-12 20:58:53.453' AS DateTime), 1, NULL, NULL)

INSERT [dbo].[WareCategory] ( [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( N'KOZ', N'Kozak', 1, CAST(N'2016-04-12 21:23:38.590' AS DateTime), 1, NULL, NULL)

INSERT [dbo].[WareCategory] ( [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( N'KOL', N'Koszule', 1, CAST(N'2016-04-12 21:23:46.777' AS DateTime), 1, NULL, NULL)

INSERT [dbo].[WareCategory] ( [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( N'BUT', N'Buty', 1, CAST(N'2016-04-12 21:23:56.230' AS DateTime), 1, NULL, NULL)

INSERT [dbo].[WareCategory] ( [Code], [Name], [Active], [CreationDate], [CreationUserId], [ModificationDate], [ModificationUserId]) VALUES ( N'CAM', N'Kamery', 1, CAST(N'2016-04-12 21:24:08.090' AS DateTime), 1, NULL, NULL)

-- LogType

INSERT INTO [dbo].[LogType] ([Code] ,[Name]  ,[Active]  ,[CreationDate]  ,[CreationUserId]) VALUES ( 'Exception ','BaseException',1,GETDATE(),1)
          
GO 

CREATE PROCEDURE [dbo].[CustomerList]
	
AS
BEGIN
						select
						Prod.dbo.custtable.ACCOUNTNUM,
						Prod.dbo.custtable.NAME,
						Prod.dbo.custtable.CUSTCLASSIFICATIONID,
						Prod.dbo.custtable.RECID,
						Prod.dbo.custtable.COUNTRYREGIONID,
						Prod.dbo.custtable.STREET,
						Prod.dbo.custtable.ZIPCODE,
						Prod.dbo.custtable.CITY,
						GETDATE() AS CreationDate,
						'0' AS CreationUserId
						from
						Prod.dbo.custtable
END

GO

CREATE PROCEDURE [dbo].[CustomerListImportToSynchronizactionCustomers]
@sessionId varchar(50) =''
	
AS
BEGIN

		IF @sessionId != ''
			BEGIN
								
				select  Prod.dbo.custtable.ACCOUNTNUM,
						Prod.dbo.custtable.NAME,
						Prod.dbo.custtable.CUSTCLASSIFICATIONID,
						Prod.dbo.custtable.RECID,
						Prod.dbo.custtable.COUNTRYREGIONID,
						Prod.dbo.custtable.STREET,
						Prod.dbo.custtable.ZIPCODE,
						Prod.dbo.custtable.CITY,
						@sessionId AS SessionId
						from
						Prod.dbo.custtable
			END
END