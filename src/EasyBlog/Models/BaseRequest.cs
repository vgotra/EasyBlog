namespace EasyBlog.Models;

public abstract class BaseRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "CreatedDate"; //TODO Check this laetr
    public bool IsDescending { get; set; }
}