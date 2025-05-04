namespace EasyBlog.DataAccessLayer.Sqlite;

public class PostsRepository(SqliteConnection dbConnection) : IPostsRepository
{
    public async Task<Posts> GetPostsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var offset = (pageNumber - 1) * pageSize;
        if (offset < 0) offset = 0;

        var posts = await dbConnection
            .QueryAsync<PostEntity>("SELECT * FROM Posts WHERE IsPublished = 1 ORDER BY CreatedDate DESC LIMIT @PageSize OFFSET @Offset", parameters =>
            {
                parameters.Add(new("PageSize", pageSize));
                parameters.Add(new("Offset", offset));
            }, cancellationToken)
            .ToListAsync(cancellationToken);
        var total = await dbConnection.QueryAsync<PostEntity>("SELECT * FROM Posts WHERE IsPublished = 1", cancellationToken).CountAsync(cancellationToken);

        return new Posts { PostList = posts, Total = total };
    }
}