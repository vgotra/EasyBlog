namespace EasyBlog.DataAccess;

public partial class EasyBlogDbContext(DbContextOptions<EasyBlogDbContext> options) : DbContext(options)
{
    public DbSet<PostEntity> Posts { get; set; }
}