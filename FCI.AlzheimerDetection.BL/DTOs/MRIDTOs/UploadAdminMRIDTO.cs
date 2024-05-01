using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;

public class UploadAdminMRIDTO
{
    public UploadAdminMRIDTO(IFormFile mri)
    {
        MRI = mri;
    }

    public IFormFile MRI { get; set; }
}

public class UploadAdminMRIDTOValidator : AbstractValidator<UploadAdminMRIDTO>
{
    public UploadAdminMRIDTOValidator()
    {
        RuleFor(x => x.MRI)
            .NotNull()
            .WithMessage("MRI Image Is Required");

        RuleFor(x => x.MRI.FileName)
            .Must(x => x.EndsWith(".jpg") || x.EndsWith(".jpeg") || x.EndsWith(".png"))
            .WithMessage("Image Must Be .jpg, .jpeg or .png");

        RuleFor(x => x.MRI.Length)
            .LessThanOrEqualTo(5 * 1024 * 1024)
            .WithMessage("Image Size Must Be Less Than 5MB");
    }
}