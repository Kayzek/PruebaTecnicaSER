using Microsoft.EntityFrameworkCore;
using PruebaBackend.Models;

namespace PruebaBackend.Data
{
    public class ClienteDbContext: DbContext
    {
        public ClienteDbContext(DbContextOptions <ClienteDbContext>options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
