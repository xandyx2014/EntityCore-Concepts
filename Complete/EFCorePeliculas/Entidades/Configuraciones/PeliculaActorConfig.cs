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
            // PeliculaACtor tiene 1 PeliculaAcctor y 1 PeliculaACtor tiene muchos Actor
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
