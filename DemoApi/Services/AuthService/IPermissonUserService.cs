using DemoApi.Models.Dtos.PageDtos;

namespace DemoApi.Services.AuthService
{
    public interface IPermissonUserService
    {
        Task<List<GetPageDtos>> GetPermissonUser(int id);
    }
}
