using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_inventory_management.Models
{
    public partial class Proveedores
    {
        [Key]
        public int Proveedor_id { get; set; }
        public string? Proveedor_nombre { get; set; }
    }
}