using Ambev.DeveloperEvaluation.Domain.Values;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class AddressValidator : AbstractValidator<Address?>
{
    public AddressValidator()
    {
        RuleFor(address => address)
            .NotNull().WithMessage("The address cannot be null.");

        RuleFor(address => address!.Street)
            .NotEmpty().WithMessage("The street cannot be empty.");

        RuleFor(address => address!.City)
            .NotEmpty().WithMessage("The city cannot be empty.");

        RuleFor(address => address!.State)
            .NotEmpty().WithMessage("The state cannot be empty.");

        RuleFor(address => address!.ZipCode)
            .NotEmpty().WithMessage("The zip code cannot be empty.")
            .Matches(@"^\d{5}(-\d{4})?$").WithMessage("The zip code format is not valid.");

        RuleFor(address => address!.Country)
            .NotEmpty().WithMessage("The country cannot be empty.");

        RuleFor(address => address!.Geolocation)
            .NotNull().WithMessage("The geolocation cannot be null.");  
    }
}
