CREATE DATABASE QRRDatabase;

Create table [QRRDatabase].[dbo].[tblUserDetails](
 UserId int IDENTITY(1,1) PRIMARY KEY,
 UserName varchar(50),
 Password varchar(10),
 FirstName varchar(50),
 LastName varchar(50) NOT NULL,
 IsAdminUser bit
)

insert into [QRRDatabase].[dbo].[tblUserDetails] (UserName,Password,FirstName,LastName,IsAdminUser)
values('qrr_admin','qrr_admin','admin','admin',1)

insert into [QRRDatabase].[dbo].[tblUserDetails] (UserName,Password,FirstName,LastName,IsAdminUser)
values('qrr_User','qrr_User','QRR','User',1)

insert into [QRRDatabase].[dbo].[tblUserDetails] (UserName,Password,FirstName,LastName,IsAdminUser)
values('sysadmin','sysadmin','system','Admin',0)

-----------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spGetUserDetails
	@username varchar(50),
	@password varchar(50)
AS
BEGIN
	select * from [dbo].[tblUserDetails] where UserName=@username AND Password=@password;
	
END
GO
