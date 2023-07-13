
namespace Entity.Exceptions.Cart
{
    public class CartBadRequestException : BadRequestException
    {
        public CartBadRequestException(int id) 
            : base($"The Product already exist in cart id:{id}")
        {
        }
    }
}
