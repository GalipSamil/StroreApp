using Services.Contracts;
using StoreApp.Entities.Models;
using StoreApp.Data;
using StoreApp.Data.Contracts;
using System.Runtime.CompilerServices;
using StoreApp.Entities.Dtos;
using AutoMapper;
using DocumentFormat.OpenXml.ExtendedProperties;
using StoreApp.Entities.RequestParameters;

namespace Services
{
    public class ProductManager :IProductService
    {
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            /*if (entity ==null)
            {
                throw new Exception("entity don't be null");
                
            }  
            else
            {
                entity.ProductName = productDto.ProductName;
            }*/
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);  
            _manager.Save();
        }

        public void CreateProduct(ProductDtoForInsertion productDto)

        {
            Product product=_mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
            var products = _manager.Product.GetShowcaseProducts(trackChanges);
            return products;
        }

       

        public IEnumerable<Product> GetAllProductWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductWithDetails(p);
        }

        public IEnumerable<Product> GetLatestProducts(int n, bool trackChanges)
        {
            return _manager
                .Product
                .FindAll(trackChanges)
                .OrderByDescending(prd => prd.ProductId)
                .Take(n);
        }
    }
        
}
