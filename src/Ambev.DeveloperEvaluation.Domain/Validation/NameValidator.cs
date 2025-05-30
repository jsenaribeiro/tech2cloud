using Ambev.DeveloperEvaluation.Domain.Values;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(name => name.FirstName)
            .NotEmpty().WithMessage("The first name cannot be empty.");

        RuleFor(name => name.LastName)
            .NotEmpty().WithMessage("The last name cannot be empty.");
    }
}  