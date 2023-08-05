USE SportsStoreIdentityDb ;
GO

SELECT * FROM dbo.AspNetRoles ;
SELECT * FROM dbo.AspNetUserRoles ;
SELECT * FROM dbo.AspNetUsers ;

BEGIN TRANSACTION ;

DECLARE @RoleID NVARCHAR(128), @UserID NVARCHAR(128) ;
SET @RoleID = ( SELECT Id FROM dbo.AspNetRoles WHERE Name = 'Administrators' ) ;
SET @UserID = ( SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'Admin' ) ;	-- Alternatively: Email = 'admin@example.com'

DELETE FROM  dbo.AspNetUserRoles ;

INSERT INTO dbo.AspNetUserRoles ( UserId, RoleId, Discriminator )
VALUES ( @UserId, @RoleId, 'StoreUserRole' ) ;	--  /* 'SportsStore.Infrastructure.Identity.StoreUserRole' */ 

SELECT * FROM  dbo.AspNetUserRoles ;

COMMIT TRANSACTION ;