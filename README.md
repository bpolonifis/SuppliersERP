# SuppliersErp
A project which has a CRUD operation (based on ASP.NET Web Api 2) for Suppliers and Supplier Categories and custom-made validations which front-end design was based in Angular 10 and Bootstrap 4 (https://github.com/apalasopoulos1986/erpuserinterface). 
It held the principle of Separation of Concern because the application is 
consisted of 3 layers (Database, Web Api 2 design and UI).

Scripts for generating database

create database SuppliersDB

//////////

use SuppliersDB
Create Table dbo.SupplierCategory(
SupplierCategoryId int identity(1,1) primary key,
Category varchar(80));

/////////

use SuppliersDB
Create Table dbo.Supplier (
SupplierId int identity(1,1) primary key,
SupplierCategoryId int references SupplierCategory(SupplierCategoryId),
FullName varchar(50),
AFM varchar(9),
Address varchar(100),
Email varchar(80),
Phone varchar(80),
Active bit
);

Template of implementation 
1.	https://www.youtube.com/watch?v=4a9VxZjnT7E&feature=youtu.be


Validations
1.	https://tatief.wordpress.com/2008/12/29/%CE%B1%CE%BB%CE%B3%CF%8C%CF%81%CE%B9%CE%B8%CE%BC%CE%BF%CF%82-%CF%84%CE%BF%CF%85-%CE%B1%CF%86%CE%BC-%CE%AD%CE%BB%CE%B5%CE%B3%CF%87%CE%BF%CF%82-%CE%BF%CF%81%CE%B8%CF%8C%CF%84%CE%B7%CF%84%CE%B1%CF%82/?fbclid=IwAR0NWsgnsJcCoRLyZ4OFl1s0Wy_jLYbE4FY6eRorLO9ro5PpNvDxlLHhpkk
2.	http://blog.rogatnev.net/posts/2020/02/ASP-WebApi-Model-validation.html?fbclid=IwAR2xiyL2Sgvj_F6U3EJ9NXYjQeSn7caMpj3_XARk_b4PxvBEVRlOSUBiabk
3.	https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api?fbclid=IwAR2xiyL2Sgvj_F6U3EJ9NXYjQeSn7caMpj3_XARk_b4PxvBEVRlOSUBiabk
     
  Front End
1.	https://getbootstrap.com/docs/4.5/components/modal/
2.	https://icons.getbootstrap.com/
3.	https://icons.getbootstrap.com/icons/pencil-square/
4.	https://icons.getbootstrap.com/icons/trash-fill/
5.	https://getbootstrap.com/docs/4.0/components/forms/
6.	https://stackoverflow.com/questions/45710983/boolean-variable-initialization-used-in-several-components


Back End
1.	https://docs.microsoft.com/el-gr/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors

