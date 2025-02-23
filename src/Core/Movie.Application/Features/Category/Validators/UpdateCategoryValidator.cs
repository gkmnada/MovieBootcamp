using FluentValidation;
using Movie.Application.Features.Category.Commands;

namespace Movie.Application.Features.Category.Validators
{
    public sealed class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
        }
    }
}
