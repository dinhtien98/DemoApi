namespace DemoApi.Models.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int userID
        {
            get; set;
        }
        public string shippingAddress { get; set; }
        public decimal total
        {
            get;set;
        }
        public int status { get; set; }
        public string paymentMenthod { get; set; }
        public string paymentBy
        {
            get;set;
        }
        public string createdBy { get; set; }
        public List<OrderDetailJson> Details { get; set; }
    }
}
