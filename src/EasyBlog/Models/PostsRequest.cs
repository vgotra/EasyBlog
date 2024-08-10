namespace EasyBlog.Models;

public class PostsRequest : BaseRequest
{
    public string? Search { get; set; }
}