using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.UserDtos;

namespace DemoApi.Services.User
{
    public interface IUserService
    {
        public Task<List<Users>> GetAllUserAsync();
        public Task<Users> GetUserByIdAsync(int id);
        public Task<bool> AddUserAsync(UserDto userDto, int createdById);
        public Task<bool> UpdateUserAsync(int id,UserDto userDto, int updatedById);
        public Task<Users> DeleteUserAsync(int id, UserDto userDto,int deletedById);
    }
}
