namespace EasyBlog.DataAccessLayer.Sqlite.Entities;

[DataRecordMapper]
public partial class TagEntity : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;

    public List<PostEntity> Posts { get; } = [];
}