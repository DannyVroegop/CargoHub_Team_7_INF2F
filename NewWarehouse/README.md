while in the NEWWAREHOUSE folder:
docker-compose up -d
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
// dotnet ef migrations add InitialCreate
dotnet ef database update