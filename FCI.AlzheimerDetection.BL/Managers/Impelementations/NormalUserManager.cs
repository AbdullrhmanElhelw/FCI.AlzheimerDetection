using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.BL.DTOs.NormalUserDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.TokenProviders;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class NormalUserManager : INormalUserManager
{
    private readonly UserManager<NormalUser> _normalUser;
    private readonly ITokenProvider _tokenProvider;
    private readonly IEmailManager _emailManager;

    public NormalUserManager(UserManager<NormalUser> normalUser, ITokenProvider tokenProvider, IEmailManager emailManager)
    {
        _normalUser = normalUser;
        _tokenProvider = tokenProvider;
        _emailManager = emailManager;
    }

    public async Task<Result> ConfirmEmail(string email, string token) =>
        await _emailManager.ConfirmEmailAsync(email, token);

    public async Task<Result> Login(LoginNormalUserDTO loginDTO)
    {
        var checkUserIsExists = await _normalUser.FindByEmailAsync(loginDTO.Email);

        if (checkUserIsExists is null)
            return Result.Failure("User Not Found");

        var checkPassordIsCorrect = await _normalUser.CheckPasswordAsync(checkUserIsExists, loginDTO.Password);

        if (checkPassordIsCorrect is false)
            return Result.Failure("Password is not Correct");

        var checkEamilIsConfirmed = await _normalUser.IsEmailConfirmedAsync(checkUserIsExists);

        if (checkEamilIsConfirmed is false)
            return Result.Failure("Email is not Confirmed");

        var claims = await _normalUser.GetClaimsAsync(checkUserIsExists);

        var token = _tokenProvider.GenerateToken((List<Claim>)claims);

        return Result.Success(token);
    }

    public async Task<Result> Register(RegisterNormalUserDTO registerDTO)
    {
        if (string.IsNullOrEmpty(registerDTO.Email) || string.IsNullOrWhiteSpace(registerDTO.Email))
            return Result.Failure("Email is Required");

        var user = new NormalUser
        {
            FirstName = registerDTO.FirstName,
            LastName = registerDTO.LastName,
            UserName = registerDTO.Email[..registerDTO.Email.IndexOf('@')],
            Email = registerDTO.Email
        };

        var creaationResult = await _normalUser.CreateAsync(user, registerDTO.Password);

        if (!creaationResult.Succeeded)
            return Result.Failure("".GetErrorResult(creaationResult));

        var addRoleResult = await _normalUser.AddToRoleAsync(user, nameof(AppRoles.NormalUser));

        if (!addRoleResult.Succeeded)
            return Result.Failure("".GetErrorResult(addRoleResult));

        var claims = new List<Claim>
        {
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Role, nameof(AppRoles.NormalUser))
        };

        var addClaimsResult = await _normalUser.AddClaimsAsync(user, claims);

        if (!addClaimsResult.Succeeded)
            return Result.Failure("".GetErrorResult(addClaimsResult));

        var token = await _normalUser.GenerateEmailConfirmationTokenAsync(user);

        var confirmationLink = $"Please Confirm Your Email{user.Email}{token}";
        await _emailManager.SendEmailAsync(registerDTO.Email, "Confirm Your Email", confirmationLink);

        return Result.Success("Uesr Added Successfully, Please Confirm Your Email Check Your Email");
    }

    public Task<Result> ForgetPassword(string email) =>
       _emailManager.ForgetPassword(email);

    public Task<Result> ResetPassword(string email, string token, ResetPasswordDTO resetPasswordDTO) =>
       _emailManager.ResetPassword(email, token, resetPasswordDTO);

    public Task<Result> ChangePassword(string email, ChangePasswordDTO changePasswordDTO) =>
        _emailManager.ChangePassword(email, changePasswordDTO);
}