using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
