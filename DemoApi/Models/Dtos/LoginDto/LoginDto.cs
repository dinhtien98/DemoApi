using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models.Dtos.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username
        {
            get; set;
        }
        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get; set;
        }
    }
}
