Create Table dbo.Colors
(
	ColorId int not null Primary Key,
	ColorName text
);

Create Table dbo.Brands
(
	BrandId int not null Primary Key,
	BrandName text
);

Create Table dbo.Models
(
	ModelId int not null Primary Key,
	BrandId int not null Foreign Key(BrandId) References dbo.Brands,
	ModelName text
);

Create Table dbo.Cars
(
	CarId int not null Primary Key,
	BrandId int not null Foreign Key(BrandId) References dbo.Brands,
	ModelId int not null Foreign Key(ModelId) References dbo.Models,
	ColorId int not null Foreign Key(ColorId) References dbo.Colors,
	ModelYear smalldatetime,
	DailyPrice dec(5,2),
	CarDescription text
);