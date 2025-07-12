using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }                
        public bool IsActive { get; set; }
        public string Marca { get; set; }
    }
}
