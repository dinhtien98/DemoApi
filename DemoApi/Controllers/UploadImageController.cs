using DemoApi.Services.UploadImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController: ControllerBase
    {
        private readonly IUploadImageService _uploadImageService;

        public UploadImageController(IUploadImageService uploadImageService)
        {
            _uploadImageService = uploadImageService;
        }

        [HttpPost("images")]
        [CustomAuthorize]
        public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> images)
        {
            if (images == null || images.Count == 0)
            {
                return BadRequest(new
                {
                    error = "No image files provided."
                });
            }

            try
            {
                var uploadedUrls = await _uploadImageService.UploadImagesAsync(images);
                return Ok(new
                {
                   uploadedUrls
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new
                {
                    error = ex.Message
                });
            }
        }
    }
}
