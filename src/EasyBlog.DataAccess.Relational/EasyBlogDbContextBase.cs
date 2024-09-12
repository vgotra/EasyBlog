using EasyBlog.DataAccess.Relational.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EasyBlog.DataAccess.Relational;

public abstract class EasyBlogDbContextBase(DbContextOptions options) : IdentityDbContext(options)
{
    public DbSet<LanguageEntity> Languages { get; set; }

    public DbSet<SettingEntity> Settings { get; set; }

    public DbSet<PostEntity> Posts { get; set; }

    public DbSet<PostContentEntity> PostContents { get; set; }

    public DbSet<TagEntity> Tags { get; set; }
}