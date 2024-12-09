namespace DemoApi.Models.Dtos.Login
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessfull
        {
            get; set;
        }
        public string ErrorMessage
        {
            get; set;
        }
        public string Token
        {
            get; set;
        }
    }
}
