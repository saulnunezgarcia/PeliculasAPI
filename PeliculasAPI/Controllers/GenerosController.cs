using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get() 
        {
            var entidades = await context.Generos.ToListAsync(); //Hace una lista de la tabla Generos
            var dtos = mapper.Map<List<GeneroDTO>>(entidades);

            return dtos;
        }

        [HttpGet("{id:int}", Name = "obtenerGenero")]

        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var entidades = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            
            if (entidades == null)
            {
                return NotFound();
            }

            var dtos = mapper.Map<GeneroDTO>(entidades);

            return dtos;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var entidad = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var generoDTO = mapper.Map<GeneroDTO>(entidad);

            return new CreatedAtRouteResult("obtenerGenero", new { id = generoDTO.Id }, generoDTO);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var entidad = mapper.Map<Genero>(generoCreacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified; //indica que ha sido modificada la base de datos 
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Generos.AnyAsync(x => x.Id==id);
            if (existe == false)
            {
                return NoContent();
            }

            context.Remove(new Genero() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
