using Newtonsoft.Json;

namespace DemoApi.Models.Dtos.UserDtos
{
    public class GetUserDtos
    {
        public int Id
        {
            get;
        }
        public string UserName
        {
            get;
        }
        public string Password
        {
            get;
        }
        public string FullName
        {
            get;
        }
        public string Email
        {
            get;
        }
        public int FirstLogin
        {
            get;
        }
        public string InDate
        {
            get;
        }
        public string OutDate
        {
            get;
        }
        public int? FailCount
        {
            get;
        }
        public int IsLocked { get; set; } = 0;
        public string Avatar
        {
            get;
        }
        public DateTime? LastLogin
        {
            get;
        }
        public DateTime? CreatedTime
        {
            get;
        }
        public string CreatedBy
        {
            get;
        }
        public DateTime? UpdatedTime
        {
            get;
        }
        public string UpdatedBy
        {
            get;
        }
        public string DeletedBy
        {
            get;
        }
        public int DeletedFlag { get; set; } = 0;
        public DateTime? DeletedTime
        {
            get;
        }
        public string RoleName
        {
            get;
        }
        //public List<string> RoleNamesList
        //{
        //    get => string.IsNullOrEmpty(RoleName) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(RoleName);
        //}
    }
}
