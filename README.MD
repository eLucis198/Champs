# STUDY PROJECT "**CLEAN ARCHITECTURE**" 
### 🧹🧹🧹🏛🏛🏛

***

## RUNNING THE PROJECT

BUILD
> dotnet build .\backend\Champs.sln

RUN
> dotnet run -p .\backend\Champs.API\Champs.API.csproj

***

## DEV TIPS

TRUST HTTPS DEV CERT
> dotnet dev-certs https --trust

ADD MIGRATION
> dotnet ef migrations add InitialMigration -p .\backend\Champs.Infra.Data\ -s .\backend\Champs.API\

RUN MIGRATION
> dotnet ef database update -p .\backend\Champs.Infra.Data\ -s .\backend\Champs.API\

***

## PACKAGES USED

AUTOMAPPER
> dotnet add package AutoMapper --version 11.0.1
> dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 11.0.0

EF CORE
> dotnet add package Microsoft.EntityFrameworkCore --version 5.0.15
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.15
> dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.15
> dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.15

JSON
> dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 5.0.15
