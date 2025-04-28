namespace EasyBlog.Tests.UI;

[Collection("WebServerCollection")]
public class MainPageTests
{
    [Fact]
    public async Task MainPage_HasExpectedTitle()
    {
        using var playwright = await Playwright.CreateAsync();
        var browserOptions = new BrowserTypeLaunchOptions { Headless = true };
        await using var browser = await playwright.Chromium.LaunchAsync(browserOptions);
        var bowserContextOptions = new BrowserNewContextOptions { IgnoreHTTPSErrors = true };
        await using var browserContext = await browser.NewContextAsync(bowserContextOptions);
        var page = await browserContext.NewPageAsync();

        await page.GotoAsync("http://localhost:5142/"); // Possible automatic redirection to https port
        var title = await page.TitleAsync();

        Assert.Equal("Home Page - EasyBlog", title);
    }
}