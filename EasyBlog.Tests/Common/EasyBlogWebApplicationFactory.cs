using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyBlog.Tests.Common;

/// <remarks>
/// https://danieldonbavand.com/2022/06/13/using-playwright-with-the-webapplicationfactory-to-test-a-blazor-application/
/// </remarks>
public class EasyBlogWebApplicationFactory(string serverUri) : WebApplicationFactory<Program>
{
    private bool _disposed;
    private IHost? _host;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureKestrel(serverOptions => serverOptions.ConfigureHttpsDefaults(httpsOptions => httpsOptions.ServerCertificate = new X509Certificate2("localhost-dev.pfx")));
        builder.UseUrls(serverUri);
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        //TODO Add InMemory Database
        var testHost = builder.Build();
        builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());

        _host = builder.Build();
        _host.Start();

        var server = _host.Services.GetRequiredService<IServer>();
        var addresses = server.Features.Get<IServerAddressesFeature>();

        ClientOptions.BaseAddress = addresses!.Addresses.Select(x => new Uri(x)).Last();

        testHost.Start();
        return testHost;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (_disposed) return;
        if (!disposing) return;

        _host?.Dispose();
        _disposed = true;
    }
}