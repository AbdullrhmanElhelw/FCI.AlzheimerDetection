using FCI.AlzheimerDetection.BL.DTOs.AdminDTOs;
using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.BL.Validation;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.Admins.Base)]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminManager _adminManager;
    private readonly UserUtility _userUtility;

    public AdminController(IAdminManager adminManager, UserUtility userUtility)
    {
        _adminManager = adminManager;
        _userUtility = userUtility;
    }
    
    [HttpPost(ApiRoutes.Admins.Create)]
    [CheckSSNLength]
    public async Task<IActionResult> CreateAdmin(CreateAdminDTO adminDTO)
    {
        var result = await _adminManager.Create(adminDTO);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.Admins.Login)]
    public async Task<IActionResult> Login(LoginAdminDTO adminDTO)
    {
        var result = await _adminManager.Login(adminDTO);
        return result.IsSuccess ?
            Ok(result)
            : BadRequest(result);
    }

    [HttpDelete(ApiRoutes.Admins.Delete)]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _adminManager.Delete(id);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
    
    [HttpGet(ApiRoutes.Admins.GetAdmin)]
    public async Task<ActionResult<ReadAdminDTO>> GetAdmin(string ssn)
    {
        if (!IsNumeric(ssn))
            return BadRequest("SSN Must be 14 Digits");
        var result = await _adminManager.GetAdmin(ssn);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
    
    [HttpGet(ApiRoutes.Admins.GetAllAdmins)]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    public async Task<ActionResult<IQueryable<ReadAdminDTO>>> GetAllAdmins()
    {
        
        var result = await _adminManager.GetAllAdmins();
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Admins.GetAllByName)]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    public async Task<ActionResult<IQueryable<ReadAdminDTO>>> GetAllByName(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            return BadRequest("Empty Name");

        var result = await _adminManager.GetAllAdmins();
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
    
    [HttpGet(ApiRoutes.Admins.GetAllAdminsPaged)]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    public async Task<ActionResult<IQueryable<ReadAdminDTO>>> GetAllAdminsWithPaging(int pageNumber, int pageSize)
    {
        var result = await _adminManager.GetAllAdminsWithPaging(pageNumber, pageSize);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
    
    [HttpGet(ApiRoutes.Admins.ChangePassword)]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    public async Task<IActionResult> ChangePassword(ChangePasswordDTO passwordDTO)
    {
        var userId = int.Parse(_userUtility.GetUserId());
        var result = await _adminManager.ChangePassword(userId, passwordDTO);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    private static bool IsNumeric(string value) =>
        long.TryParse(value, out _);
}