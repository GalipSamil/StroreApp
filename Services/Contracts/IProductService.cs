using StoreApp.Entities.Dtos;
using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;
namespace Services.Contracts
{
    public interface  IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);

        IEnumerable<Product> GetLatestProducts(int n, bool trackChanges);
        
        Product? GetOneProduct(int id, bool trackChanges);

        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);

        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);

        IEnumerable<Product> GetAllProductWithDetails(ProductRequestParameters p);
        
    }
}
