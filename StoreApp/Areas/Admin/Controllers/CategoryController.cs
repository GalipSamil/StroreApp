using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.ControllerS
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
