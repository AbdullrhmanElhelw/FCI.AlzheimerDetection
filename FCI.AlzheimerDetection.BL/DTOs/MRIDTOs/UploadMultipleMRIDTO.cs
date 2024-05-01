using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;

public sealed record UploadMultipleMRIDTO
    (IEnumerable<IFormFile> MRIs);

public class UploadMultipleMRIDTOValidator : AbstractValidator<UploadMultipleMRIDTO>
{
    public UploadMultipleMRIDTOValidator()
    {
        RuleFor(x => x.MRIs)
            .NotNull()
            .WithMessage("MRI Images Are Required");

        RuleFor(x => x.MRIs)
            .Must(x => x.Count() > 1)
            .WithMessage("At Least 2 MRI Images Are Required");

        RuleForEach(x => x.MRIs)
            .Must(x => x.Length <= 5 * 1024 * 1024)
            .WithMessage("Image Size Must Be Less Than 5MB");

        RuleForEach(x => x.MRIs)
            .Must(x => x.FileName.EndsWith(".jpg") || x.FileName.EndsWith(".jpeg") || x.FileName.EndsWith(".png"))
            .WithMessage("Image Must Be .jpg, .jpeg or .png");
    }
}