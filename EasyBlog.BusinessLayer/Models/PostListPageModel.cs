namespace EasyBlog.BusinessLayer.Models;

public class PostListPageModel : BasePageModel
{
    public List<PostPageModel> Posts { get; set; } = [];
}