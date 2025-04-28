namespace EasyBlog.DataAccess.Entities;

class PostEntity : Entity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public string ReadableUrl { get; set; } = string.Empty;
    public DateTime? PublishOnDate { get; set; }
    public DateTime CreatedDate { get; set; } // better to set value in method to avoid bugs

    public List<TagEntity> Tags { get; } = [];
}