using Microsoft.AspNetCore.Mvc;
using StoreApp.Data;

namespace StoreApp.Components
{
    public class ProductSummary : ViewComponent 
    {
        private readonly StoreAppContext _context;

        public ProductSummary(StoreAppContext context)
        {
            _context = context;
        }    
        
        public string Imvoke()
        {
            return _context.Products
        }
    }
}
