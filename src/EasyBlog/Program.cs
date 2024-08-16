using EasyBlog.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices((context, services) => services.ConfigureServices(context));
builder.Services.ConfigureCors();
builder.Services.ConfigureCaching();
builder.Services.AddControllersWithViews();

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/http3?view=aspnetcore-8.0#localhost-testing

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
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
app.UseResponseCompression();
app.UseRouting();
app.UseOutputCache();
app.UseAuthorization();

app.MapControllerRoute(name: "Admin", pattern: "{area:exists}/{controller=Management}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Posts}/{action=Index}/{id?}");

app.Run();