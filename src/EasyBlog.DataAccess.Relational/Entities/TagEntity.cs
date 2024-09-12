namespace EasyBlog.DataAccess.Relational.Entities;

[Table("Tags")]
public class TagEntity : IEntity<Guid>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required, MaxLength(DbDefaults.Tag.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public List<PostEntity> Posts { get; } = [];
}