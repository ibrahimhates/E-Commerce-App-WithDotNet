
namespace Entity.Models
{
    public class Basket
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
        public ICollection<ProductBasket>? Products { get; set; }
    }
}
