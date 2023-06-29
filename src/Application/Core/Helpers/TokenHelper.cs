using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Application.Core.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(string userId, string secretKey,string compId)
        {
            var claims = new List<Claim>
            {
                new Claim("usrid", userId),new Claim("compid", compId)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrWhiteSpace(secretKey) || secretKey.Length < 24)
            {
                throw new ArgumentException("JWT secret key not available.");
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims, "CustomAuthType"),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Issuer = "KPAPI",
                Audience = "KPWEB",
                IssuedAt = DateTime.UtcNow,
                TokenType = "JWT",
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static IEnumerable<Claim> ValidateTokenWithLifeTime(string token, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrWhiteSpace(secretKey) || secretKey.Length < 24)
            {
                throw new ArgumentException("JWT secret key not available.");
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = "KPAPI",
                ValidateAudience = true,
                ValidAudience = "KPWEB",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims;
        }

        public static IEnumerable<Claim> ValidateTokenWithoutLifeTIme(string token, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrWhiteSpace(secretKey) || secretKey.Length < 24)
            {
                throw new ArgumentException("JWT secret key not available.");
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = "KPAPI",
                ValidateAudience = true,
                ValidAudience = "KPWEB",
                ValidateLifetime = false,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims;
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var randomText = RandomNumberGenerator.Create();
            randomText.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}