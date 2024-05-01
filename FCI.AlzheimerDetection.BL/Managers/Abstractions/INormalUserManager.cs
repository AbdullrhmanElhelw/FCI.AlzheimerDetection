using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.BL.DTOs.NormalUserDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface INormalUserManager
{
    Task<Result> Register(RegisterNormalUserDTO registerDTO);

    Task<Result> Login(LoginNormalUserDTO loginDTO);

    Task<Result> ConfirmEmail(string email, string token);

    Task<Result> ForgetPassword(string email);

    Task<Result> ResetPassword(string email, string token, ResetPasswordDTO resetPasswordDTO);

    Task<Result> ChangePassword(string email, ChangePasswordDTO changePasswordDTO);
}