namespace PruebaBackend.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string nombreCompleto { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }

    }
}
