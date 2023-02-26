# Backend

## Run locally

1. Install [MS SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019).
2. Clone the repository.
3. Open the solution in Visual Studio.
4. Set the startup project to `IT-Community.Server`.
5. Right-click on the `IT-Community.Server` project > Select `Manage User Secrets` > Configure your connection string in `secrets.json`. For example:
   
   ```json
   {
     "ConnectionStrings": {
       "ITCommunityConnection": "Server=.;Database=ITCommunityDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
     }
   }
   ```

6. Start MS SQL Server Management Studio.
7. Run the following command in the Package Manager Console to create the database:
   
   ```powershell
   Update-Database
   ```

8. Press F5 or click the "Start" button.
9. Open https://localhost:7230/swagger/index.html

## Tech stack

- .Net 6
- ASP.NET Core
- WebAPI
- Entity Framework
- MS SQL Server
