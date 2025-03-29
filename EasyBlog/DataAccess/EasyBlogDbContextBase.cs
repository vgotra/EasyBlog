namespace EasyBlog.DataAccess;

public abstract class EasyBlogDbContextBase(DbContextOptions options) : IdentityDbContext(options)
{
    public DbSet<PostEntity> Posts { get; set; }

    public DbSet<TagEntity> Tags { get; set; }
}