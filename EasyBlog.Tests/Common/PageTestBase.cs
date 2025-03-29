namespace EasyBlog.Tests.Common;

public class PageTestBase : PageTest
{
    private static EasyBlogWebApplicationFactory? _factory;
    private static HttpClient? _client;

    protected static string ServerUri { get; set; } = "https://localhost:7149";

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
        _factory = new EasyBlogWebApplicationFactory(ServerUri);
        _client = _factory.CreateDefaultClient();
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        _client?.Dispose();
        _factory?.Dispose();
    }

    public override BrowserNewContextOptions ContextOptions()
    {
        var contextOptions = base.ContextOptions();
        contextOptions.IgnoreHTTPSErrors = true;
        return contextOptions;
    }
}