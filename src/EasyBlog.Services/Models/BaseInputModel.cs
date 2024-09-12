namespace EasyBlog.Services.Models;

public abstract record BaseInputModel
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}