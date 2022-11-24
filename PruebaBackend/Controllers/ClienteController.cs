using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackend.Data;
using PruebaBackend.Models;

namespace PruebaBackend.Controllers
{
    // Definir que se trata de un controlador API
    // Ubicar ruta de controlador
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClienteDbContext dbContext;

        // Inyectar los contextos de los datos
        public ClienteController(ClienteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Definir metodos http
        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            return Ok(await dbContext.Clientes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(AddCliente addCliente)
        {
            var cliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                nombreCompleto = addCliente.nombreCompleto,
                Telefono = addCliente.Telefono,
                Direccion = addCliente.Direccion
            };

            await dbContext.Clientes.AddAsync(cliente);
            await dbContext.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCliente([FromRoute] Guid id, UpdateCliente updateCliente)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);

            if (cliente != null)
            {
                cliente.nombreCompleto = updateCliente.nombreCompleto;
                cliente.Telefono = updateCliente.Telefono;
                cliente.Direccion = updateCliente.Direccion;

                await dbContext.SaveChangesAsync();
                return Ok(cliente);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] Guid id)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);
            if (cliente != null)
            {
                dbContext.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return Ok(cliente);
            }

            return NotFound();
        }
    }
}
