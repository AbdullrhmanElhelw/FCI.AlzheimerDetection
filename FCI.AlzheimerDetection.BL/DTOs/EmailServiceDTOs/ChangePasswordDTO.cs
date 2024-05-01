using FluentValidation;

namespace FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;

public sealed record ChangePasswordDTO
    (string OldPassword, string NewPassword, string ConfirmNewPassword);

public class ChangePasswordDTOValidator : AbstractValidator<ChangePasswordDTO>
{
    public ChangePasswordDTOValidator()
    {
        RuleFor(x => x.OldPassword)
            .NotEmpty()
            .WithMessage("Old Password is required");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage("New Password is required");

        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty()
            .WithMessage("Confirm New Password is required");

        RuleFor(x => x.ConfirmNewPassword)
            .Equal(x => x.NewPassword)
            .WithMessage("Password and Confirm Password do not match");
    }
}