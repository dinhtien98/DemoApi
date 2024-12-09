using DemoApi.Models.Dtos.Tokens;

namespace DemoApi.Services.Login
{
    public interface ILoginService
    {
        Task<Token> LoginAsync(string UserName,string PassWord);
    }
}
