using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    // ENTIDAD POR PROPIEDAD que se puede agregar en varias  Entidades
    // debe tener minimo 1 propiedad como required
    // El Owned es el attributed que pertenece a otra entidad
    // Por defecto se creara como Direccion_Calle, Dirrecion_Provincia, Dirrecion_Pais
    [Owned]
    public class Direccion
    {
        public string Calle { get; set; }
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }
    }
}
