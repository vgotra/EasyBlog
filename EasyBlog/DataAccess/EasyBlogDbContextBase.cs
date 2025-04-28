namespace EasyBlog.DataAccess;

public abstract class EasyBlogDbContextBase(DbContextOptions options) : DbContext(options)
{
    public required DbSet<PostEntity> Posts { get; set; }

    public required DbSet<TagEntity> Tags { get; set; }
}