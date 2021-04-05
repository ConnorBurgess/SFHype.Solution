# SFHype.Solution
#### Created By: Connor Burgess 
* * *
<p align="center"><img src="" alt="Sf Hype"
	title="SF Hype" width="350" height="200"></p>

* API is WIP

## Description  
SFHype is a RESTful API with full CRUD to track hyped shops, restaurants, and other spots around the San Francisco metro area. Database is pre-seeded with starting shops and ready to be incorporated with a front end. Utilizes system whereby shops gain "hype" according to how user interacts with API (see below for examples). Shops are added to "featured shop" list which are sorted in descending order according to hype rating. API created using C#/.Net and Uses Entity Framework Core ORM to abstract SQL interaction. 
* * *

## Hype system
### Manipulate a shop's hype in the following ways:
* Get requests to a specific shop (EX: 1 GET request to a shop will increase it's hype rating (.001 - HS, where HS = hype scale))
* Remarks posted to a shop tagged with a "Like" (+.003 - HS*3)
* Remarks posted to a shop tagged with a "Disike" (-.003 - HS*3),
* Hype scale starts at .001 and decrements with each interaction to API. Current scale is implemented in conjunction with client IP check is set to roll over daily using UTC DateTime. API by default will no longer increment hype for a shop until the day has elapsed after 1000 interactions with a specific shop. This is accomplished by decreasing scale by .000001 with each hype-generating interaction. Scale and decrementer may be adjusted as needed in Shop.cs (EX: Decrementer set at .0000005 allows for 2000 hype-generating interactions with API). 

## Technologies used
* C#
* .Net v5.0
* JSon.net
* RestSharp
* Swagger
* Entity Framework Core
* ASP.NET Core MVC
* ASP.NET Core Identity
* MySQL
* MySQL Workbench

* * *
## Setup 1) Initial Setup
* Ensure .Net v5.0 Core is installed: [download here](https://dotnet.microsoft.com/download/dotnet/5.0)
* Ensure dotnet script is installed: [instructions here](https://github.com/filipw/dotnet-script)
* Clone Repo from GitHub (Link: https://github.com/ConnorBurgess/SFHype.Solution.git)
* Optional: [Install Postman](https://www.postman.com/)

## Setup 2) Initial Database Setup
* Ensure MySQL is installed [download here](https://www.mysql.com/)
* Ensure MySQL Workbench is installed [download here](https://www.mysql.com/products/workbench/)

## Setup 3) Create appsettings.json
* In root directory of project create a file called "appsettings.json"
* Copy and paste the following into the file:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=sfhype;uid={YOUR UID};pwd={YOUR PWD;"
  }
}
* Input your UID and password from MYSQL database setup above and remove curly braces from around pwd/UID. Please note your port may be different.
* If planning to push a project to GitHub, it is advised to avoid revealing sensitive details by [setting up a .gitignore](https://docs.github.com/en/github/using-git/ignoring-files) and ignoring this file.


## Setup 4) Dotnet Setup & Running Program
* Navigate to ./SFMetroHype.Solution/SF inside of the cloned repo and type $"dotnet restore" (no bling / quotes) in terminal
* * From inside ./SFMetroHype.Solution/SF folder type $"dotnet ef database update" (no bling / quotes) in terminal in order to connect migrations to MYSql
* You may utilize MySQL Workbench in order to verify database files if desired. [Check out the MySQL docs](https://dev.mysql.com/doc/workbench/en/wb-sql-editor-navigator.html)
* Run program by inputting$"dotnet run" (no bling / quotes) in terminal while in ./SFMetroHype.Solution/SF folder.
* Please view CRUD functionality by using Swagger documentation (navigate to Localhost:5000 in browser URL). Requests to API may be sent using Postman or through Swagger.
* * *

## To Do:
* Switch to 24 hour elapsing for resetting hype scale / IPLog as opposed to day change
* Implement Remarks controller / access modifier adjustments
## Resources Used:


## Additional comments:
* Created on 4/02/21  
* * *

## License:
> *&copy; Connor Burgess, 2021*

Licensed under [MIT license](https://mit-license.org/)

* * *

## Contact Information
_Connor Burgess: [Email](connorburgesscodes@gmail.com)_