using Microsoft.EntityFrameworkCore;
using Sistema_de_Administracion.Models;

namespace Sistema_de_Administracion.Data
{
    //creamos el contexto de la conexion de la db
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        //Modelo ------------------ nombre de la tabla
        public DbSet<ProductoModel> Producto {get; set;}

        //Modelo ------------------ nombre de la tabla
        //servicio
        //usuarios
        //categorias
    }
}
