
namespace Entity.Exceptions.Order
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int id) 
            : base($"Order could not found with id:{id}")
        {
        }
    }
}
