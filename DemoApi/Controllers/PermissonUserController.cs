using DemoApi.Models.Dtos.PermissonUserDto;
using DemoApi.Services.AuthService;
using DemoApi.Services.Page;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissonUserController: ControllerBase
    {
        private readonly IPermissonUserService _permissonUserService;
        public PermissonUserController(IPermissonUserService permissonUserService)
        {
            _permissonUserService = permissonUserService;
        }

        [HttpGet("{id}",Name = "id")]
        public async Task<IActionResult> GetPermissonUser(int id)
        {
            try
            {
                var data  = await _permissonUserService.GetPermissonUser(id);
                var res = new PermissonResponce();
                res.data = data;
                res.total = data.Count();
                res.pageIndex = 0;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
