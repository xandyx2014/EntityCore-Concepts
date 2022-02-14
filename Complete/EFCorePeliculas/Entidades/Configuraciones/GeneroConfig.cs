using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            // Configura el nombre de la tabla y el nombre de la esquema que se asiganara
            //builder.ToTable(name: "Genero", schema: "Pelicula");
            // se configura para que esta tabla se una tabla temporalde SQL server

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
            // un filtro que se aplica a nivel modelo  y se ejecuta en todas las rutas
            // Donde todas las conculstas se aplicara el
            // Where(g => !g.EstaBorrado)
            builder.HasQueryFilter(g => !g.EstaBorrado);
            // es unico si EstaBorrado = 'false'
            builder.HasIndex(g => g.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");
            // 
            builder.Property<DateTime>("FechaCreacion").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
        }
    }
}
