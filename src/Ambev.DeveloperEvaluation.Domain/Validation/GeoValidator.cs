using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Values;

public class GeoValidator : AbstractValidator<Geolocation>
{
    public GeoValidator()
    {
        RuleFor(geo => geo.Latitude).NotEmpty().WithMessage("Latitude cannot be empty.");
        RuleFor(geo => geo.Longitude).NotEmpty().WithMessage("Longitude cannot be empty.");
    }
}