﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(prop => prop.Titulo)
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(prop => prop.PosterURL)
                .HasMaxLength(500)
                // valor que habilita el Unicode
                .IsUnicode(false);
            // RELACION SIN TABLA INTERMEDIA MAPEADA
            // En este no se esta utilizando una tabla intermediaria SkipNavigation

            // Pelicula tiene Muchos Generos, 1 Genero tiene muchas Peliculas
            //builder.HasMany(p => p.Generos)
            //    .WithMany(g => g.Peliculas)
            //    .UsingEntity(j => 
            //        j.ToTable("GenerosPeliculas")
            //        .HasData(new { PeliculasId = 1, GenerosIdentificador = 7 })
            //        );
        }
    }
}
