using FluentValidation;
using Movie.Application.Features.Cast.Commands;

namespace Movie.Application.Features.Cast.Validators
{
    public sealed class UpdateCastValidator : AbstractValidator<UpdateCastCommand>
    {
        public UpdateCastValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required")
                .MinimumLength(2).WithMessage("Title must be at least 2 characters")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required")
                .MinimumLength(2).WithMessage("Surname must be at least 2 characters")
                .MaximumLength(50).WithMessage("Surname must not exceed 50 characters");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Image URL is required");
            RuleFor(x => x.Overview).MaximumLength(500).WithMessage("Overview must not exceed 500 characters");
            RuleFor(x => x.Biography).MaximumLength(500).WithMessage("Biography must not exceed 500 characters");
        }
    }
}
