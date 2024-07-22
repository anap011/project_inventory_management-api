using backend_inventory_management.DTOs;
using backend_inventory_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace backend_inventory_management.Controllers
{
    [ApiController]
    [Route("v1/lotes")]
    public class LoteController : Controller
    {
        private Context _context;

        public LoteController(Context context, IConfiguration configuration)
        {
            _context = context;
        }


        // ---- READ

        [HttpGet]
        public async Task<IEnumerable<LoteDto>> GetLote() =>
            await _context.Lotes.Select(x => new LoteDto
            {
                Lote_Id = x.Lote_id,
                Lote_Nombre = x.Lote_nombre,
            }).ToListAsync();


        // -------- READ Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<LoteDto>> GetById(int id)
        {
            var lote = await _context.Lotes.FindAsync(id);
            if (lote == null) { 
                return NotFound();
            }

            var loteDto = new LoteDto()
            {
                Lote_Id = lote.Lote_id,
                Lote_Nombre = lote.Lote_nombre

            };
            return Ok(lote);
        }


        // ---- CREATE
        [HttpPost]
        public async Task<ActionResult<LoteDto>> Add([FromBody] LoteInsertDto loteInsertDto)
        {
            var lote = new Lotes()
            {
                Lote_nombre = loteInsertDto.Lote_Nombre
            };

            await _context.Lotes.AddAsync(lote);
            await _context.SaveChangesAsync();

            return Created();
        }


        // ---- UPDATE
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<LoteDto>> Update([FromBody] LoteUpdateDto loteUpdateDto, int id)
        {
            var lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            lote.Lote_nombre = loteUpdateDto.Lote_Nombre;

            await _context.SaveChangesAsync();
            return Ok();
        }



        // ---- DELETE
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var lote = await _context.Lotes.FindAsync(id);

            if (lote == null)
            {
                return NotFound();
            }

            _context.Lotes.Remove(lote);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
