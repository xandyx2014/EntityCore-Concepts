using EFCorePeliculas.Entidades.Conversiones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);

            builder.Property(prop => prop.TipoSalaDeCine)
                // Colocamos el default Value en este caso le colocamos un Enum
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones)
                // conversacion a un tipo
                .HasConversion<string>();

            builder.Property(prop => prop.Moneda)
                // Conversasciones personalziadas
                .HasConversion<MonedaASimboloConverter>();
        }
    }
}
