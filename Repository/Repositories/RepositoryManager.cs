using Repository.Repositories.Abstracts;
using Repository.UnitOfWorks;

namespace Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _basketRepository;
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IProductBasketRepository _productBasketRepository;
        public RepositoryManager(
            IProductRepository productRepository, ICategoryRepository categoryRepository,
            IAddressRepository addressRepository, IOrderRepository orderRepository,
            ICartRepository basketRepository, IProductOrderRepository productOrderRepository,
            IProductBasketRepository productBasketRepository, IUnitOfWork unitOfWork)
        {
            _productRepository=productRepository;
            _categoryRepository=categoryRepository;
            _addressRepository=addressRepository;
            _orderRepository=orderRepository;
            _basketRepository=basketRepository;
            _productOrderRepository=productOrderRepository;
            _productBasketRepository=productBasketRepository;
            _unitOfWork=unitOfWork;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IAddressRepository AddressRepository => _addressRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public ICartRepository CartRepository => _basketRepository;

        public IProductOrderRepository ProductOrderRepository => _productOrderRepository;

        public IProductBasketRepository ProductBasketRepository => _productBasketRepository;

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
