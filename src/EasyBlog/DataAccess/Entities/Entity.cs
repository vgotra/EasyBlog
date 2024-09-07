namespace EasyBlog.DataAccess.Entities;

public interface IEntity<T> where T : struct
{
    T Id { get; set; }
}