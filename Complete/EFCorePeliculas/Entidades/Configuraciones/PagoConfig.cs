using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PagoConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            // TABLA POR HERENQUIA

            // Se configura la clase  para acceder a las clases derivadas
            // el descriminador es el tipo que seleccionara que clase derivada se usara
            // esta propiedad decide cual clase heredada se usara
            // para poder estarer el datoe es necesario pasarle el tipo 
            //  await context.Pagos.OfType<PagoTarjeta>().ToListAsync();
            //  await context.Pagos.OfType<PagoPaypal>().ToListAsync();
            builder.HasDiscriminator(p => p.TipoPago)
                // Si El TipoPago es Paypal, entonces devolvera una Entidad PagoPaypal
                .HasValue<PagoPaypal>(TipoPago.Paypal)
                // Si El TipoPago es Tarjeta, entonces devolvera una Entidad PagoTarjeta
                .HasValue<PagoTarjeta>(TipoPago.Tarjeta);

            builder.Property(p => p.Monto).HasPrecision(18, 2);
        }
    }
}
