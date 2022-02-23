BikesKart

Bike Inventory App (.Net Core 6.0 CRUD WebAPIs using Entity Framework Core) 


This project is created using DB First Entity Framework Core approach.

Steps : 
1. Run SQL scripts under "DB creation scripts" folder, for creating database, schema & tables, and to insert dummy data on all tables

2. Creating Models :
Now it’s time to create the EF model based on our existing database.

Go to Tools –> NuGet Package Manager –> Package Manager Console

Install following packages :
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.SqlServer

Then, we can create the models from the existing database using Scaffold-DbContext command:
Scaffold-DbContext "Server=.\SQLEXPRESS;Database=BikeStores;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Replace DB connection string with your own connection string

This will generate Model classes and a DBContext class (BikeStoresContext.cs)

3. Create controllers
We can generate respective controller classes, using scaffolding
Just create a Controllers folder, right click on it and click Add -> New Scaffolded Item..
then choose Model and Context class and press OK, this will generate controller class with all CRUD operations
