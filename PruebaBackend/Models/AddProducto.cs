﻿namespace PruebaBackend.Models
{
    public class AddProducto
    {
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public double precioCordoba { get; set; }
        public double precioDolar { get; set; }
        public Boolean estadoProducto { get; set; }
    }
}
