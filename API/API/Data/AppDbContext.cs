using Microsoft.EntityFrameworkCore;
using API.Models;


namespace API.Data
{
    //creamos el contexto de la conexion de la db
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        //Modelo ------------------ nombre de la tabla
        public DbSet<Producto> Producto {get; set;}

        //Modelo ------------------ nombre de la tabla
        //servicio
        //usuarios
        //categorias
    }
}
