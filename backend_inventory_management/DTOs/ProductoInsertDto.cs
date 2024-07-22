namespace backend_inventory_management.DTOs
{
    public class ProductoInsertDto
    {
        public string? Producto_Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Lote_id { get; set; }
        public int Proveedor_id { get; set; }
    }
}