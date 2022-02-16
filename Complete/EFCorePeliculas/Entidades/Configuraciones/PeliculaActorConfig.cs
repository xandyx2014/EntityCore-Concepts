using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(prop =>
             new { prop.PeliculaId, prop.ActorId });
            // ======= [Con clase Intermediaria] ==============
            // PeliculaActor tiene 1 Actor y 1 Actor tiene muchos PeliculaActores
            builder.HasOne(pa => pa.Actor)
                    .WithMany(a => a.PeliculasActores)
                    .HasForeignKey(pa => pa.ActorId);
            // PeliculaACtor tiene 1 Pelicula, 1 Pelicula tiene muchas PeliculaActores atraves de PeliculaId
            builder.HasOne(pa => pa.Pelicula)
                    .WithMany(p => p.PeliculasActores)
                    .HasForeignKey(pa => pa.PeliculaId);

            builder.Property(prop => prop.Personaje)
                .HasMaxLength(150);
        }
    }
}
