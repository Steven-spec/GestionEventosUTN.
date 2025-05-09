using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventosAPI.Data;
using GestionEventosUTN.Models;

namespace GestionEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PagosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> Get()
        {
            return await _context.Pagos.Include(p => p.Inscripcion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> Get(int id)
        {
            var pago = await _context.Pagos.Include(p => p.Inscripcion).FirstOrDefaultAsync(p => p.Id == id);
            if (pago == null) return NotFound();
            return pago;
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> Post(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = pago.Id }, pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pago pago)
        {
            if (id != pago.Id) return BadRequest();

            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null) return NotFound();

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
