using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.Relatives.Base)]
[ApiController]
public class RelativeController(IRelativeManager relativeManger) : ControllerBase
{
    [HttpPost(ApiRoutes.Relatives.Login)]
    public async Task<IActionResult> Login(LoginRelativeDTO relativeDto)
    {
        var result = await relativeManger.Login(relativeDto);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
}