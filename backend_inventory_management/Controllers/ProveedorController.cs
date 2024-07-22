using backend_inventory_management.DTOs;
using backend_inventory_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_inventory_management.Controllers
{
    [ApiController]
    [Route("v1/proveedores")]
    public class ProveedorController : Controller
    {
        private Context _context;
        public ProveedorController(Context context, IConfiguration configuration)
        {
            _context = context;
        }

        //-----READ
        
        [HttpGet]
        public async Task<IEnumerable<ProveedorDto>> GetProveedor() =>
            await _context.Proveedores.Select(x => new ProveedorDto
            {
                Proveedor_Id = x.Proveedor_id,
                Proveedor_Nombre = x.Proveedor_nombre
            }).ToListAsync();

        //----READ ID

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProveedorDto>> GetById(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) { 
                return NotFound();
            }
            var proveedorDto = new ProveedorDto
            {
                Proveedor_Id = proveedor.Proveedor_id,
                Proveedor_Nombre = proveedor.Proveedor_nombre
            };

            return Ok(proveedorDto);
        }

        //-----CREATE

        [HttpPost]
        public async Task<ActionResult<ProveedorDto>> Add([FromBody] ProveedorInsertDto proveedorInsertDto)
        {
            var proveedor = new Proveedores()
            {
                Proveedor_nombre = proveedorInsertDto.Proveedor_Nombre
            };

            await _context.Proveedores.AddAsync(proveedor);
            await _context.SaveChangesAsync();
            return Created();
        }

        //-----EDIT

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProveedorDto>> Update([FromBody] ProveedorUpdateDto proveedorUpdateDto, int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null){
                return NotFound();
            }

            proveedor.Proveedor_nombre = proveedorUpdateDto.Proveedor_Nombre;

            await _context.SaveChangesAsync();
            return Ok();
        }

        //-------DELETE

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
