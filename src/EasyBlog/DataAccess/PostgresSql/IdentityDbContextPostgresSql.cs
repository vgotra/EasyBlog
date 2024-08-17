namespace EasyBlog.DataAccess.PostgresSql;

public class IdentityDbContextPostgresSql(DbContextOptions<IdentityDbContextPostgresSql> options)
    : IdentityDbContext(options);