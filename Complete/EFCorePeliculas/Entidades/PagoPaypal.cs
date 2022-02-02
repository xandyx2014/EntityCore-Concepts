namespace EFCorePeliculas.Entidades
{
    // pagoPaypal hereda de pago
    public class PagoPaypal : Pago
    {
        public string CorreoElectronico { get; set; }
    }
}
