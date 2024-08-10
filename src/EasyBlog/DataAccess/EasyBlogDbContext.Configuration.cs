namespace EasyBlog.DataAccess;

public partial class EasyBlogDbContext
{
    private const string DbSchemaName = "EasyBlog";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostEntity>(entity =>
        {
            entity.ToTable("Posts").HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Content).IsRequired().HasMaxLength(-1);
            entity.Property(e => e.IsPublished).IsRequired();
            entity.Property(e => e.ReadableUrl).IsRequired().HasMaxLength(2048);
        });

        //TODO Add check for providers
        modelBuilder.Model.GetEntityTypes().ToList()
            .ForEach(e =>
            {
                e.SetSchema(DbSchemaName);
                e.GetForeignKeys().ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.NoAction);
            });
    }
}