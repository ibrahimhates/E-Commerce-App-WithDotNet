
namespace Entity.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool StockStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductBasket>? Baskets { get; set; }
        public ICollection<ProductOrder>? Orders { get; set; }

    }
}
