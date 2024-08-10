namespace EasyBlog.Extensions;

public static class DbQueryExtensions
{
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, BaseInputModel inputModel) =>
        query.Skip((inputModel.PageNumber - 1) * inputModel.PageSize).Take(inputModel.PageSize);

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, BaseInputModel inputModel)
    {
        if (string.IsNullOrWhiteSpace(inputModel.SortBy))
            return query;

        var property = typeof(T).GetProperty(inputModel.SortBy);
        if (property == null)
            return query;

        var parameter = Expression.Parameter(typeof(T));
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        var resultExp = Expression.Call(typeof(Queryable), inputModel.IsDescending ? "OrderByDescending" : "OrderBy",
            [typeof(T), property.PropertyType], query.Expression, Expression.Quote(orderByExp));

        return query.Provider.CreateQuery<T>(resultExp);
    }
}