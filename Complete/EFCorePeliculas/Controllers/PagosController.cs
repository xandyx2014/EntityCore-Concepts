using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PagosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> Get()
        {
            return await context.Pagos.ToListAsync();
        }

        [HttpGet("tarjetas")]
        public async Task<ActionResult<IEnumerable<PagoTarjeta>>> GetTarjetas()
        {
            // sirve para llamar el pagos de la clase heredada 
            // se utiliza el oftype yta que estamos utilizando un discrimandor en apifluent
            return await context.Pagos.OfType<PagoTarjeta>().ToListAsync();
        }

        [HttpGet("paypal")]
        public async Task<ActionResult<IEnumerable<PagoPaypal>>> GetPaypal()
        {
            // sirve para llamar el pagos de la clase heredada 
            // se utiliza el oftype yta que estamos utilizando un discrimandor en apifluent
            return await context.Pagos.OfType<PagoPaypal>().ToListAsync();
        }
    }

}
