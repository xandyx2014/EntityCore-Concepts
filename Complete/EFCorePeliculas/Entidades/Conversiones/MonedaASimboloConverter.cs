using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePeliculas.Entidades.Conversiones
{
    public class MonedaASimboloConverter : ValueConverter<Moneda, string>
    {
        public MonedaASimboloConverter()
            : base(
                    valor => MapeoMonedaString(valor),
                    valor => MapeoStringMoneda(valor)
                 )
        {

        }
        // para guardar
        private static string MapeoMonedaString(Moneda valor)
        {
            return valor switch
            {
                Moneda.PesoDominicano => "RD$",
                Moneda.DolarEstadounidense => "$",
                Moneda.Euro => "€",
                _ => ""
            };
        }
        // para obtener
        private static Moneda MapeoStringMoneda(string valor)
        {
            return valor switch
            {
                "RD$" => Moneda.PesoDominicano,
                "$" => Moneda.DolarEstadounidense,
                "€" => Moneda.Euro,
                _ => Moneda.Desconocida
            };
        }
    }
}
