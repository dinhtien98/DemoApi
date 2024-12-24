namespace DemoApi.Models.Dtos.Tokens
{
    public class Token
    {
        public int id
        {
            get;set;
        }
        public DateTime? expires
        {
            get;set;
        }
        public string fullName { get; set; }
        public string token
        {
            get;set;
        }
        public string userName { get; set; }
    }
}
