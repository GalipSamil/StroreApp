using StoreApp.Data.Contracts;
using StoreApp.Entities.Models;

namespace StoreApp.Data
{
    public  class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(StoreAppContext context): base(context)
        {

        } 
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);


        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        } 
        
            
        
    }
}
