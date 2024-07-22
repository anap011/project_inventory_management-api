using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_inventory_management.Models
{
    public partial class Productos
    {
        [Key]
        public int Producto_id { get; set; }
        public string? Producto_nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("lote_id")]
        public int Lote_id { get; set; }

        [ForeignKey("proveedor_id")]
        public int Proveedor_id { get; set; }
    }
}