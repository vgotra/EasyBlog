namespace EasyBlog.Models;

public class PostsResponse : BaseResponse
{
    public List<PostResponse> Posts { get; set; } = new();
}