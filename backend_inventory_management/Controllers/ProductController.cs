using backend_inventory_management.DTOs;
using backend_inventory_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_inventory_management.Controllers
{

    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context, IConfiguration configuration)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ProductDto>> GetProductA() =>
            await _context.Products.Select(x => new ProductDto
            {
                Product_id = x.Product_id,
                Product_Name = x.Product_Name,
                Description = x.Description,
                Stock = x.Stock,
                Batch_id = x.Batch_id,
                Supplier_id = x.Supplier_id,
            }).ToListAsync();



        //-----READ

        [HttpGet]
        [Route("/product")]
        public async Task<IEnumerable<ProductDto>> GetProduct() =>
            await _context.Products.Select(x => new ProductDto
            {
                Product_id = x.Product_id,
                Product_Name = x.Product_Name,
                Description = x.Description,
                Stock = x.Stock,
                Batch_id = x.Batch_id,
                Supplier_id = x.Supplier_id,
            }).ToListAsync();


        //-------- READ Id

        [HttpGet]
        [Route("/product/id={id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            };

            var productDto = new ProductDto
            {
                Product_id = product.Product_id,
                Product_Name = product.Product_Name,
                Description = product.Description,
                Stock = product.Stock,
                Batch_id = product.Batch_id,
                Supplier_id = product.Supplier_id
            };
            return Ok(productDto);
        }


        // ------CREATE

        [HttpPost]
        [Route("/product/create")]
        public async Task<ActionResult<ProductDto>> Add([FromBody] ProductInsertDto productInsertDto)
        {
            var product = new Products()
            //product se relaciona al modelo de la base de datos
            {
                Product_Name = productInsertDto.Product_Name,
                Description = productInsertDto.Description,
                Stock = productInsertDto.Stock,
                Batch_id = productInsertDto.Batch_id,
                Supplier_id = productInsertDto.Supplier_id
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(); // Se representan los cambios en la base de datos

            return Created();
        }


        // ---------- UPDATE

        [HttpPut]
        [Route("/product/edit/id={id}")]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductUpdateDto productUpdateDto, int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Product_Name = productUpdateDto.Product_Name;
            product.Description = productUpdateDto.Description;
            product.Stock = productUpdateDto.Stock;
            product.Batch_id = productUpdateDto.Batch_id;
            product.Supplier_id = productUpdateDto.Supplier_id;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // ---------- DELETE
        [HttpDelete]
        [Route("/product/delete/id={id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}