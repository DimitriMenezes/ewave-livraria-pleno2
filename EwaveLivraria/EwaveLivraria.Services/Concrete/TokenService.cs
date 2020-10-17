using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EwaveLivraria.Services.Concrete
{
    public static class TokenService
    {
        //public static string GenerateToken(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Settings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Name.ToString()),
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(2),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        //public static string GenerateGuidToken()
        //{
        //    var g = Guid.NewGuid();
        //    var guidString = Convert.ToBase64String(g.ToByteArray());
        //    var result = string.Join("", guidString.ToCharArray().Where(ch => Char.IsLetterOrDigit(ch)));
        //    return result;
        //}
    }
}
