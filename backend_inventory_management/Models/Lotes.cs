using System.ComponentModel.DataAnnotations;

namespace backend_inventory_management.Models
{
    public partial class Lotes
    {
        [Key]
        public int Lote_id { get; set; }
        public string? Lote_nombre { get; set; }
    }
}