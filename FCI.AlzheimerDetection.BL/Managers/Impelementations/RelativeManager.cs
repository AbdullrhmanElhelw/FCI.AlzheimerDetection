using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.TokenProviders;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class RelativeManager : IRelativeManager
{
    private readonly UserManager<Relative> _userManger;
    private readonly ITokenProvider _tokenProvider;

    public RelativeManager(UserManager<Relative> userManger, ITokenProvider tokenProvider)
    {
        _userManger = userManger;
        _tokenProvider = tokenProvider;
    }


    public async Task<Result> Login(LoginRelativeDTO relativeDTO)
    {
        var relativeIsExists = await _userManger.FindBySSNAsync(relativeDTO.SSN);

        if (relativeIsExists is null)
            return Result.Failure("User Is Not Exists");

        var passwordCheck = await _userManger.CheckPasswordAsync(relativeIsExists, relativeDTO.Password);
        if (passwordCheck is false)
            return Result.Failure("Not Correct Password");

        var claims = new List<Claim>()
        {
            new (ClaimTypes.SerialNumber,relativeIsExists.SSN),
            new (ClaimTypes.NameIdentifier,relativeIsExists.Id.ToString())
        };

        var token = _tokenProvider.GenerateToken(claims);

        return Result.Success(token);
    }
}