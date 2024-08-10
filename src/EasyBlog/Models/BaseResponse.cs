namespace EasyBlog.Models;

public abstract class BaseResponse
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalRecords { get; set; }
}