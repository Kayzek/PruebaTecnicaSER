namespace PruebaBackend.Models
{
    public class AddCliente
    {
        // Campos a añadir a excepcion del id determinado por la funcion de guid
        public string nombreCompleto { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
