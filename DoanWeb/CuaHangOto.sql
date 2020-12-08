CREATE DATABASE DoanWeb
GO
USE DoanWeb
GO

CREATE TABLE Category
(
	idCategory INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nameCategory NVARCHAR(100) NOT NULL,
	-- có thể mở rộng logo hãng
)
GO
CREATE TABLE Product
(
	idProduct INT IDENTITY(1,1) PRIMARY KEY,
	idCategoryProduct INT NOT NULL REFERENCES Category(idCategory),
	nameProduct NVARCHAR(100) NOT NULL,
	priceProduct DECIMAL(18,0) NOT NULL,
	modelProduct CHAR (20) NOT NULL, --DÒNG XE
	timeProduction CHAR(10) NOT NULL,
	originProduct NVARCHAR(20) NOT NULL, -- XUẤT XỨ
	descriptionProduct NVARCHAR (2000) NOT NULL,
	urlImageProduct NVARCHAR(MAX) NOT NULL,
	color NVARCHAR(20) NOT NULL,
	seat INT NOT NULL,
	fuel NVARCHAR (20) NOT NULL
	 
)


GO
CREATE TABLE RoleAccount(
	idroleAccount INT PRIMARY KEY,
	roleName NVARCHAR(30)
)


CREATE TABLE User_info
(
	idUser INT IDENTITY(1,1) PRIMARY KEY,
	nameUser NVARCHAR(100) NOT NULL,
	birthUser DATETIME,
	sexUser NVARCHAR(5),
	phoneNumberUser CHAR(20) NOT NULL,
	emailUser NVARCHAR(100) NOT NULL,
	addressUser NVARCHAR(100),
	roleAccount INT REFERENCES RoleAccount(idroleAccount)
	-- CÓ THỂ UPDATE AVATAR User 

)
GO



--CREATE TABLE Customer_info
--(
--	idCustomer INT PRIMARY KEY,
--	nameCustomer NVARCHAR(100) NOT NULL,
--	birthCustomer DATETIME,
--	sexCustomer NVARCHAR(5),
--	phoneNumberCustomer CHAR(20) NOT NULL,
--	emailCustomer NVARCHAR(100) NOT NULL,
--	addressCustomer NVARCHAR(100),
--	roleAccount INT REFERENCES RoleAccount(idroleAccount)
	
--)


GO
CREATE TABLE OrderProduct(
	idOrder INT IDENTITY(1,1)PRIMARY KEY,
	idCustomer INT REFERENCES User_info(idUser),
	createdDate DATETIME,
	Decription NVARCHAR(100)
)
GO
CREATE TABLE DetailOrder(
	idProduct INT REFERENCES Product(idProduct),
	idOrder INT REFERENCES OrderProduct(idOrder),
	Quantity INT,
	Price DECIMAL(18,0),
	PRIMARY KEY(idProduct,idOrder)
)
--CREATE TABLE customerConsulting_info
--(
--	idCustomer INT NOT NULL  REFERENCES Customer_info(idCustomer),
--	idStaff INT NOT NULL REFERENCES Staff_info(idStaff),
--	idProduct INT NOT NULL REFERENCES Product(idProduct),
--	textInfo NVARCHAR(500), 
--	primary key (idCustomer,idStaff, idProduct)


--)

GO
CREATE TABLE Account(
	Username CHAR(30)PRIMARY KEY,
	Pass CHAR(30),
	iduser INT REFERENCES User_info(idUser)
	
)

Insert into RoleAccount values('1','Manager')
Insert into RoleAccount values('2','Staff')
Insert into RoleAccount values('3','Customer')

Insert into User_info values('Hoang','2000-01-02','Nam','123','hoang@gmail.com','TP.HCM','2')
Insert into User_info values('Hoang Huy','2000-01-02','Nam','123','hoanghuy@gmail.com','TP.HCM','3')

Insert into Account values('manager','123','1')
Insert into Account values('staff','123','2')
Insert into Account values('customer','123','3')

Insert into Category values('Ford')
Insert into Category values('SUV')

Insert into Product values('1','Ford 1',1000000000,'truck','2020-01-01','China','none','Image/20201118093058-7f09_wm.jpg','white',5,'diesel')




