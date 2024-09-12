namespace EasyBlog.Areas.Admin.Models;

public record PostManagementListViewModel : BaseViewModel
{
    public string? SearchQuery { get; set; }

    public List<PostManagementViewModel> Posts { get; set; } = new();
}