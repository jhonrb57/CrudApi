using System.ComponentModel.DataAnnotations;

namespace CrudApi.Models
{
    public class Inventario
    {
        [Key]
        public string? IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Cantidad { get; set; }
        public string? Categoria { get; set; }
        public string? Descuento { get; set; }
    }
}
