using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.UserDtos;

namespace DemoApi.Services.User
{
    public interface IUserService
    {
        public Task<List<Users>> GetAllUserAsync();
        public Task<Users> GetUserByIdAsync(int id);
        public Task<Users> AddUserAsync(UserDto userDto);
        public Task<Users> UpdateUserAsync(int id,UserDto userDto);
        public Task<Users> DeleteUserAsync(int id, UserDto userDto);
    }
}
