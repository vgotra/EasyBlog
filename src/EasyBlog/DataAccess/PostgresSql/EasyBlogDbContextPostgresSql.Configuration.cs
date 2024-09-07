namespace EasyBlog.DataAccess.PostgresSql;

public partial class EasyBlogDbContextPostgresSql
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LanguageEntity>(entity =>
        {
            entity.HasMany(e => e.PostContents).WithOne(e => e.Language);
        });

        modelBuilder.Entity<SettingEntity>();

        modelBuilder.Entity<PostEntity>(entity =>
        {
            entity.HasMany(e => e.Contents).WithOne(e => e.Post);
            entity.HasMany(e => e.Tags).WithMany(e => e.Posts).UsingEntity("PostsTags");
        });

        modelBuilder.Entity<PostContentEntity>(entity =>
        {
            entity.HasOne(e => e.Post).WithMany(e => e.Contents);
            entity.HasOne(e => e.Language).WithMany(e => e.PostContents);
        });

        modelBuilder.Entity<TagEntity>(entity =>
        {
            entity.HasMany(e => e.Posts).WithMany(e => e.Tags).UsingEntity("PostsTags");
        });

        //TODO Add check for providers
        modelBuilder.Model.GetEntityTypes().ToList()
            .ForEach(e => e.GetForeignKeys().ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.ClientCascade));
    }
}