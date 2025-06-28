namespace Sistema_de_Administracion.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }        
        public bool IsActive { get; set; }
        public string Marca { get; set; }
    }
}
