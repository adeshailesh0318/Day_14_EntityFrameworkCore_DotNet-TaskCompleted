

select *from Categories


INSERT INTO Categories VALUES
('Electronics'),
('Clothing'),
('Books'),
('Home Appliances'),
('Sports & Outdoors'),
('Toys & Games'),
('Beauty & Personal Care'),
('Groceries');


go

-- Insert Categories
INSERT INTO Categories (Name) VALUES
('Electronics'),
('Clothing'),
('Books'),
('Home Appliances'),
('Sports & Outdoors'),
('Toys & Games'),
('Beauty & Personal Care'),
('Groceries');


go
INSERT INTO Products (ProductName, Price, Quantity, CategoryId) VALUES
('Laptop', 55000.00, 10, 1),
('Smartphone', 25000.00, 25, 1),
('Headphones', 2000.00, 50, 1),
('Smart TV', 40000.00, 5, 1),
('T-Shirt', 500.00, 100, 2),
('Jeans', 1500.00, 40, 2),
('Jacket', 3000.00, 15, 2),
('C# Programming Book', 800.00, 30, 3),
('ASP.NET Core Guide', 1200.00, 20, 3),
('Refrigerator', 30000.00, 8, 4),
('Washing Machine', 22000.00, 12, 4),
('Microwave Oven', 8000.00, 18, 4),
('Cricket Bat', 2500.00, 22, 5),
('Football', 900.00, 35, 5),
('Lego Set', 3500.00, 14, 6);


go

select *from Products