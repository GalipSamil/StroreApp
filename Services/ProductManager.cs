using Services.Contracts;
using StoreApp.Entities.Models;
using StoreApp.Data;
using StoreApp.Data.Contracts;

namespace Services
{
    public class ProductManager :IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChnages)
        {
            return _manager.Product.GetAllProducts(trackChnages);
        }
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if(product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }
    }
    

    
}
