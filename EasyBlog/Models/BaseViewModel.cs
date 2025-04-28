namespace EasyBlog.Models;

public abstract class BaseViewModel
{
    private const int DefaultPageSize = 10;

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = DefaultPageSize;
    public int TotalRecords { get; set; }

    public bool IsFirstPage => PageNumber == 1;
    public int PreviousPage => PageNumber > 1 ? PageNumber - 1 : 1;
    public int NextPage => PageNumber < PagesCount ? PageNumber + 1 : PagesCount;
    int PagesCount => (int)Math.Ceiling((double)TotalRecords / (PageSize > 0 ? PageSize : DefaultPageSize));
}