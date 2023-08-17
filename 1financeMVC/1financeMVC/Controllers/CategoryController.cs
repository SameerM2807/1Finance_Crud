using Microsoft.AspNetCore.Mvc;

namespace _1financeMVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
