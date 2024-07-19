using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_inventory_management.Models
{
    public partial class Suppliers
    {
        [Key]
        public int Supplier_id { get; set; }
        public string? Supplier_name { get; set; }
    }
}