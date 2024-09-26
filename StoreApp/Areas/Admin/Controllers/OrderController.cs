using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controller
{
    public class OrderController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
