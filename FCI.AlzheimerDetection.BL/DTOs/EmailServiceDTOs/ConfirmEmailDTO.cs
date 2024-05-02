using FluentValidation;

namespace FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;

public sealed record ConfirmEmailDTO
    (string Email,string Token);



public class ConfirmEamilDTOValidator : AbstractValidator<ConfirmEmailDTO>
{
    public ConfirmEamilDTOValidator()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is empty")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(e => e.Token)
            .NotEmpty().WithMessage("Token is empty");
    }
}