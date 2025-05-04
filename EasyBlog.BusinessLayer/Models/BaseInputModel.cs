namespace EasyBlog.BusinessLayer.Models;

public abstract class BaseInputModel
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}