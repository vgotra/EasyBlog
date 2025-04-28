namespace EasyBlog.Models;

class PostListPageModel : BasePageModel
{
    public List<PostPageModel> Posts { get; set; } = new();
}