using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBlog.DataAccess.Entities;

[Table("PostContents")]
public class PostContentEntity : IEntity<Guid>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required, MaxLength(DbDefaults.PostContent.TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(DbDefaults.PostContent.ContentMaxLength)]
    public string Content { get; set; } = string.Empty;

    public PostEntity Post { get; set; } = new();

    public LanguageEntity Language { get; set; } = new();
}