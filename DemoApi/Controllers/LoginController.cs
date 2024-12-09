using AutoMapper;
using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.Login;
using DemoApi.Services.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService= loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = await _loginService.LoginAsync(loginDto.Username,loginDto.Password);
                return Ok(new
                {
                    token
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new
                {
                    message = "Invalid credentials"
                });
            }
        }
    }
}
