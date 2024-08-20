namespace EasyBlog.Extensions;

public static class DbQueryExtensions
{
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, BaseInputModel inputModel)
    {
        return query.Skip((inputModel.PageNumber - 1) * inputModel.PageSize).Take(inputModel.PageSize);
    }
}