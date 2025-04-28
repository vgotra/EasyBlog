namespace EasyBlog.DataAccess.Entities;

class TagEntity : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;

    public List<PostEntity> Posts { get; } = [];
}