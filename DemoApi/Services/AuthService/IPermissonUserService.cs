using DemoApi.Models.Dtos.PermissonUserDto;

namespace DemoApi.Services.AuthService
{
    public interface IPermissonUserService
    {
        Task<List<PermissonUserDto>> GetPermissonUser(int id);
    }
}
