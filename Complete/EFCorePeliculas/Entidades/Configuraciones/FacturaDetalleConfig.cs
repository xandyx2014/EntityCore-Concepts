using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class FacturaDetalleConfig : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            // Se configura la Columna Computed
            // se dividen en 2
            // las que guardan el valor final en la DB
            // las que no lo hacen en la DB
            builder.Property(f => f.Total)
                    .HasComputedColumnSql("Precio * Cantidad");
        }
    }
}
