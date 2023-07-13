using Entity.Models;
using Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Concretes
{
    public class ProductBasketRepository :
        GenericRepositoryBase<ProductBasket>, IProductBasketRepository
    {
        public ProductBasketRepository(ETContext context) : base(context)
        {
        }
    }
}
