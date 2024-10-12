using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StoreApp.Data.Contracts;
using StoreApp.Data.Extensions;
using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;
using System.Runtime.CompilerServices;

namespace StoreApp.Data
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository // sealed class tanımlarsak birdaha inherit edilemiyor
    {
        public ProductRepository(StoreAppContext context) : base(context)
        {

        }
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);


        // İnterface
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }

        public void CreateProduct(Product product) => Create(product);

        public void CreateOneProduct(Product product) => Create(product);


        public void DeleteOneProduct(Product product) => Remove(product);

        public void UpdateOneProduct(Product entity) => Update(entity);

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(P => P.ShowCase.Equals(true));
        }

        public IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p)
        {
            return _context
                .Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                .ToPaginate(p.PageNumber, p.PageSize);
                
        }

      


    }
}
