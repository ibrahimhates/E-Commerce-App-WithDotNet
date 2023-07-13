

namespace Entity.Exceptions.Cart
{
    public class CartNotFoundException : NotFoundException
    {
        public CartNotFoundException() 
            : base($"Cart could not found maybe is empty")
        {
        }
    }
}
