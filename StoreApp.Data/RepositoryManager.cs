using StoreApp.Data.Contracts;

namespace StoreApp.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly StoreAppContext _context;

        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(IProductRepository productRepository,ICategoryRepository categoryRepository, StoreAppContext context)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
 