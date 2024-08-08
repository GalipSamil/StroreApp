using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data;
using StoreApp.Entities;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreAppContext _context;

        public ProductController(StoreAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Products.ToList();
            return View(model);
        }
    }
}
