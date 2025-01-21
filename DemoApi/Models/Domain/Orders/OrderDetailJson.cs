namespace DemoApi.Models.Domain.Orders
{
    public class OrderDetailJson
    {
        public int PRODUCTID { get; set; }
        public int QUANTITY { get; set; }
        public decimal PRICE { get; set; }
        public decimal TOTAL { get; set; }
    }
}
