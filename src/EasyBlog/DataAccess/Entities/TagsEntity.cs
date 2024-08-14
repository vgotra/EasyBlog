namespace EasyBlog.DataAccess.Entities;

public class TagsEntity : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;

    public List<PostEntity> Posts { get; } = [];
}