CREATE DATABASE ContactDB;
USE ContactDB;

-- tblLogin
DROP TABLE IF EXISTS dbo.tblLogin;
CREATE TABLE dbo.tblLogin (
    UserId int IDENTITY(1,1) NOT NULL,
    UserName nvarchar(200) NOT NULL,
    UserPassword nvarchar(200) NOT NULL
);

INSERT INTO dbo.tblLogin VALUES ('admin', 'admin');


-- tblContact
DROP TABLE IF EXISTS dbo.tblContact;
CREATE TABLE dbo.tblContact (
    ContactId int NOT NULL PRIMARY KEY,
    FirstName nvarchar(200) NOT NULL,
    LastName nvarchar(200),
	Email nvarchar(200),
	PhoneNumber nvarchar(15),
	Address nvarchar(500),
	City nvarchar(100),
	State nvarchar(100),
	Country nvarchar(100),
	PostalCode nvarchar(10)
);

INSERT INTO tblContact VALUES
(1001, 'John', 'A', 'john@mail.com', '9876543210', '123 St','CJ','NJ', 'USA', '6543210'),
(1002, 'Rick', 'R', 'rick@mail.com', '9876543333', '456 St','CT','NY', 'USA', '6543333');
 