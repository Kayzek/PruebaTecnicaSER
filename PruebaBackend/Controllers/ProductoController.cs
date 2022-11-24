using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackend.Data;
using PruebaBackend.Models;

namespace PruebaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly ProductoDbContext dbContext;

        public ProductoController(ProductoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducto()
        {
            return Ok(await dbContext.Productos.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostProducto(AddProducto addProducto)
        {
            var producto = new Producto()
            {
                id = Guid.NewGuid(),
                nombreProducto = addProducto.nombreProducto,
                descripcionProducto = addProducto.descripcionProducto,
                precioCordoba = addProducto.precioCordoba,
                precioDolar = addProducto.precioDolar,
                estadoProducto = addProducto.estadoProducto
            };

            await dbContext.Productos.AddAsync(producto);
            await dbContext.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProducto([FromRoute] Guid id, UpdateProducto updateProducto)
        {
            var producto = await dbContext.Productos.FindAsync(id);

            if (producto != null)
            {
                producto.nombreProducto = updateProducto.nombreProducto;
                producto.descripcionProducto = updateProducto.descripcionProducto;
                producto.precioCordoba = updateProducto.precioCordoba;
                producto.precioDolar = updateProducto.precioDolar;
                producto.estadoProducto = updateProducto.estadoProducto;

                await dbContext.SaveChangesAsync();
                return Ok(producto);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] Guid id)
        {
            var producto = await dbContext.Productos.FindAsync(id);
            if (producto != null)
            {
                dbContext.Remove(producto);
                await dbContext.SaveChangesAsync();
                return Ok(producto);
            }

            return NotFound();
        }
    }
}
