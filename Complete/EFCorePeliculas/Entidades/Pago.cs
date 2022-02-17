namespace EFCorePeliculas.Entidades
{
    // Tabla por herarquia
    // Clase para ser Heredada
    // toda esta clase y sus clases derivadas solo pertenecesaran a 1 sola tabla llamada Pago
    // no se crerara 1 tabla por cada herencia que se haga
    // todas las tablas heredades de esta solo pertenceran a 1 sola tabla
    public abstract class Pago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
