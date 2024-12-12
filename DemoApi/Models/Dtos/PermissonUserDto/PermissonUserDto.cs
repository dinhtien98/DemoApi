
namespace DemoApi.Models.Dtos.PermissonUserDto
{
    public class PermissonUserDto
    {
        public int UserId
        {
            get; set;
        }
        public string UserName { get; set; }
        public string PageCode { get; set; }
        public string PageName { get; set; }
        public string pageParentCode { get; set; }
        public int pageLevel { get; set; }
        public string icon { get; set; }  
        public string Url { get; set; }
        public int sort { get; set; }
    }
}
