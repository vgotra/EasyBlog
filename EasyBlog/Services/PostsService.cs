using Microsoft.Data.Sqlite;
using Nanorm;

namespace EasyBlog.Services;

class PostsService(SqliteConnection dbConnection) : IPostsService
{
    public async Task<PostListPageModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var offset = (inputModel.PageNumber - 1) * inputModel.PageSize;
        if (offset < 0) offset = 0;

        var posts = await dbConnection
            .QueryAsync<PostEntity>("SELECT * FROM Posts WHERE IsPublished = 1 ORDER BY CreatedDate DESC LIMIT @PageSize OFFSET @Offset", parameters =>
            {
                parameters.Add(new ("PageSize", inputModel.PageSize));
                parameters.Add(new ("Offset", offset));
            }, cancellationToken)
            .ToListAsync(cancellationToken);
        var total = await dbConnection.QueryAsync<PostEntity>("SELECT * FROM Posts WHERE IsPublished = 1", cancellationToken).CountAsync(cancellationToken);

        return inputModel.ToListViewModel(posts, total);
    }
}