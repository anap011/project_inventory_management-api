using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_inventory_management.Models
{
    public partial class Products
    {
        [Key]
        public int Product_id { get; set; }
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }

        [ForeignKey("batch_id")]
        public int Batch_id { get; set; }

        [ForeignKey("supplier_id")]
        public int Supplier_id { get; set; }
    }
}