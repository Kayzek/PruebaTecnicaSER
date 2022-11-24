namespace PruebaBackend.Models
{
    public class TasaCambio
    {
        public Guid id { get; set; }
        public DateTime fecha { get; set; }
        public double dolarCordoba { get; set; }
        public double cordobaDolar { get; set; }
    }
}
