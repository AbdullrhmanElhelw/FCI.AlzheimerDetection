using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.BL.DTOs.NormalUserDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.NormalUsers.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.NormalUser))]
public class NormalUserController : ControllerBase
{
    private readonly INormalUserManager _normalUserManager;

    public NormalUserController(INormalUserManager normalUserManager)
    {
        _normalUserManager = normalUserManager;
    }

    [HttpPost(ApiRoutes.NormalUsers.Register)]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterNormalUserDTO register)
    {
        var result = await _normalUserManager.Register(register);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.NormalUsers.Login)]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginNormalUserDTO login)
    {
        var result = await _normalUserManager.Login(login);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.NormalUsers.ConfirmEmail)]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailDTO confirmEmailDto)
    {
        var result = await _normalUserManager.ConfirmEmail(confirmEmailDto.Email, confirmEmailDto.Token);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.NormalUsers.ForgotPassword)]
    [AllowAnonymous]
    public async Task<IActionResult> ForgetPassword(string email)
    {
        var result = await _normalUserManager.ForgetPassword(email);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.NormalUsers.ResetPassword)]
    public async Task<IActionResult> ResetPassword(string email, string token, ResetPasswordDTO resetPasswordDTO)
    {
        var result = await _normalUserManager.ResetPassword(email, token, resetPasswordDTO);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.NormalUsers.ChangePassword)]
    public async Task<IActionResult> ChangePassword(string email, ChangePasswordDTO changePasswordDTO)
    {
        var result = await _normalUserManager.ChangePassword(email, changePasswordDTO);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

}