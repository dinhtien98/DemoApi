using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.RoleDtos;
using DemoApi.Services.Page;
using DemoApi.Services.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorize]
    public class authRoleController: ControllerBase
    {
        private readonly IRoleService _roleService;
        public authRoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var role = await _roleService.GetAllRolesAsync();
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("{id}",Name = "Role_id")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role == null)
                {
                    return NotFound();
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleDtos roleDto)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim,out int createdById))
                {
                    return Unauthorized(new
                    {
                        message = "Invalid or missing user ID in token."
                    });
                }
                var addRole = await _roleService.AddRoleAsync(roleDto,createdById);
                return Ok("Add successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500,new
                {
                    error = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int id,[FromBody] RoleDtos roleDtos)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim,out int deletedById))
                {
                    return Unauthorized(new
                    {
                        message = "Invalid or missing user ID in token."
                    });
                }
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role == null)
                    return NotFound();
                await _roleService.DeleteRoleAsync(id,roleDtos,deletedById);
                return Ok("delete successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500,new
                {
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePage(int id,[FromBody] RoleDtos roleDtos)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim,out int updatedById))
                {
                    return Unauthorized(new
                    {
                        message = "Invalid or missing user ID in token."
                    });
                }
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role == null)
                    return NotFound();
                await _roleService.UpdateRoleAsync(id,roleDtos,updatedById);
                return Ok("update successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500,new
                {
                    error = ex.Message
                });
            }
        }
    }
}
