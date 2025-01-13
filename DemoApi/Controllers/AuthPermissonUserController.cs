using DemoApi.Models.Dtos.PermissonUserDto;
using DemoApi.Services.AuthService;
using DemoApi.Services.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authPermissonUserController: ControllerBase
    {
        private readonly IPermissonUserService _permissonUserService;
        public authPermissonUserController(IPermissonUserService permissonUserService)
        {
            _permissonUserService = permissonUserService;
        }

        [HttpGet]
        [CustomAuthorize]
        public async Task<IActionResult> GetPermissionUser()
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim,out int userId))
                {
                    return Unauthorized(new
                    {
                        message = "Invalid or missing user ID in token."
                    });
                }

               
                var data = await _permissonUserService.GetPermissonUser(userId);


                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

    }
}
