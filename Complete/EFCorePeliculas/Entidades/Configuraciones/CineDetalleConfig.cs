using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineDetalleConfig : IEntityTypeConfiguration<CineDetalle>
    {
        public void Configure(EntityTypeBuilder<CineDetalle> builder)
        {
            // DIVISION DE TABLAS 
            // hace referencia a una tabla ya creada en la Base de datos
            // donde este agregara la properties a la tabla
            // sirve para dividir 2 entidades en 1 tabla
            builder.ToTable("Cines");
        }
    }
}
