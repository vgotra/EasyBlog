namespace EasyBlog.DataAccess.Relational.Entities;

[Table("Posts")]
public class PostEntity : IEntity<Guid>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public bool IsPublished { get; set; }

    [Required, MaxLength(DbDefaults.Post.ReadableUrlMaxLength)]
    public string ReadableUrl { get; set; } = string.Empty;

    public DateTimeOffset? PublishOnDate { get; set; }

    [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTimeOffset CreatedDate { get; set; }

    public List<PostContentEntity> Contents { get; set; } = [];

    public List<TagEntity> Tags { get; } = [];

}