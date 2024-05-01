using System.Security.Claims;

namespace FCI.AlzheimerDetection.DAL.TokenProviders;

public interface ITokenProvider
{
    string GenerateToken(List<Claim> claims);
}