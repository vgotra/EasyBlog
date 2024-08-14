# EasyBlog

## EF Core Specific

EF Core Compiled Models can be enabled later with:

```shell
dotnet ef dbcontext optimize -n EasyBlog.DataAccess.Compiledmodels -o DataAccess/CompiledModels
```

At current moment it just slows development
