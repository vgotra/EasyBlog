using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBlog.DataAccess.SqlLite;

class PostEntityConfigurationSqLite : IEntityTypeConfiguration<PostEntity>
{
    public void Configure(EntityTypeBuilder<PostEntity> builder)
    {
        builder.ToTable("Posts").HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(1000);
        builder.Property(e => e.Content).IsRequired().HasMaxLength(-1);
        builder.Property(e => e.IsPublished).IsRequired();
        builder.Property(e => e.ReadableUrl).IsRequired().HasMaxLength(2048);
        builder.Property(e => e.CreatedDate).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(e => e.Tags).WithMany(e => e.Posts).UsingEntity("PostsTags");
    }
}