using Microsoft.EntityFrameworkCore;
using PruebaBackend.Models;

namespace PruebaBackend.Data
{
    public class TasaCambioDbContext: DbContext
    {
        public TasaCambioDbContext(DbContextOptions<TasaCambioDbContext> options) : base(options) { }
        public DbSet<TasaCambio> TasaCambios { get; set; }
    }
}
