create database ZestIndiaCRUDTaskDB
go
use ZestIndiaCRUDTaskDB


GO

CREATE TABLE Categories
(
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL,
    Description VARCHAR(500)
);

go

INSERT INTO Categories (CategoryName, Description)
VALUES
('Electronics', 'Electronic products'),
('Mobiles', 'Mobile phones and accessories'),
('Laptops', 'Laptops and computers'),
('Shoes', 'Sports and casual shoes'),
('Books', 'Educational and programming books');
GO


CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Description VARCHAR(500),
    CategoryId INT NOT NULL,

    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId)
        REFERENCES Categories(CategoryId)
);
GO

INSERT INTO Products
(ProductName, Price, Stock, Description, CategoryId)
VALUES
('iPhone 15', 69999, 10, 'Apple smartphone', 2),
('Samsung Galaxy S24', 74999, 15, 'Samsung smartphone', 2),
('Dell Inspiron', 55000, 8, 'Dell Core i5 laptop', 3),
('HP Pavilion', 48000, 12, 'HP Core i5 laptop', 3),
('Nike Running Shoes', 4999, 20, 'Running shoes', 4),
('Adidas Sports Shoes', 3999, 25, 'Sports shoes', 4),
('C# Programming Book', 999, 18, 'C# learning book', 5),
('ASP.NET Core Book', 1200, 15, 'ASP.NET Core learning book', 5);
GO

select *from Categories
select *from Products


select *from Products where CategoryId =4