namespace EasyBlog.Extensions;

public static class DateTimeExtensions
{
    public static DateTimeOffset ToLocalTimeBasedOnCulture(this DateTimeOffset dateTime)
    {
        var timeZoneId = CultureInfo.CurrentCulture.Name switch
        {
            "uk-UA" => "FLE Standard Time", // Ukrainian time zone
            _ => TimeZoneInfo.Local.Id
        };

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTime(dateTime, timeZone);
    }
}