using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;

namespace StoreApp.Data.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        
        IQueryable<Product> GetAllProducts(bool trackChanges);

        IQueryable<Product> GetShowcaseProducts(bool trackChanges);

        IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p);

        Product? GetOneProduct(int id,bool trackChanges);

        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product entity);

    }
}