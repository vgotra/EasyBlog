namespace EasyBlog.DataAccess.SqlLite;

partial class EasyBlogDbContextSqLite
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostEntityConfigurationSqLite());
        modelBuilder.ApplyConfiguration(new TagEntityConfigurationSqLite());
        
        //TODO Add check for providers
        modelBuilder.Model.GetEntityTypes().ToList()
            .ForEach(e => e.GetForeignKeys().ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.ClientCascade));
    }
}