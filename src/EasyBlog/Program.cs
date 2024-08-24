using EasyBlog.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EasyBlogOptions>(builder.Configuration.GetSection(EasyBlogOptions.ConfigurationSectionName));

builder.Host.ConfigureServices((context, services) => services.ConfigureServices(context));
builder.Host.ConfigureServices((context, services) => services.ConfigureAuth(context));
builder.Services.ConfigureCors();
builder.Services.ConfigureCaching();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureValidation();

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/http3?view=aspnetcore-8.0#localhost-testing

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    // https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&tabs=visual-studio%2Clinux-sles#http-strict-transport-security-protocol-hsts
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=3600")
});

app.UseCors();
app.UseRouting();
app.UseOutputCache();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("Admin", "{area:exists}/{controller=Management}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Posts}/{action=Index}/{id?}");

app.MapRazorPages();

await app.Services.ConfigureAuthDefaultUsersAsync(); //Add default admin user if needed

app.Run();