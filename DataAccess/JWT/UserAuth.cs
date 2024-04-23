using DataModels.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DataAccess.JWT;

public class UserAuth : IUserAuth
{
    private readonly IConfiguration _config;

    public UserAuth(IConfiguration config)
    {
        _config = config;
    }

    public String AuthUser(User user)
    {
        var Claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.username),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.GivenName, user.givenName),
            new Claim(ClaimTypes.Surname, user.surname),
            new Claim(ClaimTypes.Role, user.role),
        };

        var token = new JwtSecurityToken
        (
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: Claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"])),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}
