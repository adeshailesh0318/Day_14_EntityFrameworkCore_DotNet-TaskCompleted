create database Authentication_AuthorizationWithZestIndiaDB
Go
use Authentication_AuthorizationWithZestIndiaDB


go


CREATE TABLE Roles
(
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Roles (RoleName)
VALUES 
('Admin'),
('User');

go


CREATE TABLE Users
(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL UNIQUE,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,

    CONSTRAINT FK_Users_Roles
        FOREIGN KEY (RoleId)
        REFERENCES Roles(RoleId)
);

INSERT INTO Users (UserName, Email, Password, RoleId)
VALUES
('admin', 'shaileshade@gmail.com', 'ade@0318', 1),
('vaishh', 'vaishh@gmail.com', 'ade@0318', 2);


go

select *from Roles
select *from [Users]