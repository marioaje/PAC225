using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
