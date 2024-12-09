
using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.Login;
using DemoApi.Models.Dtos.Tokens;
using DemoApi.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoApi.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly DapperConnection _dapperConnection;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSetings;
        public LoginService(DapperConnection dapperConnection,IConfiguration configuration)
        {
            _dapperConnection = dapperConnection;
            _configuration = configuration;
            _jwtSetings = _configuration.GetSection("JWTSettings");
        }


        public async Task<Token> LoginAsync(string UserName,string PassWord)
        {
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var userLogonUserDetails = await connection.QuerySingleOrDefaultAsync<Users>(
                    "UserAuthenticateLookupByLogonNameV1",
                    new
                    {
                        P_UserName = UserName
                    },
                    commandType: CommandType.StoredProcedure
                );

                if (userLogonUserDetails == null || !BCrypt.Net.BCrypt.Verify(PassWord,userLogonUserDetails.Password))
                {
                    throw new UnauthorizedAccessException("Invalid login credentials.");
                }

                // Setup claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userLogonUserDetails.UserName.ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetings["securityKey"]));

                var token = new JwtSecurityToken(
                issuer: _jwtSetings["validIssuer"],
                audience: _jwtSetings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSetings["expiryInMinutes"])),
                signingCredentials: new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256));
                var tk = new JwtSecurityTokenHandler().WriteToken(token);
                Token rsToken = new Token();
                rsToken.fullName = userLogonUserDetails.FullName;
                rsToken.expires = DateTime.UtcNow.AddHours(1);
                rsToken.token = tk;
                rsToken.userName = userLogonUserDetails.UserName;
                return rsToken;
            }
        }
    }
}
