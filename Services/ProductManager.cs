using Services.Contracts;
using StoreApp.Entities.Models;
using StoreApp.Data;
using StoreApp.Data.Contracts;
using System.Runtime.CompilerServices;

namespace Services
{
    public class ProductManager :IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if(product is not null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }
            
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

        public void UpdateOneProduct(Product product)
        {
            var entity = _manager.Product.GetOneProduct(product.ProductId, true);
            if (entity ==null)
            {
                throw new Exception("entity don't be null");
                
            }  
            else
            {
                entity.ProductName = product.ProductName;
            }
            entity.Price = product.Price;
            _manager.Save();
        }

        void IProductService.CreateProduct(Product product)
        {
            _manager.Product.Create(product);
            _manager.Save();
        }

        
    }
    

    
}
