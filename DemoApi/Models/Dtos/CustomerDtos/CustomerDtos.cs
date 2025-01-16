using DemoApi.Commons;

namespace DemoApi.Models.Dtos.CustomerDtos
{
    public class CustomerDtos : Common
    {
        public int Id
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string? FirstLogin
        {
            get; set;
        }
        public string? InDate
        {
            get; set;
        }
        public string? OutDate
        {
            get; set;
        }
        public int FailCount { get; set; } = 0;
        public int IsLocked { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Discount { get; set; } = 0;
        public DateTime? CreatedTime
        {
            get; set;
        }
        public string? CreatedBy
        {
            get; set;
        }
        public DateTime? UpdatedTime
        {
            get; set;
        }
        public string? UpdatedBy
        {
            get; set;
        }
        public DateTime? DeletedTime
        {
            get; set;
        }
        public string? DeletedBy
        {
            get; set;
        }
        public int DeletedFlag { get; set; } = 0;
    }
}
