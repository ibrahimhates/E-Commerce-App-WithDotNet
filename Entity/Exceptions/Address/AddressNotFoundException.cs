
namespace Entity.Exceptions.Address
{
    public class AddressNotFoundException : NotFoundException
    {
        public AddressNotFoundException(int id) 
            : base($"Address could not found with id:{id}")
        {
        }
    }
}
