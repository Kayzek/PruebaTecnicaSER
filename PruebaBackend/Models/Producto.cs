namespace PruebaBackend.Models
{
    public class Producto
    {
        public Guid id { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public double precioCordoba { get; set; }
        public double precioDolar { get; set; }
        public Boolean estadoProducto { get; set; }
    }
}
