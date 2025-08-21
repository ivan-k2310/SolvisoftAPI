# SolvisoftAPI

This project is the Back-end for an assesment. this API is made in C# with use of the enity framework. it has 4 end-points, 2 GETs and 2 POSTs. these are called from the Front-end (https://github.com/ivan-k2310/Front-end-Solvisoft-assesment). It also has a migration that creates a database with the needed data. when you run the application make sure to look at the logs to see on what ports the api is listening on. If the ports are different change it in the code appropriately.  

-To run this on your machine proceed with these steps:

Make sure you have the following installed:

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)


Clone this github repo (https://github.com/ivan-k2310/SolvisoftAPI)
Use the following commands:
  ```bash
  cd Front-end-Solvisoft-assesment
  ```
Edit appsettings.json and update the connection string for your database:
  ```json
  "ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
  ```
Apply Migrations:
  ```bash
    Update-Database
  ```
Than run the application
