namespace EasyBlog.Extensions;

public static class ViewModelExtensions
{
    public static string ToContentWithEllipsis(this string content, int defaultCharsCount = 200)
    {
        if (content.Length > defaultCharsCount)
            return new string(content.AsSpan(0, defaultCharsCount)) + "...";

        return content;
    }
}