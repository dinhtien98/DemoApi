namespace DemoApi.Models.Domain.Pages
{
    public class Pages
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }
        public int Level { get; set; }
        public string Url { get; set; }
        public int Hidden { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public int DeletedFlag { get; set; } = 0;
        public DateTime? DeletedTime { get; set; }
    }
}
