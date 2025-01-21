namespace DemoApi.Models.Domain.Product
{
    public class Products
    {
        public int Id
        {
            get; set;
        }
        public string? ProductName
        {
            get; set;
        }
        public string? Description
        {
            get; set;
        }
        public decimal Price
        {
            get; set;
        }
        public int StockQuantity
        {
            get; set;
        }
        public int Category
        {
            get; set;
        }
        public string? Supplier
        {
            get; set;
        }
        public decimal Discount
        {
            get; set;
        }
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
        public int DeletedFlag
        {
            get; set;
        }
    }
}

