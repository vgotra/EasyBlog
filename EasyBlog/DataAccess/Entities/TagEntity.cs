using Nanorm;

namespace EasyBlog.DataAccess.Entities;

[DataRecordMapper]
partial class TagEntity : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;

    public List<PostEntity> Posts { get; } = [];
}