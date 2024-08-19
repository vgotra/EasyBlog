namespace EasyBlog.Models.Posts;

public class PostManagementListViewModel : BaseViewModel
{
    public string? SearchQuery { get; set; }
    public List<PostManagementViewModel> Posts { get; set; } = new();
}