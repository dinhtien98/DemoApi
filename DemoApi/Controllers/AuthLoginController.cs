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
    public class authLoginController: ControllerBase
    {
        private readonly ILoginService _loginService;
        public authLoginController(ILoginService loginService)
        {
            _loginService= loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var Data = await _loginService.LoginAsync(loginDto.Username,loginDto.Password);
                return Ok(new
                {
                    Data
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
