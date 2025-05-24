using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventosAPI.Data;
using Libreria.Modelo; 

namespace GestionEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participante>>> Get()
        {
            return await _context.Participantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> Get(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null) return NotFound();
            return participante;
        }

        [HttpPost]
        public async Task<ActionResult<Participante>> Post(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = participante.Id }, participante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Participante participante)
        {
            if (id != participante.Id) return BadRequest();

            _context.Entry(participante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null) return NotFound();

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
