CREATE DATABASE ContactDB;
USE ContactDB;

-- tblLogin
CREATE TABLE dbo.tblLogin (
    UserId int IDENTITY(1,1) NOT NULL,
    UserName nvarchar(200) NOT NULL,
    UserPassword nvarchar(200) NOT NULL
);

INSERT INTO dbo.tblLogin VALUES ('admin', 'admin');

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
(1001, 'testFName', 'testLName', 'test@mail.com', '9876543210', 'testAddress','testCity','testState', 'testCountry', '6543210');
 