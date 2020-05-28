
IF OBJECT_ID ('dbo.tblUser', 'U') IS NOT NULL  
   DROP TABLE tblUser;  
GO 

CREATE TABLE [dbo].[tblUser](    
    [UserID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,    
    [UserName] [nvarchar](50) NOT NULL,    
    [Email] [nvarchar](50) NOT NULL,    
    [Mobile] [nvarchar](15) NOT NULL,   
    [Password] [nvarchar](50) NOT NULL,
	[UserType] [char] NOT NULL
) ON [PRIMARY]    
GO 

IF OBJECT_ID ('dbo.tblMenu', 'U') IS NOT NULL  
   DROP TABLE tblMenu;  
GO 

CREATE TABLE [dbo].[tblMenu](    
    [MenuID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,    
    [MenuName] [nvarchar](50) NOT NULL,    
    [URL] [nvarchar](250) NOT NULL,    
) ON [PRIMARY]    
GO 

IF OBJECT_ID ('dbo.tblUserMenu', 'U') IS NOT NULL  
   DROP TABLE tblUserMenu;  
GO 

CREATE TABLE [dbo].[tblUserMenu](    
    [PrivID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,    
    [UserID] [int] NOT NULL,    
    [MenuID] [int] NOT NULL    
)   
GO 


