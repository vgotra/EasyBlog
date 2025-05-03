using System.Text.Json.Serialization;

namespace EasyBlog.Models;

public class PostListPageModel : BasePageModel
{
    public List<PostPageModel> Posts { get; set; } = [];
}

[JsonSerializable(typeof(PostListPageModel))]
partial class PostListPageModelJsonContext : JsonSerializerContext { }

[JsonSerializable(typeof(PostsInputModel))]
partial class PostsInputModelJsonContext : JsonSerializerContext { }