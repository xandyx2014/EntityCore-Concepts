using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entidades
{
    // Esta clase se esta utilizando como division de clases
    public class CineDetalle
    {
        public int Id { get; set; }
        // es necesarioq ue teng un campo requerido
        [Required]
        public string Historia { get; set; }
        public string Valores { get; set; }
        public string Misiones { get; set; }
        public string CodigoDeEtica { get; set; }
        public Cine Cine { get; set; }
    }
}
