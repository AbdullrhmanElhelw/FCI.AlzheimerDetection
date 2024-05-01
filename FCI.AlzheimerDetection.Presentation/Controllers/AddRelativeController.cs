using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.BL.Validation;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.AddRelatives.Base)]
[ApiController]
public class AddRelativeController : ControllerBase
{
    private readonly IAddRelativeManager _addRelativeManager;
    private readonly UserUtility _userUtility;

    public AddRelativeController(IAddRelativeManager addRelativeManager, UserUtility userUtility)
    {
        _addRelativeManager = addRelativeManager;
        _userUtility = userUtility;
    }

    [HttpPost("{patientId:int}")]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    [CheckSSNLength]
    public async Task<IActionResult> AddRelative(AddRelativeDTO relativeDTO, int patientId)
    {
        var result = await _addRelativeManager.AddRelative(relativeDTO, _userUtility.GetUserId(), patientId);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
}