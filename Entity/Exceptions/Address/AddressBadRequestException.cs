
namespace Entity.Exceptions.Address
{
    public class AddressBadRequestException : BadRequestException
    {
        public AddressBadRequestException(int id) 
            : base($"An incorrect request for address. No user found for the address to be added id:{id}")
        {
        }
    }
}
