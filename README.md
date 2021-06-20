# Claims Audit Function

The Claim Audit Function is the Azure function for Auditing Claims . It is written in C# and runs on .NET Core 5.0. EF Core is used as orm layer.
You need to have vaild azure subcription to run the function

## Set up locally

You will need:

- [.net core 5.0](https://dotnet.microsoft.com/download/dotnet-core/5.0)
- IDE: [Rider](https://www.jetbrains.com/rider/download/), [VS Code](https://code.visualstudio.com/download) or [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- SQL Server either in azure or running locally
- Azure Service Bus and Queue with appropriate access

## Settings
Settings are now being read from local.settings.json.
The important settings

| Variable Name  | Desription |
| ------------- | ------------- |
| SqlConnectionString  | Connection String for Sql Server  |
| ClaimsQueueConnection  | Connection String for azure service bus |

##Migration
Migrations are not part of this project. To get the app running, the following migration needs to be run in the SQL console after creating the db.
# Database
Create
```sql
create database dbname;
```
Drop
```sql
drop database dbname;
```

# Table
Check if not exists and create
```sql
create table ClaimAudits
(
  Id uniqueidentifier,
  ClaimId uniqueidentifier not null,
  Name nvarchar(255),
  Year int,
  Type nvarchar(16),
  DamageCost decimal,
  AuditTime datetime default getdate()
)
  go
```
## Related services

| Service   | Description |
| ------------- | ------------- |
| [Claim Api](https://github.com/chandrashekar-nallamilli/claims-api)  |CRUD Operations for claims  |

