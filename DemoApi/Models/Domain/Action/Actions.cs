namespace DemoApi.Models.Domain.Action
{
    public class Actions
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string ActionCode
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
    }
}
