namespace EasyBlog.Models.Posts;

public class PostListViewModel : BaseViewModel
{
    public List<PostViewModel> Posts { get; set; } = new();
}