Database Configuration:
You can configure connection strings in appsettings.json using the following formats:

SQL Server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<your_password>" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server

MongoDB
mongodb://localhost:27017
SQL Server
Server=localhost;Database=MyDb;User Id=SA;Password=<your_password>;

Edit the file appsettings.json to set connections:
{
  "ConnectionStrings": {
    "SqlServer": "Server=localhost,1433;Database=ProductsDb;User Id=sa;Password=<your_password>;TrustServerCertificate=True;",
    "MongoDb": "mongodb://localhost:27017"
  }
}

>;