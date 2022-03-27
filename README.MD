Projeto de estudo Clean Architecture

ADD MIGRATION
> dotnet ef migrations add InitialMigration -p .\backend\Champs.Infra.Data\ -s .\backend\Champs.API\

RUN MIGRATION
> dotnet ef database update -p .\backend\Champs.Infra.Data\ -s .\backend\Champs.API\