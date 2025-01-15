using DemoApi.Commons;
using DemoApi.Models.Domain.Role;
using DemoApi.Models.Dtos.PageDtos;

namespace DemoApi.Models.Dtos.UserDtos
{
    public class UserDto : Common
    {
        public string UserName
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public int FirstLogin
        {
            get; set;
        }
        public string InDate
        {
            get; set;
        }
        public string OutDate
        {
            get; set;
        }
        public int? FailCount
        {
            get; set;
        }
        public int IsLocked { get; set; } = 0;
        public string LastLogin
        {
            get; set;
        }
        public DateTime? CreatedTime
        {
            get; set;
        }
        public string CreatedBy
        {
            get; set;
        }
        public DateTime? UpdatedTime
        {
            get; set;
        }
        public string UpdatedBy
        {
            get; set;
        }
        public string DeletedBy
        {
            get; set;
        }
        public int DeletedFlag { get; set; } = 0;
        public DateTime? DeletedTime
        {
            get; set;
        }
        public List<Json> RoleCode
        {
            get; set;
        }
    }
}
