using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackend.Data;
using PruebaBackend.Models;

namespace PruebaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasaCambioController : Controller
    {
        private readonly TasaCambioDbContext dbContext;

        public TasaCambioController(TasaCambioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasa()
        {
            return Ok(await dbContext.TasaCambios.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostTasa(AddTasaCambio addTasaCambio)
        {
            var tasa = new TasaCambio()
            {
                id = Guid.NewGuid(),
                fecha = DateTime.Today.AddDays(1),
                dolarCordoba = addTasaCambio.dolarCordoba,
                cordobaDolar = addTasaCambio.cordobaDolar
            };

            await dbContext.TasaCambios.AddAsync(tasa);
            await dbContext.SaveChangesAsync();
            return Ok(tasa);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTasa([FromRoute] Guid id, UpdateTasa updateTasa)
        {
            var tasa = await dbContext.TasaCambios.FindAsync(id);

            if (tasa != null)
            {
                tasa.dolarCordoba = updateTasa.dolarCordoba;
                tasa.cordobaDolar = updateTasa.cordobaDolar;

                await dbContext.SaveChangesAsync();
                return Ok(tasa);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTasa([FromRoute] Guid id)
        {
            var tasa = await dbContext.TasaCambios.FindAsync(id);
            if (tasa != null)
            {
                dbContext.Remove(tasa);
                await dbContext.SaveChangesAsync();
                return Ok(tasa);
            }

            return NotFound();
        }
    }
}
