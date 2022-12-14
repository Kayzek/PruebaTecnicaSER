using Microsoft.EntityFrameworkCore;
using PruebaBackend.Models;

namespace PruebaBackend.Data
{
    public class ProductoDbContext: DbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}
