using DemoApi.Models.Dtos.ActionDtos;
using DemoApi.Models.Dtos.RoleDtos;
using DemoApi.Services.Action;
using DemoApi.Services.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorize]
    public class AuthActionController: ControllerBase
    {
        private readonly IActionService _actionService;
        public AuthActionController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAction()
        {
            try
            {
                var res = await _actionService.GetAllActionsAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("{id}",Name = "Action_id")]
        public async Task<IActionResult> GetActionById(int id)
        {
            try
            {
                var res = await _actionService.GetActionByIdAsync(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAction([FromBody] ActionDtos actionDtos)
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
                var res = await _actionService.AddActionAsync(actionDtos,createdById);
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
        public async Task<IActionResult> DeleteAction(int id,[FromBody] ActionDtos actionDtos)
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
                var res = await _actionService.GetActionByIdAsync(id);
                if (res == null)
                    return NotFound();
                await _actionService.DeleteActionAsync(id,actionDtos,deletedById);
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
        public async Task<IActionResult> UpdatePage(int id,[FromBody] ActionDtos actionDtos)
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
                var res = await _actionService.GetActionByIdAsync(id);
                if (res == null)
                    return NotFound();
                await _actionService.UpdateActionAsync(id,actionDtos,updatedById);
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
