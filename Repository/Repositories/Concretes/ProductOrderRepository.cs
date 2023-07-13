using Entity.Models;
using Repository.Repositories.Abstracts;

namespace Repository.Repositories.Concretes
{
    public class ProductOrderRepository :
        GenericRepositoryBase<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(ETContext context) : base(context)
        {
        }
    }
}
