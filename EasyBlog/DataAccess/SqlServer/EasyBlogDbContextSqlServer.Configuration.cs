namespace EasyBlog.DataAccess.SqlServer;

public partial class EasyBlogDbContextSqlServer
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PostEntity>(entity =>
        {
            entity.ToTable("Posts").HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Content).IsRequired().HasMaxLength(-1);
            entity.Property(e => e.IsPublished).IsRequired();
            entity.Property(e => e.ReadableUrl).IsRequired().HasMaxLength(2048);

            entity.HasMany(e => e.Tags).WithMany(e => e.Posts).UsingEntity("PostsTags");
            ;
        });

        modelBuilder.Entity<TagEntity>(entity =>
        {
            entity.ToTable("Tags").HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.HasIndex(x => x.Name).IsUnique();

            entity.HasMany(e => e.Posts).WithMany(e => e.Tags);
        });

        //TODO Add check for providers
        modelBuilder.Model.GetEntityTypes().ToList()
            .ForEach(e => e.GetForeignKeys().ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.ClientCascade));
    }
}