
namespace Entity.Exceptions.Product
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) 
            : base($"Product could not found with id : {id}")
        {
        }
    }
}
