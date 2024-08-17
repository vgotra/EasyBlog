namespace EasyBlog.DataAccess.SqlServer;

public class IdentityDbContextSqlServer(DbContextOptions<IdentityDbContextSqlServer> options)
    : IdentityDbContext(options);