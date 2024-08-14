# EasyBlog

## User Secrets for Local Development

Don't forget to set connections string for local development (for SQL Server setup trusted self-signed cert or change connection string)
At Linux: https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-encrypted-connections?view=sql-server-ver16&tabs=client

Example for MS Sql Server:

```shell
dotnet user-secrets set "ConnectionStrings:DefaultConnectionSqlServer" "Server=server.local;Database=EasyBlogDb;MultipleActiveResultSets=true;User Id=sa;Password=***;TrustServerCertificate=true;Encrypt=false"
```

## EF Core Specific

### Migrations for Multiple providers

```shell
dotnet ef migrations add InitialCreate --context EasyBlogDbContextPostgresSql --output-dir Migrations/MigrationsPostgresSql -- --EasyBlog:DatabaseProvider PostgresSql
dotnet ef migrations add InitialCreate --context EasyBlogDbContextSqlServer --output-dir Migrations/MigrationsSqlServer -- --EasyBlog:DatabaseProvider SqlServer
```

### Applying Migrations

```shell
dotnet ef database update --context EasyBlogDbContextPostgresSql -- --EasyBlog:DatabaseProvider PostgresSql
dotnet ef database update --context EasyBlogDbContextSqlServer -- --EasyBlog:DatabaseProvider SqlServer
```

### Compiled Models

EF Core Compiled Models can be enabled later with:

```shell
dotnet ef dbcontext optimize -n EasyBlog.DataAccess.Compiledmodels -o DataAccess/CompiledModels
```

At current moment it just slows development
