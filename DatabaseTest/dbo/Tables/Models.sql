CREATE TABLE [dbo].[Models] (
    [ModelId]   INT  NOT NULL,
    [BrandId]   INT  NOT NULL,
    [ModelName] TEXT NULL,
    PRIMARY KEY CLUSTERED ([ModelId] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);

