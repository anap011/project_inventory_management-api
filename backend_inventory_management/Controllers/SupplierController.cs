using backend_inventory_management.DTOs;
using backend_inventory_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_inventory_management.Controllers
{
    public class SupplierController : Controller
    {
        private Context _context;
        public SupplierController(Context context, IConfiguration configuration)
        {
            _context = context;
        }

        //-----READ
        
        [HttpGet]
        [Route("/supplier")]
        public async Task<IEnumerable<SupplierDto>> GetSupplier() =>
            await _context.Suppliers.Select(x => new SupplierDto
            {
                Supplier_Id = x.Supplier_id,
                Supplier_Name = x.Supplier_name
            }).ToListAsync();

        //----READ ID

        [HttpGet]
        [Route("/supplier/id={id}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) { 
                return NotFound();
            }
            var supplierDto = new SupplierDto
            {
                Supplier_Id = supplier.Supplier_id,
                Supplier_Name = supplier.Supplier_name
            };

            return Ok(supplierDto);
        }

        //-----CREATE

        [HttpPost]
        [Route("/supplier/create")]
        public async Task<ActionResult<SupplierDto>> Add([FromBody] SupplierInsertDto supplierInsertDto)
        {
            var supplier = new Suppliers()
            { 
                Supplier_name = supplierInsertDto.Supplier_Name
            };

            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return Created();
        }

        //-----EDIT

        [HttpPut]
        [Route("/supplier/edit/id={id}")]
        public async Task<ActionResult<SupplierDto>> Update([FromBody] SupplierUpdateDto supplierUpdateDto, int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null){
                return NotFound();
            }

            supplier.Supplier_name = supplierUpdateDto.Supplier_Name;

            await _context.SaveChangesAsync();
            return Ok();
        }

        //-------DELETE

        [HttpDelete]
        [Route("/supplier/delete/id={id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
