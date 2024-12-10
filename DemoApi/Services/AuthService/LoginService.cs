
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
    public class LoginService: ILoginService
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
                Token rsToken = new Token();
                await connection.OpenAsync();
                var userLogonUserDetails = await connection.QuerySingleOrDefaultAsync<Users>(
                    "sp_auth_user_login_select",
                    new
                    {
                        P_UserName = UserName
                    },
                    commandType: CommandType.StoredProcedure
                );


                if (userLogonUserDetails == null)
                {
                    rsToken.token = "Incorrect username or password";
                    return rsToken;
                }
                else if (userLogonUserDetails.IsLocked == 1)
                {
                    rsToken.token = "Account is locked";
                    return rsToken;
                }
                else if (!BCrypt.Net.BCrypt.Verify(PassWord,userLogonUserDetails.Password))
                {
                    var userLogonFailCount = await connection.QuerySingleOrDefaultAsync<Users>(
                        "sp_auth_user_login_failcount_update",
                        new
                        {
                            P_ID = userLogonUserDetails.Id
                        },
                        commandType: CommandType.StoredProcedure
                        );
                    rsToken.token = "Incorrect password";
                    return rsToken;
                }
                else
                {
                    var resetFailCount = await connection.QueryAsync<Users>(
                        "sp_auth_user_login_failcount_reset",
                        new
                        {
                            P_ID = userLogonUserDetails.Id
                        },
                        commandType: CommandType.StoredProcedure
                        );
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
                    var tkn = new JwtSecurityTokenHandler().WriteToken(token);


                    rsToken.fullName = userLogonUserDetails.FullName;
                    rsToken.expires = DateTime.UtcNow.AddHours(1);
                    rsToken.token = tkn;
                    rsToken.userName = userLogonUserDetails.UserName;
                    return rsToken;
                }
            }
        }
    }
}
