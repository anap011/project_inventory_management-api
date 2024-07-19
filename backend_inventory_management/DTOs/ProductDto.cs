﻿namespace backend_inventory_management.DTOs
{
    public class ProductDto
    {
        public int Product_id { get; set; }
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public int Batch_id { get; set; }
        public int Supplier_id { get; set; }
    }
}