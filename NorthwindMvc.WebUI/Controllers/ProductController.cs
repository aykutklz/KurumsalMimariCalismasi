using Microsoft.AspNetCore.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
