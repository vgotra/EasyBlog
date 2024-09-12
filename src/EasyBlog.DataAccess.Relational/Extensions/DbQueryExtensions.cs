namespace EasyBlog.DataAccess.Relational.Extensions;

public static class DbQueryExtensions
{
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}