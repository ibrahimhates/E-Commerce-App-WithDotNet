
namespace Entity.Models
{
    public class Cart
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
        public ICollection<ProductCart> Products { get; set; }
    }
}
