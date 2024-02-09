# SuppliersErp
Simple Suppliers ERP, Back-End in Angular with CRUD on Database.

##Back-End:https://github.com/bpolonifis/SuppliersERP/

##Front-End:https://github.com/bpolonifis/UiSuppliersERP/															

## Install Back-End:
	Download from repo link.
	Run SQL queries from github link.
	Open in vs studio 2022 connect project to DB.
	Download nuget package.
## Close VS Studio, to update nuget.
## Run this in the Package Manager Console: 
	Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
## At Build Menu: 
	Clean Build
	Build
## At Server Explorer Menu:
	Refresh
 	Connect to SuppliersERPAppDB (SuppliersErp)
  	Refresh
 ## Run (presiquisite: Have the SQL DB set and connected)

#  SM SQL  Queries for generating database:
	create database SuppliersDB
## SQL Queries for generating database:
	create database SuppliersDB

## SQL Queries for generating Supplier Caterogy Table:
	use SuppliersDB 
	Create Table dbo.SupplierCategory
	( SupplierCategoryId int identity(1,1) primary key,
	 Category varchar(80));
## SQL Queries for generating Supplier Country Table:
	use SuppliersDB
	Create Table dbo.SupplierCountry
	( SupplierCountryId int identity(1,1) primary key,
	Country varchar(80));												
						
## SQL Queries for generating Supplier  Table:
	
	use SuppliersDB Create Table dbo.Supplier
	( SupplierId int identity(1,1) primary key,
	SupplierCategoryId int references SupplierCategory(SupplierCategoryId),
	SupplierCountryId int references SupplierCountry(SupplierCountryId),
	FullName varchar(80), AFM varchar(9), Address varchar(100),
	Email varchar(50), Phone varchar(10), Active bit );
## SQL Queries for Importing Supplier Country Table values:
	use SuppliersDB												
	Insert into SupplierCategory( Category)
	VALUES ('DefaultCategory');		
## SQL Queries for Importing Supplier Country Table values:
	use SuppliersDB												
	Insert into SupplierCountry( Country)
	VALUES ('Greece');	
## SQL Queries for Importing Supplier  Table values:
	use SuppliersDB												
	Insert into Supplier (FullName, AFM , Address ,
	 Email , Phone , Active)
	VALUES ('Vasilis Polonyfis','011111111','Zografou,Athens','bpolonifis@gmail.complete','6986986989',1);		

Template of implementation 
1.	https://www.youtube.com/watch?v=4a9VxZjnT7E&feature=youtu.be
2.	https://www.youtube.com/@NehanthWorld/playlists


Validations
1.	https://tatief.wordpress.com/2008/12/29/%CE%B1%CE%BB%CE%B3%CF%8C%CF%81%CE%B9%CE%B8%CE%BC%CE%BF%CF%82-%CF%84%CE%BF%CF%85-%CE%B1%CF%86%CE%BC-%CE%AD%CE%BB%CE%B5%CE%B3%CF%87%CE%BF%CF%82-%CE%BF%CF%81%CE%B8%CF%8C%CF%84%CE%B7%CF%84%CE%B1%CF%82/?fbclid=IwAR0NWsgnsJcCoRLyZ4OFl1s0Wy_jLYbE4FY6eRorLO9ro5PpNvDxlLHhpkk

3.	https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api?fbclid=IwAR2xiyL2Sgvj_F6U3EJ9NXYjQeSn7caMpj3_XARk_b4PxvBEVRlOSUBiabk
     

Back End
1.	https://docs.microsoft.com/el-gr/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors
2.	https://www.youtube.com/@NehanthWorld/playlists

