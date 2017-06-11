
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2017 13:44:18
-- Generated from EDMX file: E:\GitRepositry\SkyReg_Dev\SkyReg\DataLayer\DLModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SkyRegDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserUsersType_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserUsersType] DROP CONSTRAINT [FK_UserUsersType_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUsersType_UsersType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserUsersType] DROP CONSTRAINT [FK_UserUsersType_UsersType];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOperator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operator] DROP CONSTRAINT [FK_UserOperator];
GO
IF OBJECT_ID(N'[dbo].[FK_FlightAirplane]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flight] DROP CONSTRAINT [FK_FlightAirplane];
GO
IF OBJECT_ID(N'[dbo].[FK_ParachuteUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parachute] DROP CONSTRAINT [FK_ParachuteUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FlightsElemFlight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FlightsElem] DROP CONSTRAINT [FK_FlightsElemFlight];
GO
IF OBJECT_ID(N'[dbo].[FK_FlightsElemUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FlightsElem] DROP CONSTRAINT [FK_FlightsElemUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FlightsElemParachute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parachute] DROP CONSTRAINT [FK_FlightsElemParachute];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_UserOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_GroupUser];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentsPaymentsSetting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_PaymentsPaymentsSetting];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPayments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_UserPayments];
GO
IF OBJECT_ID(N'[dbo].[FK_FlightsElemPayments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FlightsElem] DROP CONSTRAINT [FK_FlightsElemPayments];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PaymentsSetting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentsSetting];
GO
IF OBJECT_ID(N'[dbo].[GlobalSetting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GlobalSetting];
GO
IF OBJECT_ID(N'[dbo].[Operator]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operator];
GO
IF OBJECT_ID(N'[dbo].[UsersType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersType];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Airplane]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Airplane];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Flight]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flight];
GO
IF OBJECT_ID(N'[dbo].[FlightsElem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FlightsElem];
GO
IF OBJECT_ID(N'[dbo].[Parachute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parachute];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payment];
GO
IF OBJECT_ID(N'[dbo].[UserUsersType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserUsersType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PaymentsSetting'
CREATE TABLE [dbo].[PaymentsSetting] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] smallint  NOT NULL,
    [Value] decimal(8,2)  NULL,
    [Count] decimal(18,0)  NULL
);
GO

-- Creating table 'GlobalSetting'
CREATE TABLE [dbo].[GlobalSetting] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeBefore] time  NULL,
    [TimeAfter] time  NULL,
    [AirportsName] nvarchar(max)  NULL,
    [CertExpired] smallint  NULL,
    [CountPerHour] nvarchar(max)  NULL,
    [CamPrice] decimal(18,0)  NULL
);
GO

-- Creating table 'Operator'
CREATE TABLE [dbo].[Operator] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] smallint  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'UsersType'
CREATE TABLE [dbo].[UsersType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Value] decimal(8,2)  NOT NULL,
    [IsCam] bit  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [Certificate] nvarchar(max)  NULL,
    [CertDate] datetime  NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [SurName] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NULL,
    [ZipCode] nvarchar(max)  NULL,
    [Street] nvarchar(max)  NULL,
    [StreetNr] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [FaceBook] nvarchar(max)  NULL,
    [IdNr] int  NULL,
    [Group_Id] int  NULL
);
GO

-- Creating table 'Airplane'
CREATE TABLE [dbo].[Airplane] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegNr] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Seats] int  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderTime] datetime  NOT NULL,
    [IsUser] bit  NOT NULL,
    [User_Id] int  NULL
);
GO

-- Creating table 'Flight'
CREATE TABLE [dbo].[Flight] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FlyDateTime] datetime  NOT NULL,
    [FlyNr] nvarchar(max)  NOT NULL,
    [FlyStatus] smallint  NOT NULL,
    [Altitude] int  NOT NULL,
    [Airplane_Id] int  NULL
);
GO

-- Creating table 'FlightsElem'
CREATE TABLE [dbo].[FlightsElem] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AssemblySelf] bit  NULL,
    [Lp] int  NULL,
    [TeamName] nvarchar(max)  NULL,
    [Flight_Id] int  NOT NULL,
    [User_Id] int  NOT NULL,
    [Payments_Id] int  NOT NULL
);
GO

-- Creating table 'Parachute'
CREATE TABLE [dbo].[Parachute] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdNr] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [RentValue] decimal(8,2)  NULL,
    [AssemblyValue] decimal(8,2)  NULL,
    [User_Id] int  NULL,
    [FlightsElem_Id] int  NULL
);
GO

-- Creating table 'Group'
CREATE TABLE [dbo].[Group] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Color] nvarchar(max)  NOT NULL,
    [AllowDelete] bit  NULL
);
GO

-- Creating table 'Payment'
CREATE TABLE [dbo].[Payment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Value] decimal(8,2)  NOT NULL,
    [Count] decimal(8,2)  NULL,
    [IsBooked] bit  NULL,
    [Date] datetime  NULL,
    [PaymentsSetting_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'UserUsersType'
CREATE TABLE [dbo].[UserUsersType] (
    [User_Id] int  NOT NULL,
    [UsersType_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PaymentsSetting'
ALTER TABLE [dbo].[PaymentsSetting]
ADD CONSTRAINT [PK_PaymentsSetting]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GlobalSetting'
ALTER TABLE [dbo].[GlobalSetting]
ADD CONSTRAINT [PK_GlobalSetting]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operator'
ALTER TABLE [dbo].[Operator]
ADD CONSTRAINT [PK_Operator]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersType'
ALTER TABLE [dbo].[UsersType]
ADD CONSTRAINT [PK_UsersType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Airplane'
ALTER TABLE [dbo].[Airplane]
ADD CONSTRAINT [PK_Airplane]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Flight'
ALTER TABLE [dbo].[Flight]
ADD CONSTRAINT [PK_Flight]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FlightsElem'
ALTER TABLE [dbo].[FlightsElem]
ADD CONSTRAINT [PK_FlightsElem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parachute'
ALTER TABLE [dbo].[Parachute]
ADD CONSTRAINT [PK_Parachute]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [PK_Group]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [PK_Payment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [UsersType_Id] in table 'UserUsersType'
ALTER TABLE [dbo].[UserUsersType]
ADD CONSTRAINT [PK_UserUsersType]
    PRIMARY KEY CLUSTERED ([User_Id], [UsersType_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'UserUsersType'
ALTER TABLE [dbo].[UserUsersType]
ADD CONSTRAINT [FK_UserUsersType_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UsersType_Id] in table 'UserUsersType'
ALTER TABLE [dbo].[UserUsersType]
ADD CONSTRAINT [FK_UserUsersType_UsersType]
    FOREIGN KEY ([UsersType_Id])
    REFERENCES [dbo].[UsersType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUsersType_UsersType'
CREATE INDEX [IX_FK_UserUsersType_UsersType]
ON [dbo].[UserUsersType]
    ([UsersType_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Operator'
ALTER TABLE [dbo].[Operator]
ADD CONSTRAINT [FK_UserOperator]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOperator'
CREATE INDEX [IX_FK_UserOperator]
ON [dbo].[Operator]
    ([User_Id]);
GO

-- Creating foreign key on [Airplane_Id] in table 'Flight'
ALTER TABLE [dbo].[Flight]
ADD CONSTRAINT [FK_FlightAirplane]
    FOREIGN KEY ([Airplane_Id])
    REFERENCES [dbo].[Airplane]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlightAirplane'
CREATE INDEX [IX_FK_FlightAirplane]
ON [dbo].[Flight]
    ([Airplane_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Parachute'
ALTER TABLE [dbo].[Parachute]
ADD CONSTRAINT [FK_ParachuteUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParachuteUser'
CREATE INDEX [IX_FK_ParachuteUser]
ON [dbo].[Parachute]
    ([User_Id]);
GO

-- Creating foreign key on [Flight_Id] in table 'FlightsElem'
ALTER TABLE [dbo].[FlightsElem]
ADD CONSTRAINT [FK_FlightsElemFlight]
    FOREIGN KEY ([Flight_Id])
    REFERENCES [dbo].[Flight]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlightsElemFlight'
CREATE INDEX [IX_FK_FlightsElemFlight]
ON [dbo].[FlightsElem]
    ([Flight_Id]);
GO

-- Creating foreign key on [User_Id] in table 'FlightsElem'
ALTER TABLE [dbo].[FlightsElem]
ADD CONSTRAINT [FK_FlightsElemUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlightsElemUser'
CREATE INDEX [IX_FK_FlightsElemUser]
ON [dbo].[FlightsElem]
    ([User_Id]);
GO

-- Creating foreign key on [FlightsElem_Id] in table 'Parachute'
ALTER TABLE [dbo].[Parachute]
ADD CONSTRAINT [FK_FlightsElemParachute]
    FOREIGN KEY ([FlightsElem_Id])
    REFERENCES [dbo].[FlightsElem]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlightsElemParachute'
CREATE INDEX [IX_FK_FlightsElemParachute]
ON [dbo].[Parachute]
    ([FlightsElem_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[Order]
    ([User_Id]);
GO

-- Creating foreign key on [Group_Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_GroupUser]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[Group]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUser'
CREATE INDEX [IX_FK_GroupUser]
ON [dbo].[User]
    ([Group_Id]);
GO

-- Creating foreign key on [PaymentsSetting_Id] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [FK_PaymentsPaymentsSetting]
    FOREIGN KEY ([PaymentsSetting_Id])
    REFERENCES [dbo].[PaymentsSetting]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentsPaymentsSetting'
CREATE INDEX [IX_FK_PaymentsPaymentsSetting]
ON [dbo].[Payment]
    ([PaymentsSetting_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [FK_UserPayments]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPayments'
CREATE INDEX [IX_FK_UserPayments]
ON [dbo].[Payment]
    ([User_Id]);
GO

-- Creating foreign key on [Payments_Id] in table 'FlightsElem'
ALTER TABLE [dbo].[FlightsElem]
ADD CONSTRAINT [FK_FlightsElemPayments]
    FOREIGN KEY ([Payments_Id])
    REFERENCES [dbo].[Payment]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlightsElemPayments'
CREATE INDEX [IX_FK_FlightsElemPayments]
ON [dbo].[FlightsElem]
    ([Payments_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------