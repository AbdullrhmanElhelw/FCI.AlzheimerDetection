using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.AdminMrIs.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.Admin))]
public class AdminMriController : ControllerBase
{
    private readonly IAdminMRIManager _adminMriManager;
    private readonly UserUtility _userUtility;

    public AdminMriController(IAdminMRIManager adminMriManager, UserUtility userUtility)
    {
        _adminMriManager = adminMriManager;
        _userUtility = userUtility;
    }

    [HttpPost(ApiRoutes.AdminMrIs.UploadMri)]
    public async Task<ActionResult<CreateMRIDTO>> UploadMri(IFormFile mri)
    {
        var adminId = int.Parse(_userUtility.GetUserId());
        var result = await _adminMriManager.UploadAdminMRI(new UploadAdminMRIDTO(mri), adminId);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
}