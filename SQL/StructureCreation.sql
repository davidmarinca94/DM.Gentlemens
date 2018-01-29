CREATE TABLE [Users](
	[UserID] uniqueidentifier NOT NULL,
	[Username] nvarchar(50) NOT NULL,
	[UserPassword] nvarchar(50) NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Address] nvarchar(250) NOT NULL,
	[City] nvarchar(50) NOT NULL,
	[Country] nvarchar(50) NOT NULL,
	[PhoneNumber] nvarchar(50) NOT NULL,
	[EmailAddress] nvarchar(50) NOT NULL,
	[UserRole] nvarchar(50) NOT NULL,	
CONSTRAINT [PK_Users] PRIMARY KEY ([UserID]));

CREATE TABLE [Images](
	[ImageID] uniqueidentifier NOT NULL,
	[ImageUrl] nvarchar(250) NOT NULL,
CONSTRAINT [PK_Images] PRIMARY KEY ([ImageID]));

CREATE TABLE [Categories](
	[CategoryID] uniqueidentifier NOT NULL,
	[CategoryName] nvarchar(50) NOT NULL,
	[ImageID] uniqueidentifier,
	[ParentID] uniqueidentifier,
CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID]),
CONSTRAINT [FK_Categories_Images] FOREIGN KEY ([ImageID])
    REFERENCES [Images]([ImageID]),
CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentID])
    REFERENCES [Categories]([CategoryID]));


CREATE TABLE [Products](
	[ProductID] uniqueidentifier NOT NULL,
	[CategoryID] uniqueidentifier,
	[ProductName] nvarchar(50) NOT NULL,
	[ProductDescription] nvarchar(500) NOT NULL,
	[ImageID] uniqueidentifier,
	[Price] DECIMAL(19,6) NOT NULL,
CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID])
    REFERENCES [Categories]([CategoryID]),
CONSTRAINT [FK_Products_Images] FOREIGN KEY ([ImageID])
    REFERENCES [Images]([ImageID]));


CREATE TABLE [ShoppingCart](
	[CartID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier,
	[ProductID] uniqueidentifier,
	[Quantity] int NOT NULL,
CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([CartID]),
CONSTRAINT [FK_ShoppingCart_Users] FOREIGN KEY ([UserID])
    REFERENCES [Users]([UserID]),
CONSTRAINT [FK_ShoppingCart_Products] FOREIGN KEY ([ProductID])
	REFERENCES [Products]([ProductID]));


CREATE TABLE [Orders](
	[OrderID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[BuyerName] nvarchar(50) NOT NULL,
	[BuyerEmail] nvarchar(50) NOT NULL,
	[BuyerAddress] nvarchar(250) NOT NULL,
	[OrderDate] date,
CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]));


CREATE TABLE [OrderedProducts](
	[SoldItemID] uniqueidentifier NOT NULL,
	[OrderID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[ProductID] uniqueidentifier NOT NULL,
	[Quantity] int NOT NULL,
CONSTRAINT [PK_OrderedProducts] PRIMARY KEY ([SoldItemID]),
CONSTRAINT [FK_OrderedProducts_Orders] FOREIGN KEY ([OrderID])
	REFERENCES [Orders]([OrderID]),
CONSTRAINT [FK_OrderedProducts_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_OrderedProducts_Product] FOREIGN KEY ([ProductID])
	REFERENCES [Products]([ProductID]));
GO


CREATE PROCEDURE dbo.Users_Create
	@UserID					uniqueidentifier = NULL,
	@Username				nvarchar(50) = NULL,
	@UserPassword			nvarchar(50) = NULL,
	@FirstName				nvarchar(50) = NULL,
	@LastName				nvarchar(50) = NULL,
	@Address				nvarchar(250) = NULL,
	@City					nvarchar(50) = NULL,
	@Country				nvarchar(50) = NULL,
	@PhoneNumber			nvarchar(50) = NULL,
	@EmailAddress			nvarchar(50) = NULL,
	@UserRole				nvarchar(50) = NULL
AS
BEGIN
INSERT INTO dbo.Users
	(
	UserID,
	Username,
	UserPassword,
	FirstName,
	LastName,
	Address,
	City,
	Country,
	PhoneNumber,
	EmailAddress,
	UserRole
	)
VALUES
	(
	@UserID,
	@Username,			
	@UserPassword,
	@FirstName,
	@LastName,				
	@Address,
	@City,
	@Country,
	@PhoneNumber,
	@EmailAddress,
	@UserRole
	)
END
GO


CREATE PROCEDURE dbo.Images_Create
	@ImageID					uniqueidentifier = NULL,
	@ImageUrl					nvarchar(250) = NULL
	
AS
BEGIN
INSERT INTO dbo.Images
	(
	ImageID,
	ImageUrl
	)
VALUES
	(
	@ImageID,
	@ImageUrl	
	)
END
GO


CREATE PROCEDURE dbo.Categories_Create
	@CategoryID						uniqueidentifier = NULL,
	@CategoryName					nvarchar(250) = NULL,
	@ImageID						uniqueidentifier = NULL,
	@ParentID						uniqueidentifier = NULL
	
AS
BEGIN
INSERT INTO dbo.Categories
	(
	CategoryID,
	CategoryName,
	ImageID,
	ParentID
	)
VALUES
	(
	@CategoryID,
	@CategoryName,
	@ImageID,
	@ParentID	
	)
END
GO


CREATE PROCEDURE dbo.Products_Create
	@ProductID						uniqueidentifier = NULL,
	@CategoryID						uniqueidentifier = NULL,
	@ProductName					nvarchar(50) = NULL,
	@ProductDescription				nvarchar(500) = NULL,
	@ImageID						uniqueidentifier = NULL,
	@Price							DECIMAL(19,6) = NULL
AS
BEGIN
INSERT INTO dbo.Products
	(
	ProductID,
	CategoryID,
	ProductName,
	ProductDescription,
	ImageID,
	Price
	)
VALUES
	(
	@ProductID,
	@CategoryID,
	@ProductName,
	@ProductDescription,
	@ImageID,
	@Price	
	)
END
GO


CREATE PROCEDURE dbo.ShoppingCart_Create
	@CartID							uniqueidentifier = NULL,
	@UserID							uniqueidentifier = NULL,
	@ProductID						uniqueidentifier = NULL,
	@Quantity						int = NULL
AS
BEGIN
INSERT INTO dbo.ShoppingCart
	(
	CartID,
	UserID,
	ProductID,
	Quantity
	)
VALUES
	(
	@CartID,
	@UserID,
	@ProductID,
	@Quantity	
	)
END
GO


CREATE PROCEDURE dbo.Orders_Create
	@OrderID       uniqueidentifier = NULL, 
	@UserID        uniqueidentifier = NULL
AS
BEGIN 
INSERT INTO dbo.Orders  
SELECT  @OrderID,    
		@UserID,    
		u.FirstName + ' ' + u.LastName as BuyerName,    
		u.EmailAddress as BuyerEmail,    
		u.Address + ' ' + u.City + ' ' + u.Country as BuyerAddress,    
		GETDATE() as OrderDate  
		FROM Users u  
		WHERE UserID = @UserID
END
GO


CREATE PROCEDURE dbo.OrderedProducts_Create
	@SoldItemID         uniqueidentifier = NULL, 
	@OrderID			uniqueidentifier = NULL,
	@UserID				uniqueidentifier = NULL,
	@ProductID			uniqueidentifier = NULL,
	@Quantity			int = NULL
AS
BEGIN 
INSERT INTO dbo.OrderedProducts
(
	SoldItemID,
	OrderID,
	UserID,
	ProductID,
	Quantity
)
VALUES
(
	@SoldItemID,
	@OrderID,
	@UserID,
	@ProductID,
	@Quantity
)
END
GO
	

CREATE PROCEDURE dbo.Users_Update
    @UserID					uniqueidentifier = NULL,
	@Username				nvarchar(50) = NULL,
	@UserPassword			nvarchar(50) = NULL,
	@FirstName				nvarchar(50) = NULL,
	@LastName				nvarchar(50) = NULL,
	@Address				nvarchar(250) = NULL,
	@City					nvarchar(50) = NULL,
	@Country				nvarchar(50) = NULL,
	@PhoneNumber			nvarchar(50) = NULL,
	@EmailAddress			nvarchar(50) = NULL,
	@UserRole				nvarchar(50) = NULL
AS
BEGIN
    UPDATE dbo.Users
    SET Username = @Username,
		UserPassword = @UserPassword,
		FirstName = @FirstName,
		LastName = @LastName,
		Address = @Address,
		City = @City,
		Country = @Country,
		PhoneNumber = @PhoneNumber,
		EmailAddress = @EmailAddress,
		UserRole = @UserRole
		WHERE UserID=@UserID
END
GO


CREATE PROCEDURE dbo.Images_Update
	@ImageID					uniqueidentifier = NULL,
	@ImageUrl					nvarchar(250) = NULL
	
AS
BEGIN
UPDATE dbo.Images
	SET	ImageUrl = @ImageUrl
		WHERE ImageID=@ImageID
END
GO


CREATE PROCEDURE dbo.Categories_Update
	@CategoryID					uniqueidentifier = NULL,
	@CategoryName				nvarchar(50) = NULL,
	@ImageID					uniqueidentifier = NULL,
	@ParentID					uniqueidentifier = NULL
AS
BEGIN
UPDATE dbo.Categories
	SET	CategoryName = @CategoryName,
		ImageID = @ImageID,
		ParentID = @ParentID
		WHERE CategoryID=@CategoryID
END
GO


CREATE PROCEDURE dbo.Products_Update
	@ProductID					uniqueidentifier = NULL,
	@CategoryID					uniqueidentifier = NULL,
	@ProductName				nvarchar(50) = NULL,
	@ProductDescription			nvarchar(500) = NULL,
	@ImageID					uniqueidentifier = NULL,
	@Price						DECIMAL(19,6) = NULL
AS
BEGIN
UPDATE dbo.Products
	SET	CategoryID = @CategoryID,
		ProductName = @ProductName,
		ProductDescription = @ProductDescription,
		ImageID = @ImageID,
		Price = @Price
		WHERE ProductID=@ProductID
END
GO


CREATE PROCEDURE dbo.ShoppingCart_Update
	@CartID					uniqueidentifier = NULL,
	@UserID					uniqueidentifier = NULL,
	@ProductID				uniqueidentifier = NULL,
	@Quantity				int = NULL
AS
BEGIN
UPDATE dbo.ShoppingCart
	SET	UserID = @UserID,
		ProductID = @ProductID,
		Quantity = @Quantity
		WHERE CartID=@CartID
END
GO


CREATE PROCEDURE dbo.Orders_Update
	@OrderID				uniqueidentifier = NULL,
	@UserID					uniqueidentifier = NULL,
	@BuyerName				nvarchar(50) = NULL,
	@BuyerEmail				nvarchar(50) = NULL,
	@BuyerAddress			nvarchar(250) = NULL,
	@OrderDate				date = NULL
AS
BEGIN
UPDATE dbo.Orders
	SET	UserID = @UserID,
		BuyerName = @BuyerName,
		BuyerEmail = @BuyerEmail,
		BuyerAddress = @BuyerAddress,
		OrderDate = @OrderDate
		WHERE OrderID=@OrderID
END
GO


CREATE PROCEDURE dbo.OrderedProducts_Update
	@SoldItemID				uniqueidentifier = NULL,
	@OrderID				uniqueidentifier = NULL,
	@UserID					uniqueidentifier = NULL,
	@ProductID				uniqueidentifier = NULL,
	@Quantity				int = NULL
AS
BEGIN
UPDATE dbo.OrderedProducts
	SET	OrderID = @OrderID,
		UserID = @UserID,
		ProductID = @ProductID,
		Quantity = @Quantity
		WHERE SoldItemID=@SoldItemID
END
GO


CREATE PROCEDURE dbo.Users_Delete
	@UserID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.Users
    WHERE UserId = @UserID
END
GO


CREATE PROCEDURE dbo.Images_Delete
	@ImageID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.Images
    WHERE ImageId = @ImageID
END
GO


CREATE PROCEDURE dbo.Categories_Delete
	@CategoryID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.Categories
    WHERE CategoryId = @CategoryID
END
GO

	
CREATE PROCEDURE dbo.Products_Delete
	@ProductID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.Products
    WHERE ProductId = @ProductID
END
GO


CREATE PROCEDURE dbo.ShoppingCart_Delete
	@CartID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.ShoppingCart
    WHERE CartId = @CartID
END
GO


CREATE PROCEDURE dbo.Orders_Delete
	@OrderID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.Orders
    WHERE OrderId = @OrderID
END
GO


CREATE PROCEDURE dbo.OrderedProducts_Delete
	@SoldItemID uniqueidentifier = NULL
AS
BEGIN
    DELETE FROM dbo.OrderedProducts
    WHERE SoldItemId = @SoldItemID
END
GO


CREATE PROCEDURE dbo.Users_ReadByID 
	@UserID uniqueidentifier
AS
BEGIN
	SELECT u.UserID,
			u.FirstName,
			u.LastName,
			u.UserRole
	FROM Users u
	WHERE u.UserID = @UserID
END
GO

CREATE PROCEDURE dbo.Images_ReadByID 
	@ImageID uniqueidentifier
AS
BEGIN
	SELECT i.ImageID,
			i.ImageUrl
	FROM Images i
	WHERE i.ImageID = @ImageID
END
GO



CREATE PROCEDURE dbo.Categories_ReadByID 
	@CategoryID uniqueidentifier
AS
BEGIN
	SELECT c.CategoryID,
			c.CategoryName,
			c.ParentID
	FROM Categories c
	WHERE c.CategoryID = @CategoryID
END
GO



CREATE PROCEDURE dbo.Products_ReadByID 
	@ProductID uniqueidentifier
AS
BEGIN
	SELECT p.ProductID,
			p.ProductName,
			p.ProductDescription,
			p.Price
	FROM Products p
	WHERE p.ProductID = @ProductID
END
GO



CREATE PROCEDURE dbo.ShoppingCart_ReadByID 
	@CartID uniqueidentifier
AS
BEGIN
	SELECT s.CartID,
			s.UserID,
			s.ProductID,
			s.Quantity
	FROM ShoppingCart s
	WHERE s.CartID = @CartID
END
GO


CREATE PROCEDURE dbo.Orders_ReadByID 
	@OrderID uniqueidentifier
AS
BEGIN
	SELECT o.OrderID,
			o.BuyerName,
			o.BuyerAddress,
			o.OrderDate
	FROM Orders o
	WHERE o.OrderID = @OrderID
END
GO


CREATE PROCEDURE dbo.OrderedProducts_ReadByID 
	@SoldItemID uniqueidentifier
AS
BEGIN
	SELECT op.SoldItemID,
			op.OrderID,
			op.UserID,
			op.ProductID,
			op.Quantity
	FROM OrderedProducts op
	WHERE op.SoldItemID = @SoldItemID
END
GO

CREATE PROCEDURE dbo.Categories_ReadAll
AS
BEGIN
	SELECT CategoryID,
			CategoryName,
			ImageID,
			ParentID
	FROM Categories
END
GO

CREATE PROCEDURE dbo.Images_ReadAll
AS
BEGIN
	SELECT ImageID,
			ImageUrl
	FROM Images
END
GO

CREATE PROCEDURE dbo.OrderedProducts_ReadAll
AS
BEGIN
	SELECT SoldItemID,
			OrderID,
			UserID,
			ProductID,
			Quantity
	FROM OrderedProducts
END
GO

CREATE PROCEDURE dbo.Orders_ReadAll
AS
BEGIN
	SELECT OrderID
			UserID,
			BuyerName,
			BuyerEmail,
			BuyerAddress,
			OrderDate
	FROM Orders
END
GO

CREATE PROCEDURE dbo.Products_ReadAll
AS
BEGIN
	SELECT ProductID,
			CategoryID,
			ProductName,
			ProductDescription,
			ImageID,
			Price
	FROM Products
END
GO

CREATE PROCEDURE dbo.ShoppingCart_ReadAll
AS
BEGIN
	SELECT CartID,
			UserID,
			ProductID,
			Quantity
	FROM ShoppingCart
END
GO

CREATE PROCEDURE dbo.Users_ReadAll
AS
BEGIN
	SELECT UserID,
			Username,
			UserPassword,
			FirstName,
			LastName,
			Address,
			City,
			Country,
			PhoneNumber,
			EmailAddress,
			UserRole
	FROM Users
END
GO


CREATE VIEW dbo.ProductsAndCategories
AS
SELECT c.CategoryID, c.CategoryName, 
		COUNT(p.ProductID) as NoOfProducts
FROM Categories c
	INNER JOIN Products p ON p.CategoryID= c.CategoryID
GROUP BY c.CategoryID, c.CategoryName
GO


CREATE VIEW dbo.ProductsAndOrderedProducts
AS
SELECT p.ProductID, p.ProductName, 
		COUNT(op.ProductID) as NoOfTimesTheProductWasOrdered
FROM Products p
	LEFT JOIN OrderedProducts op ON p.ProductID= op.ProductID
GROUP BY p.ProductID, p.ProductName
GO



