create database Authentication_AuthorizationWithZestIndiaDB
Go
use Authentication_AuthorizationWithZestIndiaDB
go

create table Roles
(
Id int primary key identity,
Name varchar(50)
)
go
insert into Roles values('admin'),('user')


go

create table Users
(
Id int primary key identity,
Name varchar(50) not null,
Email varchar(50),
Password varchar(50),
RoleId int foreign key references Roles(Id)
)
go

insert into [Users] values('shailesh','adeshailesh.net@gmail.com','Ade@0318',1),
('Vaishh','vaishh@gmail.com','Ade@0318',1),('user','user@gamil.com','user123456',2),('shree','shree@gmail.com','shree12345',2);
go

select *from [Users]
select *from Roles

go


CREATE TABLE Category
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(500)
);

INSERT INTO Category (Name, Description)
VALUES
('Electronics', 'Electronic devices and accessories'),
('Mobiles', 'Smartphones and mobile accessories'),
('Laptops', 'Laptops and computer accessories'),
('Clothing', 'Men and women clothing products'),
('Books', 'Educational and general books')
go

select *from Category