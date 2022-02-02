using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class SalaDeCine : IId
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int ElCine { get; set; }
        // para especificar que el llave foreign sea esto
        // esto puede server cuando no seguimos por conveccion el nombre que seria CineId
        [ForeignKey(nameof(ElCine))]
        public Cine Cine { get; set; }
        // relacion por Convencion
        public HashSet<Pelicula> Peliculas { get; set; }
        public Moneda Moneda { get; set; }
    }
}
