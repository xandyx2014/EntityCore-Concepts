namespace EFCorePeliculas.Entidades
{
    // Clase para ser Heredada
    // toda esta clase y sus clases derivadas solo pertenecesaran a 1 sola tabla llamada Pago
    // no se crerara 1 tabla por cada herencia que se haga
    public abstract class Pago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
