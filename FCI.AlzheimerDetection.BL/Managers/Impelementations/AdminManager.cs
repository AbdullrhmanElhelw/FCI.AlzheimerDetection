using FCI.AlzheimerDetection.BL.DTOs.AdminDTOs;
using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.TokenProviders;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class AdminManager : IAdminManager
{
    private readonly UserManager<Admin> _userManger;
    private readonly ITokenProvider _jWTTokenProvider;

    public AdminManager(UserManager<Admin> userManger, ITokenProvider jWTTokenProvider)
    {
        _userManger = userManger;
        _jWTTokenProvider = jWTTokenProvider;
    }

    public async Task<Result> Create(CreateAdminDTO registerDTO)
    {
        var user = new Admin
        {
            FirstName = registerDTO.FirstName,
            LastName = registerDTO.LastName,
            UserName = registerDTO.FirstName + registerDTO.LastName,
            SSN = registerDTO.SSN,
            BirthDate = registerDTO.BirthDate
        };

        var CreationResult = await _userManger.CreateAsync(user, registerDTO.Password);

        string result = string.Empty;
        if (!CreationResult.Succeeded)
            return Result.Failure(result.GetErrorResult(CreationResult));

        var roleResult = await _userManger.AddToRoleAsync(user, nameof(AppRoles.Admin));

        if (!roleResult.Succeeded)
            return Result.Failure((result.GetErrorResult(roleResult)));

        var claims = new List<Claim>()
        {
            new (ClaimTypes.SerialNumber,registerDTO.SSN),
            new (ClaimTypes.Name,registerDTO.FirstName),
            new (ClaimTypes.NameIdentifier,await _userManger.GetUserIdAsync(user)),
        };

        var claimResult = await _userManger.AddClaimsAsync(user, claims);
        if (!claimResult.Succeeded)
            return Result.Failure((result.GetErrorResult(roleResult)));

        return Result.Success("User Created Successfully");
    }

    public async Task<Result> Login(LoginAdminDTO loginDTO)
    {
        var checkAdminIsExists = await _userManger.FindBySSNAsync(loginDTO.SSN);
        if (checkAdminIsExists is null)
            return Result.Failure("User Not Found");

        var checkPassword = await _userManger.CheckPasswordAsync(checkAdminIsExists, loginDTO.Password);
        if (checkPassword is false)
            return Result.Failure("Password is not Correct");

        var claims = await _userManger.GetClaimsAsync(checkAdminIsExists);
        claims.Add(new(ClaimTypes.Role, nameof(AppRoles.Admin)));
        var token = _jWTTokenProvider.GenerateToken((List<Claim>)claims);

        return Result.Success(token);
    }

    public async Task<Result> Delete(int id)
    {
        var userIsExists = await _userManger.FindByIdAsync(id.ToString());
        if (userIsExists is null)
            return Result.Failure("User Not Found");

        var result = await _userManger.DeleteAsync(userIsExists);
        var errorResult = string.Empty;
        if (!result.Succeeded)
            return Result.Failure(errorResult.GetErrorResult(result));

        return Result.Success("Admin Deleted SuccessFully");
    }

    public async Task<Result<ReadAdminDTO>> GetAdmin(string ssn)
    {
        var checkAdminIsExists = await _userManger.FindBySSNAsync(ssn);

        if (checkAdminIsExists is null)
            return Result.Failure<ReadAdminDTO>("User Not Found");

        return Result.Success<ReadAdminDTO>(checkAdminIsExists);
    }

    public Task<Result<IQueryable<ReadAdminDTO>>> GetAllAdmins()
    {
        var users = _userManger.Users.AsQueryable();

        var mappedUsers = users.Select(u => new ReadAdminDTO(u.FirstName, u.LastName, u.SSN, u.BirthDate));

        return Task.FromResult(Result.Success(mappedUsers));
    }

    public Task<Result<IQueryable<ReadAdminDTO>>> FindAllByName(string Name)
    {
        var users = _userManger.Users
            .Where(u => u.FirstName
            .Contains(Name, StringComparison.OrdinalIgnoreCase)
            || u.LastName
            .Contains(Name, StringComparison.OrdinalIgnoreCase))
            .AsQueryable();

        var mappedUsers = users.Select(u => new ReadAdminDTO(u.FirstName, u.LastName, u.SSN, u.BirthDate));

        return Task.FromResult(Result.Success(mappedUsers));
    }

    public Task<Result<IQueryable<ReadAdminDTO>>> GetAllAdminsWithPaging(int pageNumber, int pageSize, string orderBy = "SSN")
    {
        var users = _userManger.Users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(x => orderBy)
            .AsQueryable();

        var mappedUsers = users.Select(u => new ReadAdminDTO(u.FirstName, u.LastName, u.SSN, u.BirthDate));

        return Task.FromResult(Result.Success(mappedUsers));
    }

    public async Task<Result> ChangePassword(int id, ChangePasswordDTO passwordDTO)
    {
        var adminIsExists = await _userManger.FindByIdAsync(id.ToString());
        if (adminIsExists is null)
            return Result.Failure("User Not Found");

        var oldPasswordChecker = await _userManger.CheckPasswordAsync(adminIsExists, passwordDTO.OldPassword);
        if (oldPasswordChecker is false)
            return Result.Failure("Old Password is not Correct");

        var result = await _userManger.ChangePasswordAsync(adminIsExists, passwordDTO.OldPassword, passwordDTO.NewPassword);

        if (!result.Succeeded)
        {
            StringBuilder errors = new();
            foreach (var error in result.Errors)
            {
                errors.Append(error.Description);
                errors.Append(Environment.NewLine);
            }
            return Result.Failure(errors.ToString());
        }

        return Result.Success("Password Changed Successfully");
    }
}