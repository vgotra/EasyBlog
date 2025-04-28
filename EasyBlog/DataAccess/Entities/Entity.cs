namespace EasyBlog.DataAccess.Entities;

abstract class Entity<T> where T : struct
{
    public T Id { get; set; } = default;
}