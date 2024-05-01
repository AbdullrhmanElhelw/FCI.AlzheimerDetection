using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;

public sealed record UploadNormalUserMRI
    (IFormFile MRI);

public class UploadNormalUserMRIValidator : AbstractValidator<UploadNormalUserMRI>
{
    public UploadNormalUserMRIValidator()
    {
        RuleFor(x => x.MRI)
            .NotNull()
            .WithMessage("MRI is required");

        RuleFor(x => x.MRI.Length)
            .LessThanOrEqualTo(5 * 1024 * 1024)
            .WithMessage("MRI size should be less than 5MB");

        RuleFor(x => x.MRI.FileName)
            .Must(x => x.EndsWith(".jpg") || x.EndsWith(".jpeg") || x.EndsWith(".png"))
            .WithMessage("MRI should be in jpg, jpeg, png format");
    }
}