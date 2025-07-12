using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
