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