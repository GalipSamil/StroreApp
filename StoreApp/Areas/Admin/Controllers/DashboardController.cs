using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
