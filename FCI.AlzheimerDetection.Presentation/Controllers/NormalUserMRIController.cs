using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.NormalUserMri.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.NormalUser))]
public class NormalUserMriController : ControllerBase
{
    private readonly INormalUserMRIManager _normalUserMriManager;
    private readonly UserUtility _userUtility;

    public NormalUserMriController(INormalUserMRIManager normalUserMriManager, UserUtility userUtility)
    {
        _normalUserMriManager = normalUserMriManager;
        _userUtility = userUtility;
    }

    [HttpPost(ApiRoutes.NormalUserMri.UploadMri)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadMri([FromForm] UploadNormalUserMRI userMri)
    {
        var userId = int.Parse(_userUtility.GetUserId());
        var result = await _normalUserMriManager.UploadMRI(userMri, userId);

        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPost(ApiRoutes.NormalUserMri.UploadMultipleMri)]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<UploadMultipleMRIDTO>> UploadMultipleMri([FromForm] UploadMultipleMRIDTO userMrIs)
    {
        var userId = int.Parse(_userUtility.GetUserId());
        var result = await _normalUserMriManager.UploadMultipleMRI(userMrIs, userId);

        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }
}