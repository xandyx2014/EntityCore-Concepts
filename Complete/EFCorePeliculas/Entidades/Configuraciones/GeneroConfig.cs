using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            // se configura para que esta tabla se una tabla temporal
            builder.ToTable(name: "Generos", opciones =>
            {
                opciones.IsTemporal();
            });
            // estas dos columnas son necesarias para las tablas temporales
            builder.Property("PeriodStart").HasColumnType("datetime2");
            builder.Property("PeriodEnd").HasColumnType("datetime2");

            builder.HasKey(prop => prop.Identificador);
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasQueryFilter(g => !g.EstaBorrado);
            // es unico si EstaBorrado = 'false'
            builder.HasIndex(g => g.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");
            // 
            builder.Property<DateTime>("FechaCreacion").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
        }
    }
}
