using Microsoft.Data.Sqlite;
using Nanorm;

namespace EasyBlog.Services;

class TagsService(SqliteConnection dbConnection) : ITagsService
{
    public async Task<List<TagPageModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tags = await dbConnection.QueryAsync<TagEntity>("SELECT * FROM Tags", cancellationToken).ToListAsync(cancellationToken);
        return tags.Select(x => x.ToModel()).ToList()!;
    }
}