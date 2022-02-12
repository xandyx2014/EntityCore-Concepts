using System.ComponentModel.DataAnnotations;


namespace EFCorePeliculas.Entidades
{
    // crear un indice de la DB
    //  [Index(nameof(Nombre), IsUnique = true)]
    public class Genero : EntidadAuditable
    {
        public int Identificador { get; set; }
        // Checka la concurrencia cuando el campo es editado al mismo Tiempo
        [ConcurrencyCheck]
        public string Nombre { get; set; }
        public bool EstaBorrado { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
        public string Ejemplo { get; set; }
    }
}
