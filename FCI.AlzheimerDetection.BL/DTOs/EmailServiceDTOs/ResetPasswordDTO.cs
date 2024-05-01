using FluentValidation;

namespace FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;

public sealed record ResetPasswordDTO
    (string NewPassword, string ConfirmNewPassword);

public class ResetPasswordDTOValidator : AbstractValidator<ResetPasswordDTO>
{
    public ResetPasswordDTOValidator()
    {
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