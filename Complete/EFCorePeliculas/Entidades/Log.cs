using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Log
    {
        // para evitar que se autogenera el uid y lo manejemos nosotros
        // para genearar un Guui.NewGuid()
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Mensaje { get; set; }
        public string Ejemplo { get; set; }
    }
}
