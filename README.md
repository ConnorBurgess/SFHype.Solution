# SFMetroHype.Solution
#### Created By: Connor Burgess 
* * *
<p align="center"><img src="" alt="Sf Finder"
	title="SF Finder" width="350" height="200"></p>

## Description  
SFMetroHype is a RESTful API with full CRUD to track hyped businesses in the San Francisco metro area. Database is pre-seeded with starting shops and ready to be incorporated with a front end. Simple hype system whereby shops gain "hype" according to how user interacts with API (EX: 1 GET request to a shop increases hype rating by .001). Hyped businesses are added to a best shop list which are sorted in descending order by hype rating. API in C#/.Net/ASP.Net Core MVC and Uses Entity Framework Core ORM to abstract SQL interaction. 
* * *

## Hype system v1
### Manipulate a shop's hype in the following ways:
* Get requests to a specific shop (EX: 1 GET request to a shop will increase it's hype rating by .001)
* Comments posted to a shop with "Like" flag set to true (+.003 hype)
* Comments posted to a shop with a "Like" flag set to false (-.003 hype)
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
* Clone Repo from GitHub (Link: )

## Setup 2) Initial Database Setup
* Ensure MySQL is installed [download here](https://www.mysql.com/)
* Ensure MySQL Workbench is installed [download here](https://www.mysql.com/products/workbench/)

## Setup 3) Create appsettings.json
* In root directory of project create a file called "appsettings.json"
* Copy and paste the following into the file:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=sfmetrohype;uid={YOUR UID};pwd={YOUR PWD;"
  }
}
* Input your UID and password from MYSQL database setup and remove curly braces from around pwd/UID. Please note your port may be different.
* If planning to push a project to GitHub, it is advised to avoid revealing sensitive details by [setting up a .gitignore](https://docs.github.com/en/github/using-git/ignoring-files) and ignoring this file.

## Setup 4) Dotnet Setup & Running Program
* Navigate to ./SFMetroHype.Solution/SF inside of the cloned repo and type $"dotnet restore" (no bling / quotes) in terminal
* * From inside ./SFMetroHype.Solution/SF folder type $"dotnet ef database update" (no bling / quotes) in terminal in order to connect migrations to MYSql
* You may utilize MySQL Workbench in order to verify database files if desired. [Check out the MySQL docs](https://dev.mysql.com/doc/workbench/en/wb-sql-editor-navigator.html)
* Run program by inputting$"dotnet run" (no bling / quotes) in terminal while in ./SFMetroHype.Solution/SF folder.

* * *

## To Do:

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