using EasyBlog.Areas.Admin.Validation;
using FluentValidation;

namespace EasyBlog.Configurations;

public static class ConfigurationValidation
{
    public static void ConfigureValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<PostManagementViewModelValidator>();
    }
}