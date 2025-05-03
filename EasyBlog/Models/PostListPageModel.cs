namespace EasyBlog.Models;

public class PostListPageModel : BasePageModel
{
    public List<PostPageModel> Posts { get; set; } = [];
}