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

        [HttpPost("delete-image")]
        [CustomAuthorize]
        public async Task<IActionResult> DeleteImageAsync([FromBody] string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return BadRequest(new
                {
                    message = "Image path is required."
                });
            }
            var id = await _uploadImageService.GetIdImageAsync(imagePath);
            var result = await _uploadImageService.DeleteImageAsync(imagePath,id);

            if (result)
            {
                return Ok(new
                {
                    message = "Image deleted successfully."
                });
            }

            return NotFound(new
            {
                message = "Image not found."
            });
        }

        [HttpGet]
        [CustomAuthorize]
        public async Task<IActionResult> GetUserById(string imageUrl)
        {
            try
            {
                var res = await _uploadImageService.GetIdImageAsync(imageUrl);
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
    }
}
