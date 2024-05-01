using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.DAL.Shared;
using Microsoft.AspNetCore.Http;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IEmailManager
{
    Task SendEmailAsync(string To, string Subject, string Content, IList<IFormFile> attachments = default!);

    Task<Result> ConfirmEmailAsync(string email, string token);

    Task<Result> ForgetPassword(string email);

    Task<Result> ResetPassword(string email, string token, ResetPasswordDTO resetPasswordDTO);

    Task<Result> ChangePassword(string email, ChangePasswordDTO changePasswordDTO);
}