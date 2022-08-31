using Microsoft.AspNetCore.Mvc;

namespace MegaOneShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
