
namespace Entity.Exceptions.Product
{
    public class ProductBadRequestException : BadRequestException
    {
        public ProductBadRequestException(int id) 
            : base($"An incorrect request for products. Category not found with id:{id} ")
        {
        }
    }
}
