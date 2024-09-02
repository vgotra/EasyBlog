// ReSharper disable ClassNeverInstantiated.Global

using FluentValidation;

namespace EasyBlog.Areas.Admin.Validation;

public class PostManagementViewModelValidator : AbstractValidator<PostManagementViewModel>
{
    public PostManagementViewModelValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(1000).WithMessage("Title cannot exceed 1000 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.ReadableUrl)
            .NotEmpty().WithMessage("Readable URL is required.")
            .MaximumLength(2048).WithMessage("Readable URL cannot exceed 2048 characters.")
            .Matches(@"^[a-zA-Z0-9\-]+$").WithMessage("Readable URL can only contain letters, numbers, and hyphens.");

        RuleFor(x => x.PublishOnDate)
            .GreaterThan(DateTimeOffset.UtcNow).When(x => !x.IsPublished)
            .WithMessage("Publish On Date must be in the future.");
    }
}