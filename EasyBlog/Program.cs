var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EasyBlogOptions>(builder.Configuration.GetSection(EasyBlogOptions.ConfigurationSectionName));
builder.Host.ConfigureServices((context, services) => services.ConfigureServices(context));
builder.Services.ConfigureCors();
builder.Services.ConfigureCaching();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
app.UseLocalization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<EasyBlogDbContextSqLite>();
dbContext.Database.EnsureCreated();

app.Run();