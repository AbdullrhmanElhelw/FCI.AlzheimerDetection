using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;

public sealed record CreateMRIDTO
{
    public IFormFile MRI { get; init; }
}

public class CreateMRIDTOValidator : AbstractValidator<CreateMRIDTO>
{
    public CreateMRIDTOValidator()
    {
        RuleFor(x => x.MRI)
            .NotNull()
            .WithMessage("MRI is Required");

        RuleFor(x => x.MRI.ContentType)
            .Must(x => x == "image/jpeg" || x == "image/png")
            .WithMessage("Invalid Image Type Image Type Must be Png or Jpeg");

        RuleFor(x => x.MRI.Length)
            .LessThanOrEqualTo(5 * 1024 * 1024)
            .WithMessage("Image Size Must Be Less Than 5MB");
    }
}