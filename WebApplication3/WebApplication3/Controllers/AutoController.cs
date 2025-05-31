using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AutoController : Controller
    {
        #region propiedades

        private static List<AutoModel> autoDatos = new List<AutoModel>();

        #endregion

        #region eventos
        public IActionResult Index()
        {
            return View(autoDatos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        //Busca y encuentra el elemto y lo carga en el formulario
        public IActionResult Eliminar(int id)
        {
            var _autoDatos = autoDatos.FirstOrDefault(x => x.Id == id);

            if (_autoDatos == null) 
            {
                return NotFound();
            }

             return View(_autoDatos);

        }

        public IActionResult Editar(int id)
        {
            var _autoDatos = autoDatos.FirstOrDefault(x => x.Id == id);

            if (_autoDatos == null)
            {
                return NotFound();
            }

            return View(_autoDatos);

        }

        [HttpPost, ActionName("EliminarRegistro")]
        public IActionResult EliminarRegistro(int id)
        {
            var _autoDatos = autoDatos.FirstOrDefault(x => x.Id == id);

            if (_autoDatos != null)
            {
                autoDatos.Remove(_autoDatos);
            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Crear(AutoModel _autoDatos)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //Almacena los datos
                    _autoDatos.Id = autoDatos.Count + 1;
                    autoDatos.Add(_autoDatos);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudo almacenar");
            }

            return View(_autoDatos);
        }


        [HttpPost]
        public IActionResult Editar(AutoModel _autoDatos)
        {
            var _autoVerificarDatos = autoDatos.FirstOrDefault(x => x.Id == _autoDatos.Id);

            if (_autoVerificarDatos == null)
            {
                return NotFound();
            }

            _autoVerificarDatos.Name = _autoDatos.Name;
            _autoVerificarDatos.Description = _autoDatos.Description;
            _autoVerificarDatos.IsActive = _autoDatos.IsActive;
            _autoVerificarDatos.Marca = _autoDatos.Marca;

            return RedirectToAction("Index");

            
        }

        #endregion 




    }
}
