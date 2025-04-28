using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyBlog.Pages;

[AllowAnonymous]
[OutputCache]
class IndexModel(IPostsService postsService) : PageModel
{
    public PostListPageModel Context { get; private set; } = new();

    public async Task OnGetAsync(PostsInputModel? request, CancellationToken cancellationToken = default)
    {
        var postsRequest = request ?? new PostsInputModel();
        Context = await postsService.GetPostsAsync(postsRequest, cancellationToken);
    }
}