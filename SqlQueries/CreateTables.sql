CREATE TABLE [dbo].[Colors] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Brands] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Models] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [BrandId] INT          NOT NULL,
    [Name]    VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Brands] ([Id])
);

CREATE TABLE [dbo].[Cars] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT            NOT NULL,
    [ModelId]     INT            NOT NULL,
    [ColorId]     INT            NOT NULL,
    [ModelYear]   INT            NULL,
    [DailyPrice]  DECIMAL (5, 2) NULL,
    [Name]        VARCHAR (20)   NULL,
    [Description] VARCHAR (500)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Brands] ([Id]),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Colors] ([Id]),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Models] ([Id])
);

CREATE TABLE [dbo].[CarImages] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [CarId]     INT           NOT NULL,
    [ImagePath] VARCHAR (250) NULL,
    [Date]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (20) NULL,
    [LastName]  VARCHAR (20) NULL,
    [Email]     VARCHAR (50) NULL,
    [Password]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [CompanyName] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NOT NULL,
    [CustomerId] INT      NOT NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Customers] ([Id]),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Cars] ([Id])
);