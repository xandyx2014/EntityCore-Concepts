using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades
{
    // Tabla para herencia por TIPO para ser usado Herencia - Tabla por tipo
    // Tabla por tipo por cada herencia que se herede
    // se creara cada tabla por cada herencia que se hace
    // siempre y cuando utilziando es .ToTable
    public abstract class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Precision(18, 2)]
        public decimal Precio { get; set; }
    }
}
