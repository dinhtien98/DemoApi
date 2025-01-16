using DemoApi.Models.Dtos.CustomerDtos;
using DemoApi.Models.Dtos.ProductDtos;
using DemoApi.Services.Customer;
using DemoApi.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [CustomAuthorize]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var res = await _customerService.GetAllCustomerAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("{id}",Name = "Customer_id")]
        [CustomAuthorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var res = await _customerService.GetCustomerByIdAsync(id);
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
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDtos customerDtos)
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
                var res = await _customerService.AddCustomerAsync(customerDtos,createdById);
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
        public async Task<IActionResult> UpdateCustomer(int id,[FromBody] CustomerDtos customerDtos)
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
                var res = await _customerService.GetCustomerByIdAsync(id);
                if (res == null)
                    return NotFound();
                await _customerService.UpdateCustomerAsync(id,customerDtos,updatedById);
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
        public async Task<IActionResult> DeleteCustomer(int id,[FromBody] CustomerDtos customerDtos)
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
                var res = await _customerService.GetCustomerByIdAsync(id);
                if (res == null)
                    return NotFound();
                await _customerService.DeleteCustomerAsync(id,customerDtos,deletedById);
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
