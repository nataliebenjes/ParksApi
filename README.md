# Parks Api

### This is an Api to look up state and national parks.

#### By Natalie Benjes

## Technologies Used

* C#
* .NET
* SQL
* MySQL
* MySQL Workbench
* Entity Framework Core


## How To Run This Project

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c).

### Set Up and Run This Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called `ParksApi`.
3. Within the production directory `ParksApi`, run `dotnet watch run` in the command line to start the project in development mode with a watcher.
4. Open the browser to _https://localhost:7277/
5. Run the command `dotnet ef database update` to generate the database through Entity Framework Core.

#### AppSettings

1. Within the production directory "ParksLookup", create a new file called `appsettings.json`.
2. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. 

# appsettings.json

``` "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=parks_api;uid=[username];pwd=[password];"
}```


### Current bugs:
* when posting a new park, parkId is entered as a number such as "1929", instead of 8. 
* When the command for `dotnet ef database update` is run, the following error is diplayed `A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 40 - Could not open a connection to SQL Server: Could not open a connection to SQL Server)`.

### API Endpoints

#### Edit a Park:
PUT: https://localhost:7277/Parks/id?id=[parkId]

#### Delete a Park:
DELETE: https://localhost:7277/Parks/[parkId]

#### See all parks:
GET: https://localhost:7277/Parks

#### Get a park by id:
GET: https://localhost:7277/Parks/[id]

#### Post a new park:
POST: https://localhost:7277/Parks/


## License
[MIT](https://opensource.org/license/mit)

Copyright (c) 2023 Natalie Benjes


## Current bugs:

when posting a new park, parkId is entered as a number such as "1929", instead of 8.


