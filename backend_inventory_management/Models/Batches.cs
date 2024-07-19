using System.ComponentModel.DataAnnotations;

namespace backend_inventory_management.Models
{
    public partial class Batches
    {
        [Key]
        public int Batch_id { get; set; }
        public string? Batch_name { get; set; }
    }
}