using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventosAPI.Data;
using GestionEventosUTN.Models;

namespace GestionEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscripcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InscripcionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> Get()
        {
            return await _context.Inscripciones
                .Include(i => i.Participante)
                .Include(i => i.Evento)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> Get(int id)
        {
            var inscripcion = await _context.Inscripciones
                .Include(i => i.Participante)
                .Include(i => i.Evento)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inscripcion == null) return NotFound();
            return inscripcion;
        }

        [HttpPost]
        public async Task<ActionResult<Inscripcion>> Post(Inscripcion inscripcion)
        {
            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = inscripcion.Id }, inscripcion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Inscripcion inscripcion)
        {
            if (id != inscripcion.Id) return BadRequest();

            _context.Entry(inscripcion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null) return NotFound();

            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
