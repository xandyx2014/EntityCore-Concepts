using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            // usando el automapper 
            return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var actorDB = await context.Actores.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if (actorDB is null)
            {
                return NotFound();
            }

            actorDB = mapper.Map(actorCreacionDTO, actorDB);
            var entry = context.Entry(actorDB);
            //await context.SaveChangesAsync();
            return Ok();
        }
        // MODELO DESCONECTADO
        // se usa un contexto distinto 
        // con 1 dbcontext se carga
        // con otro dbcontext se guarda
        // DIFERENCIA ENTRE CONECTADO Y DESCONECTADO
        // CONECTADO: save que valores cambiaron y solo acutaliza 
        // DESCONECTADO: no sabe que valores cambiaron y intenta actualizar todo
        [HttpPut("desconectado/{id:int}")]
        public async Task<ActionResult> PutDesconectado(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var existeActor = await context.Actores.AnyAsync(a => a.Id == id);

            if (!existeActor)
            {
                return NotFound();
            }

            var actor = mapper.Map<Actor>(actorCreacionDTO);
            actor.Id = id;

            //context.Update(actor);

            context.Entry(actor).Property(a => a.Nombre).IsModified = true;

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
