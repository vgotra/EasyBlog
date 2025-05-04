namespace EasyBlog.DataAccessLayer.Sqlite.Entities;

public abstract class Entity<T> where T : struct
{
    public T Id { get; set; } = default;
}