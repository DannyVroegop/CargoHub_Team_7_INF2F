while in the NEWWAREHOUSE folder:
docker-compose up -d
dotnet add package Microsoft.EntityFrameworkCore -v 8.0.10
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL -v 8.0.10
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 8.0.10
// dotnet ef migrations add InitialCreate
dotnet ef database update