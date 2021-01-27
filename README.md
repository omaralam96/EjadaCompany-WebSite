# EjadaCompany Preparation Assignment


 This Assignment is for implementation website that showing all Employees exist in Database and apply the following options:

  - Add New Employee
  - Edit Existing Employee
  - Delete Existing Employee

# Structure

  - Project is built following Razor Page Architecture that groups files by purpose, A single page not only has a Razor view but also a tightly-integrated "code-behind" class which defines the functionality for that page.
  - Conversely, MVC In MVC, functionality is grouped by function, Controllers contain actions, models contain data, and views contain display information. Each of these are put in their own dedicated folders



# Tools Used In Project
     Visual Studio 2019 “C# ASP.Net Core3.1”
     SQL Server
     Microsoft SQL Server Manager “MSSM”

# Packages
All Packeges must be installed in Visual studio from "Tool" -> NuGets Package Manager -> Manage NuGets Package for solution.
All Packages have to be of [Version 3.1][df1] , as the used ASP.Net was of [ Core 3.1 ][df1] 
| Package Name | Usage |
| ------ | ------ |
|  Microsoft .ASPNetCore.MVC.RAZOR.RuntimeCompilation | For Immediate runtime changes in the website with no need for restarting the application |
|  Microsoft.EntityFrameworkCore | Object database Mapper |
|  Microsoft.EntityFrameworkCore.SqlServer | As We Use Sql Server |
| Microsoft.EntityFrameworkCore.Tools | For Migration to Database |


# Note:

Make Sure all packages are installed, and change server name in [appsetting.jason] Match your sql-server name.
By default the name will be.....(LocalDb)\\MSSQLLocalDB
so all you need to change the below line
"ConnectionStrings": {
    "DefaultConnection": "`${Server=DESKTOP-N7251L9}`;Database=EjadaCompany;Trusted_Connection=True;MultipleActiveResultSets=True"
  },
  
to

"ConnectionStrings": {
 "DefaultConnection": "Server=(LocalDb)\\\MSSQLLocalDB;Database=EjadaCompany;Trusted_Connection=True;MultipleActiveResultSets=True"
 },
 
