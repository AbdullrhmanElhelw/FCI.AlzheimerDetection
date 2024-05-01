using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FCI.AlzheimerDetection.BL.Helper;

public class UserUtility
    (IHttpContextAccessor httpContextAccessor)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string GetUserId()
    {
        var claim = ClaimTypes.NameIdentifier;
        return _httpContextAccessor.HttpContext.User.FindFirst(claim).Value;
    }
}