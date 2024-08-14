# EasyBlog

## EF Core Specific

### Migrations for Multiple providers

```shell
dotnet ef migrations add InitialCreate --context EasyBlogDbContextPostgresSql --output-dir Migrations/MigrationsPostgresSql -- --EasyBlog:DatabaseProvider PostgresSql
dotnet ef migrations add InitialCreate --context EasyBlogDbContextSqlServer --output-dir Migrations/MigrationsSqlServer -- --EasyBlog:DatabaseProvider SqlServer
```

### Compiled Models

EF Core Compiled Models can be enabled later with:

```shell
dotnet ef dbcontext optimize -n EasyBlog.DataAccess.Compiledmodels -o DataAccess/CompiledModels
```

At current moment it just slows development
