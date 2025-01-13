using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Domain.Role;
using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.RoleDtos;

namespace DemoApi.Services.Role
{
    public interface IRoleService
    {
        public Task<List<GetRoleDtos>> GetAllRolesAsync();
        public Task<Roles> GetRoleByIdAsync(int id);
        public Task<Roles> AddRoleAsync(RoleDtos roleDtos, int createdById);
        public Task<Roles> UpdateRoleAsync(int id,RoleDtos roleDtos,int updatedById);
        public Task<Roles> DeleteRoleAsync(int id,RoleDtos roleDtos,int deletedById);
    }
}
