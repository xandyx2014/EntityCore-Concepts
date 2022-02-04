using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        // Propiedad de Secuencia
        public int NumeroFactura { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
