
namespace Entity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public bool DeliveryStatus { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public ICollection<ProductOrder> Products { get; set; }
    }
}
