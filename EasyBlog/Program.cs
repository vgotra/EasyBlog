var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EasyBlogOptions>(builder.Configuration.GetSection(EasyBlogOptions.ConfigurationSectionName));

builder.Host.ConfigureServices((context, services) => services.ConfigureServices(context));
builder.Services.ConfigureCors();
builder.Services.ConfigureCaching();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

app.MapControllerRoute("Admin", "{area:exists}/{controller=Management}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Posts}/{action=Index}/{id?}");

app.MapRazorPages();
app.UseLocalization();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<EasyBlogDbContextSqLite>();
dbContext.Database.EnsureCreated();

app.Run();

partial class Program { }