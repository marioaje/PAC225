using Microsoft.AspNetCore.Mvc;
using Sistema_de_Administracion.Data;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Administracion.Models;
using Microsoft.AspNetCore.Http.HttpResults;





namespace Sistema_de_Administracion.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        //Cuales son los metodos??? Update, Get, Add, Delete
        //Cuando se interactua con bd, ws, api, se debe de dejar tipo asyncronico
        //Get Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producto.ToListAsync());
        }

        //Get
        public IActionResult Crear() {
            return View();
        }

        //Significado de presionar un post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear( ProductoModel _producto)  
        {
            if (ModelState.IsValid) { 
                _context.Add(_producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(_producto);
        }

        //Consultar por id para cargar la informacion del edit
        //Get
        public async Task<IActionResult> Editar(int? _id)
        {
            if ( _id == null) {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(_id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }


        //Post: Producto/Editar/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar( int _id, ProductoModel _producto )
        {
            if ( _id != _producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(_producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(_producto);
        }



        //Consultar por id para cargar la informacion del eliminar
        //Get
        public async Task<IActionResult> Eliminar(int? _id)
        {
            if (_id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(m => m.Id == _id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }



        //Post: Producto/Editar/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int _id)
        {

            var producto = await _context.Producto.FindAsync(_id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
                await _context.SaveChangesAsync(    );
            }

            return RedirectToAction(nameof(Index));


            
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
