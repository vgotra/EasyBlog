namespace EasyBlog.Models;

public class PostListViewModel : BaseViewModel
{
    public List<PostViewModel> Posts { get; set; } = new();
}