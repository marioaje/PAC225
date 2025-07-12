using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ProductoService
    {

        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<Producto> _products = new List<Producto>();
        private int _nextId = 1;


        //funcion de obtener productos
        public List<Producto> GetProducto()
        { 
                return _context.Producto.ToList(); 
        }


        public Producto GetById(int id) {
            return _context.Producto.FirstOrDefault(p=> p.Id == id);
        }

        public Producto AddProducto(Producto producto)
        {
            // Se autogenra_nextId
            //producto.Id = _nextId++;
            _context.Producto.Add(producto);
            _context.SaveChanges();
            return producto;
        }


        public bool UpdateProducto(Producto producto)
        {
            var entidad =  _context.Producto.FirstOrDefault(p => p.Id == producto.Id);

            if (entidad == null) {
                return false;
            }

            entidad.Name = producto.Name;
            entidad.Descripcion = producto.Descripcion;
            entidad.IsActive = producto.IsActive;
            entidad.Marca = producto.Marca;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteProducto(int id)
        {
            var entidad = _context.Producto.FirstOrDefault(p => p.Id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.Producto.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
