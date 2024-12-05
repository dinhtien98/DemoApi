using DemoApi.Models.Domain.Student;
using DemoApi.Models.Dtos.StudentDtos;
using DemoApi.Models.Dtos.UserDtos;
using DemoApi.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var Users = await _userService.GetAllUserAsync();
                return Ok(Users);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("{id}",Name = "User_id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                var addUser = await _userService.AddUserAsync(userDto);
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
        public async Task<IActionResult> UpdateUser(int id,[FromBody] UserDto userDto)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();
                await _userService.UpdateUserAsync(id,userDto);
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
        public async Task<IActionResult> DeleteUser(int id,[FromBody] UserDto userDto)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();
                await _userService.DeleteUserAsync(id,userDto);
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
