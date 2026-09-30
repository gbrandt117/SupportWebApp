# SupportWebApp

## Formål

Formålet med projektet er at lave en simpel Blazor WebApp, hvor man kan oprette supporthenvendelser og gemme dem i Azure Cosmos DB.

Man kan indtaste navn, email, telefon, beskrivelse og kategori. Henvendelserne bliver gemt i Cosmos DB og kan bagefter ses på en liste.

## Teknologier

- .NET 10
- Blazor Web App
- C#
- Azure Cosmos DB
- GitHub

## Cosmos DB

Jeg bruger:

- Database: `IBasSupportDB`
- Container: `ibassupport`
- Partition key: `/category`

En supporthenvendelse indeholder:

- id
- name
- email
- phone
- description
- category
- createdAt

## Opret Cosmos DB

Cosmos DB kan oprettes med Azure CLI:

```bash
az login

az account set --subscription "Azure for Students"

az group create \
  --name IBasSupportRG \
  --location swedencentral

az cosmosdb create \
  --name ibas-db-account-20665 \
  --resource-group IBasSupportRG \
  --locations regionName=Sweden\ Central \
  --enable-free-tier true

az cosmosdb sql database create \
  --account-name ibas-db-account-20665 \
  --resource-group IBasSupportRG \
  --name IBasSupportDB

az cosmosdb sql container create \
  --account-name ibas-db-account-20665 \
  --resource-group IBasSupportRG \
  --database-name IBasSupportDB \
  --name ibassupport \
  --partition-key-path /category