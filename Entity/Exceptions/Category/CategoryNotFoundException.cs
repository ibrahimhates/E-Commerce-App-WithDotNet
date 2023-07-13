
namespace Entity.Exceptions.Category
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id)
            : base($"Category could not found with id: {id}")
        {
        }
    }
}
