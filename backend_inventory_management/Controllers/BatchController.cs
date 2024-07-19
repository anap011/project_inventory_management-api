using backend_inventory_management.DTOs;
using backend_inventory_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace backend_inventory_management.Controllers
{
    public class BatchController : Controller
    {
        private Context _context;

        public BatchController(Context context, IConfiguration configuration)
        {
            _context = context;
        }


        // ---- READ

        [HttpGet]
        [Route("/batch")]
        public async Task<IEnumerable<BatchDto>> GetBatch() =>
            await _context.Batches.Select(x => new BatchDto
            {
                Batch_Id = x.Batch_id,
                Batch_Name = x.Batch_name,
            }).ToListAsync();



        // -------- READ Id
        [HttpGet]
        [Route("/batch/id={id}")]
        public async Task<ActionResult<BatchDto>> GetById(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null) { 
                return NotFound();
            }

            var batchDto = new BatchDto()
            {
                Batch_Id = batch.Batch_id,
                Batch_Name = batch.Batch_name

            };
            return Ok(batch);
        }


        // ---- CREATE
        [HttpPost]
        [Route("/batch/create")]
        public async Task<ActionResult<BatchDto>> Add([FromBody] BatchInsertDto batchInsertDto)
        {
            var batch = new Batches()
            {
                Batch_name = batchInsertDto.Batch_Name
            };

            await _context.Batches.AddAsync(batch);
            await _context.SaveChangesAsync();

            return Created();
        }


        // ---- UPDATE
        [HttpPut]
        [Route("/batch/edit/id={id}")]
        public async Task<ActionResult<BatchDto>> Update([FromBody] BatchUpdateDto batchUpdateDto, int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            batch.Batch_name = batchUpdateDto.Batch_Name;

            await _context.SaveChangesAsync();
            return Ok();
        }



        // ---- DELETE
        [HttpDelete]
        [Route("/batch/delete/id={id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
