using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.UserDtos;
using DemoApi.Services.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorize]

    public class authPageController: ControllerBase
    {
        private readonly IPageService _pageService;
        public authPageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPages()
        {
            try
            {
                var page = await _pageService.GetAllPagesAsync();
                return Ok(page);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("{id}",Name = "Page_id")]
        public async Task<IActionResult> GetPageById(int id)
        {
            try
            {
                var page = await _pageService.GetPageByIdAsync(id);
                if (page == null)
                {
                    return NotFound();
                }
                return Ok(page);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPage([FromBody] PageDtos pageDtos)
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
                var addPage = await _pageService.AddPageAsync(pageDtos,createdById);
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
        public async Task<IActionResult> DeletePage(int id,[FromBody] PageDtos pageDto)
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
                var page = await _pageService.GetPageByIdAsync(id);
                if (page == null)
                    return NotFound();
                await _pageService.DeletePageAsync(id,pageDto,deletedById);
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
        public async Task<IActionResult> UpdatePage(int id,[FromBody] PageDtos pageDto)
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
                var page = await _pageService.GetPageByIdAsync(id);
                if (page == null)
                    return NotFound();
                await _pageService.UpdatePageAsync(id,pageDto,updatedById);
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
