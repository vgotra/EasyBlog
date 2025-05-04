namespace EasyBlog.DataAccessLayer.Sqlite;

public record Posts
{
    public List<PostEntity> PostList { get; set; } = []; //TODO Improve
    public int Total { get; set; }
}