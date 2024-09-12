namespace EasyBlog.Services.Common.Models;

public record PostListViewModel : BaseViewModel
{
    public List<PostViewModel> Posts { get; set; } = new();
}