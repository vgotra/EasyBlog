using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EasyBlog.Configurations;

public static class ConfigurationAuthDefaultUsers
{
    public static async Task ConfigureAuthDefaultUsersAsync(this IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<IOptions<EasyBlogOptions>>();
        var defaultAuth = options.Value.DefaultAuth;
        if (!defaultAuth.CreateDefaultUser)
            return;

        await CreateRoles(serviceProvider);
        await CreateAdminUser(serviceProvider, defaultAuth);
    }

    private static async Task CreateAdminUser(IServiceProvider serviceProvider, DefaultAuthOptions options)
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var adminUser = new IdentityUser { UserName = options.DefaultUserName, Email = options.DefaultUserEmail };
        var user = await userManager.FindByEmailAsync(options.DefaultUserEmail);
        if (user != null)
            return;

        var createPowerUser = await userManager.CreateAsync(adminUser, options.DefaultUserPassword);
        if (createPowerUser.Succeeded)
            await userManager.AddToRoleAsync(adminUser, Defaults.Auth.DefaultAdminRoleName);
    }

    private static async Task CreateRoles(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var roleExist = await roleManager.RoleExistsAsync(Defaults.Auth.DefaultAdminRoleName);
        if (!roleExist)
            await roleManager.CreateAsync(new IdentityRole(Defaults.Auth.DefaultAdminRoleName));
    }
}