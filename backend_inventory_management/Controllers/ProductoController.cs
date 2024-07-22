using backend_inventory_management.DTOs;
using backend_inventory_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_inventory_management.Controllers
{
    [ApiController]
    [Route("v1/productos")]
    public class ProductoController : Controller
    {
        private readonly Context _context;

        public ProductoController(Context context, IConfiguration configuration)
        {
            _context = context;
        }

        //-----READ

        [HttpGet]
        public async Task<IEnumerable<ProductoDto>> GetProducto() =>
            await _context.Productos.Select(x => new ProductoDto
            {
                Producto_Id = x.Producto_id,
                Producto_Nombre = x.Producto_nombre,
                Descripcion = x.Descripcion,
                Cantidad = x.Cantidad,
                Lote_id = x.Lote_id,
                Proveedor_id = x.Proveedor_id,
            }).ToListAsync();


        //-------- READ Id

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductoDto>> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            };

            var productoDto = new ProductoDto
            {
                Producto_Id = producto.Producto_id,
                Producto_Nombre = producto.Producto_nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,
                Lote_id = producto.Lote_id,
                Proveedor_id = producto.Proveedor_id
            };
            return Ok(productoDto);
        }


        // ------CREATE

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Add([FromBody] ProductoInsertDto productoInsertDto)
        {
            var producto = new Productos()
            //product se relaciona al modelo de la base de datos
            {
                Producto_nombre = productoInsertDto.Producto_Nombre,
                Descripcion = productoInsertDto.Descripcion,
                Cantidad = productoInsertDto.Cantidad,
                Lote_id = productoInsertDto.Lote_id,
                Proveedor_id = productoInsertDto.Proveedor_id
            };

            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync(); // Se representan los cambios en la base de datos

            return Created();
        }


        // ---------- UPDATE

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProductoDto>> Update([FromBody] ProductoUpdateDto productoUpdateDto, int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Producto_nombre = productoUpdateDto.Producto_Nombre;
            producto.Descripcion = productoUpdateDto.Descripcion;
            producto.Cantidad = productoUpdateDto.Cantidad;
            producto.Lote_id = productoUpdateDto.Lote_id;
            producto.Proveedor_id = productoUpdateDto.Proveedor_id;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // ---------- DELETE
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}