namespace EasyBlog.BusinessLayer;

public class PostsService(IPostsRepository postsRepository) : IPostsService
{
    public async Task<PostListPageModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await postsRepository.GetPostsAsync(inputModel.PageNumber, inputModel.PageSize, cancellationToken); //TODO Make some common models for DAL
        return inputModel.ToListViewModel(posts);
    }
}