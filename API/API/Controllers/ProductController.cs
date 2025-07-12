using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        //private readonly AppDbContext _context;
        //analogia
        private readonly ProductoService _productoService;

        //public ProductController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //Analogia
        public ProductController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        //Apis GET, POST, PUT   y DELETE

        //Apis GET
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProducto()
        {            
            return  _productoService.GetProducto();            
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            return _productoService.GetById(id);
        }

        [HttpPost]
        public ActionResult<Producto> AddProducto(Producto producto)
        {
            
            var newProducto = _productoService.AddProducto(producto);

            return
                CreatedAtAction(                    
                        nameof(GetProducto), new
                        {
                            id = newProducto.Id,
                        }, 
                        newProducto);

        }

        [HttpPut]
        public IActionResult UpdateProducto(Producto producto)
        {

            if (!_productoService.UpdateProducto(producto))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El producto no esta"
                        }
                    );
            }
         
            return NoContent();

        }

        [HttpDelete]
        public IActionResult DeleteProducto(int id)
        {

            if (!_productoService.DeleteProducto(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El producto no esta"
                        }
                    );
            }

            return NoContent();

        }


    }
}
