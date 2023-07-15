
namespace Entity.Models
{
    public class ProductCart
    {
        public int ProductId { get; set; }
        public int BasketId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
