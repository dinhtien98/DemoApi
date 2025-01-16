using DemoApi.Models.Dtos.ProductDtos;
using DemoApi.Models.Dtos.UserDtos;
using DemoApi.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [CustomAuthorize]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var res = await _productService.GetAllProductAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("{id}",Name = "Product_id")]
        [CustomAuthorize]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var res = await _productService.GetProductByIdAsync(id);
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
        public async Task<IActionResult> AddProduct([FromBody] ProductDtos productDtos)
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
                var res = await _productService.AddProductAsync(productDtos, createdById);
                return Ok("AddUser successfully");
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
        [CustomAuthorize]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductDtos productDtos)
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
                var res = await _productService.GetProductByIdAsync(id);
                if (res == null)
                    return NotFound();
                await _productService.UpdateProductAsync(id,productDtos,updatedById);
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

        [HttpDelete]
        [CustomAuthorize]
        public async Task<IActionResult> DeleteProduct(int id,[FromBody] ProductDtos productDtos)
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
                var res = await _productService.GetProductByIdAsync(id);
                if (res == null)
                    return NotFound();
                await _productService.DeleteProductAsync(id,productDtos,deletedById);
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
    }
}
