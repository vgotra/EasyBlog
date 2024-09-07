using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBlog.DataAccess.Entities;

[Table("Settings")]
[Index(nameof(Name), IsUnique = true)]
public class SettingEntity : IEntity<Guid>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required, MaxLength(DbDefaults.Setting.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(DbDefaults.Setting.ValueMaxLength)]
    public string Value { get; set; } = string.Empty; //TODO JSON serialization?
}