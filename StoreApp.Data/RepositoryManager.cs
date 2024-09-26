using StoreApp.Data.Contracts;

namespace StoreApp.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly StoreAppContext _context;

        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IOrderRepository _orderRepository;

        public RepositoryManager(IProductRepository productRepository,ICategoryRepository categoryRepository, StoreAppContext context,IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
 