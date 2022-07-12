CREATE TABLE dbo.Users  
(
   Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,  
   _Login varchar(50) NOT NULL,  
   _Password varchar(50) NULL,  
   Id_record int NULL
)  