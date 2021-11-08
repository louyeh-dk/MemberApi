CREATE DATABASE MemberDB;
GO
USE MemberDB;
--DROP TABLE MEMBER;
CREATE TABLE Member (
    Id INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
	MiddelName VARCHAR(50) NULL,
    Mobile VARCHAR(10)NOT NULL,
    Mail VARCHAR (50) NOT NULL
	
);

GO

INSERT INTO MEMBER( FirstName, LastName, MiddelName, Mobile,Mail )
VALUES('Sam', 'Louyeh','','212121445','Sam@post.com' );

INSERT INTO MEMBER ( FirstName, LastName, MiddelName, Mobile,Mail )
VALUES('Eric', 'Nilsen','Mogens','555321445','Eric@post.com' );

INSERT INTO MEMBER ( FirstName, LastName, MiddelName, Mobile,Mail )
VALUES('Rasmus', 'Hansen','Rand','33321445','Rasmus@post.com' );
GO