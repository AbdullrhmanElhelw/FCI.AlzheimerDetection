using FCI.AlzheimerDetection.DAL.Settings.TokenSettings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FCI.AlzheimerDetection.DAL.TokenProviders;

public class JWTTokenProvider : ITokenProvider
{
    private readonly JWTSetting _options;

    public JWTTokenProvider(IOptions<JWTSetting> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(List<Claim> claims)
    {
        var readKey = _options.Key;
        var keyInBytes = Encoding.UTF8.GetBytes(readKey);
        var keyEncypted = new SymmetricSecurityKey(keyInBytes);
        var creds = new SigningCredentials(keyEncypted, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audicne,
            signingCredentials: creds,
            expires: DateTime.Now.AddMinutes(_options.DurationInMinutes),
            claims: claims
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}