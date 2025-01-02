using Newtonsoft.Json;

namespace DemoApi.Models.Dtos.PageDtos
{
    public class GetPageDtos
    {
        public string id
        {
            get;
        }
        public string Code
        {
            get;
        }
        public string Name
        {
            get;
        }
        public string ParentCode
        {
            get;
        }
        public int Level
        {
            get;
        }
        public string Url
        {
            get;
        }
        public int Hidden
        {
            get;
        }
        public string Icon
        {
            get;
        }
        public int Sort
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

        public List<string> RoleNamesList
        {
            get
            {
                if (string.IsNullOrEmpty(RoleName))
                    return new List<string>();

                var cleanedRoleName = RoleName.Replace("\\","");
                return JsonConvert.DeserializeObject<List<string>>(cleanedRoleName);
            }
        }

        public string ActionName
        {
            get;
        }

        public List<string> ActionNamesList
        {
            get
            {
                if (string.IsNullOrEmpty(ActionName))
                    return new List<string>();

                var cleanedActionName = ActionName.Replace("\\","");
                return JsonConvert.DeserializeObject<List<string>>(cleanedActionName);
            }
        }

    }
}
