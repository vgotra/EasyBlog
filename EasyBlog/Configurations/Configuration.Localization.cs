namespace EasyBlog.Configurations;

public static class ConfigurationLocalization
{
    public static void UseLocalization(this IApplicationBuilder app)
    {
        //TODO Add all supported cultures (a lot of them, maybe in alphabetical order for easy updating or checking)
        //A lot of them cultures: EU, UK, USA, Japan, Israel, South Korea, etc, maybe in alphabet order for easy updating
        var supportedCultures = new[] { new CultureInfo("uk-UA") };
        
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(supportedCultures.First().Name), //TODO Add possibility to configure in appsettings or db
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        //TODO Check all other related to localization
    }
}