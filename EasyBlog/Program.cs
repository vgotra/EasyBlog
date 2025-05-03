var builder = WebApplication.CreateSlimBuilder(args);
builder.WebHost.UseKestrelHttpsConfiguration();

builder.Services.AddWebEncoders();
builder.Services.Configure<EasyBlogOptions>(builder.Configuration.GetSection(EasyBlogOptions.ConfigurationSectionName));
builder.Services.ConfigureDataAccessSqLite(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
builder.Services.ConfigureCaching();
builder.Services.ConfigureCompression();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions { OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=3600") });
app.UseCors();
app.UseRouting();
app.UseOutputCache();
app.UseLocalization();
app.MapStaticAssets();

// Comment For AOT
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<EasyBlogDbContextSqLite>();
await dbContext.Database.EnsureCreatedAsync();

app.MapGet("/", async (IPostsService postsService, CancellationToken cancellationToken = default) =>
{
    var postsRequest = new PostsInputModel();
    var model = await postsService.GetPostsAsync(postsRequest, cancellationToken);
    return Results.Extensions.RazorSlice<EasyBlog.Slices.Index, PostListPageModel>(model);
});

app.Run();