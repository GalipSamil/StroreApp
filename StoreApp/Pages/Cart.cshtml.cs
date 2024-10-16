using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Entities.Models;


namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        
        public CartModel(IServiceManager manager, Cart cartService)
        {
            Cart = cartService;
            _manager = manager;
        }
        public Cart Cart { get; set; } // Ioc

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string ReturnUrl)
        {
            ReturnUrl = ReturnUrl ?? "/";
            // Cart = HttpContext.Session.GetJson<Cart>("cart"); ?? new Cart();
        }

        public IActionResult OnPost(int productId,string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId, false);

            if (product is not null)
            {
               // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl}); // returnUrl
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
           // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(c1 => c1.Product.ProductId.Equals(id)).Product);
            //HttpContext.Session.SetJson<Cart>("cart",Cart)
            return Page();
        }
    }
}
