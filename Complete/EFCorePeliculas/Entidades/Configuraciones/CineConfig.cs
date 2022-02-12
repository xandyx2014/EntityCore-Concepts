using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {

            builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

            builder.Property(prop => prop.Nombre)
              .HasMaxLength(150)
              .IsRequired();
            // CONFIGURACION 1 A 1 con ApiFluent
            // Cine tiene 1 CineOferte y 1 CineOferta tiene 1 Cine
            builder.HasOne(c => c.CineOferta)
                .WithOne()
                // configuracion cual sera la llave foreign si no sigue la conveccion de .net core
                .HasForeignKey<CineOferta>(co => co.CineId);
            // CONFIGURACIOn 1 a MUCHOS
            // 1 cine tiene muchas SalasDeCine y 1 SalasDeCine tiene 1 Cine
            builder.HasMany(c => c.SalasDeCine)
                .WithOne(s => s.Cine)
                .HasForeignKey(s => s.ElCine)
                // Cascade
                // Cliente Cascade
                // No action
                // Client No Action
                // Restrict
                // Set Null
                // Client Set Null
                .OnDelete(DeleteBehavior.Cascade);
            // 1 Cine Tiene 1 CineDetalle y 1 CineDetalle 1 Cine 
            builder.HasOne(c => c.CineDetalle).WithOne(cd => cd.Cine)
                .HasForeignKey<CineDetalle>(cd => cd.Id);
            // Configurar las Entidades de propiedad 
            // Configurarmos el nombre por default 
            builder.OwnsOne(c => c.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Provincia).HasColumnName("Provincia");
                dir.Property(d => d.Pais).HasColumnName("Pais");
            });
        }
    }
}
