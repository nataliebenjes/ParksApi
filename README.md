follows tutorial that uses alternative database engine. Find out which one to use and configure appsettings.json file appropriately 

appsettings.json

Current bugs:
when posting a new park, parkId is entered as a number such as "1929", instead of 8.

Endpoints

Edit a Park:
PUT: https://localhost:7277/Parks/id?id=[parkId]

Delete a Park:
DELETE: https://localhost:7277/Parks/[parkId]

See all parks:
GET: https://localhost:7277/Parks

Get a park by id:
GET: https://localhost:7277/Parks/[id]

Post a new park:
POST: https://localhost:7277/Parks/





``` "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=api_setup_lesson;uid=[username];pwd=[password];"
}```