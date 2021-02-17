CREATE TABLE [dbo].[Cars] (
    [CarId]          INT            NOT NULL,
    [BrandId]        INT            NOT NULL,
    [ModelId]        INT            NOT NULL,
    [ColorId]        INT            NOT NULL,
    [ModelYear]      SMALLDATETIME  NULL,
    [DailyPrice]     DECIMAL (5, 2) NULL,
    [CarDescription] TEXT           NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Models] ([ModelId])
);

