
namespace Entity.Exceptions.Address
{
    public class AddressBadRequestException : BadRequestException
    {
        public AddressBadRequestException(int id) 
            : base($"An incorrect request for address. Address already exist with userId:{id}")
        {
        }
    }
}
