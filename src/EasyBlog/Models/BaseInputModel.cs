namespace EasyBlog.Models;

public abstract class BaseInputModel
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "CreatedDate";
    public bool IsDescending { get; set; }
}