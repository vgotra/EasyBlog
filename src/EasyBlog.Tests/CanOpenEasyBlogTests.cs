namespace EasyBlog.Tests;

[TestClass]
public class CanOpenEasyBlogTests : PageTestBase
{
    [TestMethod]
    [Ignore]
    public async Task CanOpenHomePage()
    {
        await Page.GotoAsync(ServerUri);
        await Page.GetByRole(AriaRole.Link, new() { Name = "🏠 Easy Blog" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Home Page - EasyBlog");
    }
}