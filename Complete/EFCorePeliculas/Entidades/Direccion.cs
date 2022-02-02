using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    // ENTIDAD POR PROPIEDAD que se puede agregar en varias  Entidades
    // debe tener minimo 1 propiedad como required
    [Owned]
    public class Direccion
    {
        public string Calle { get; set; }
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }
    }
}
