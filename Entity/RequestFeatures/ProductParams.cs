
namespace Entity.RequestFeatures
{
    public class ProductParams : PaginationParams
    {
        public String? SearchTerm { get; set; }
        public ProductParams()
        {
            OrderBy = "id";
        }
    }
}
