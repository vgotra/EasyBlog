using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBlog.DataAccess.SqlLite;

class TagEntityConfigurationSqLite : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.ToTable("Tags").HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(40);
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasMany(e => e.Posts).WithMany(e => e.Tags);
    }
}