using JwtStore.Account.Entities;
using JwtStore.Account.Services;
using JwtStore.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtStore.Infra.Services;

public class AuthenticateTokenService : IAuthenticateTokenService
{
    public string GenerateToken(User user)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)

        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }
    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claimsIdent = new ClaimsIdentity();
        claimsIdent.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
        claimsIdent.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        foreach (var role in user.Roles)
        {
            claimsIdent.AddClaim(new Claim(ClaimTypes.Role, role.Title));
        }


        return claimsIdent;
    }
}