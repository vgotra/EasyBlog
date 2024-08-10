namespace EasyBlog.Models;

public class PostsListViewModel : BaseViewModel
{
    public List<PostViewModel> Posts { get; set; } = new();
}