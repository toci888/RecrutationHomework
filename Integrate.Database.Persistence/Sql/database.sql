
drop view if exists ProductBySku;

drop  table if exists Prices;
drop  table if exists Inventory;
drop  table if exists Products;

create table Products
(
	ID int primary key,
	SKU text unique,
	name text,
	EAN text,
	producer_name text,
	category text,
	is_wire int,
	available int,
	is_vendor int,-- Indicates whether the product is shipped by supplier or warehouse. If value is 0, it’s shipped by warehouse, if 1, it’s shipped by supplier.
	default_image text -- URL address to product’s image
);

create table Inventory
(
	product_id int primary key references Products(ID) not null,
	sku text unique references Products(SKU) not null,
	unit text,
	qty float,
	manufacturer text,
	shipping text,
	shipping_cost float
);

create table Prices
(
	ID int primary key references Products(ID) not null,
	SKU text unique references Products(SKU) not null,
	NettProductPrice float,
	NettProductPriceDiscount float,
	VATRate float,
	NettProductPriceDiscountPlu float
);

create view ProductBySku as
select P1.SKU, P1.name, P1.EAN, P1.producer_name, P1.category, P1.default_image, 
I1.qty, I1.unit, Pr1.NettProductPrice, I1.shipping_cost
from 
Products P1 join Inventory I1 on P1.SKU = I1.sku
join Prices Pr1 on P1.SKU = Pr1.SKU