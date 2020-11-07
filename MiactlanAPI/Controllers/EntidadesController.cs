using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiactlanAPI.Context;
using MiactlanAPI.Entities;

namespace MiactlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        private readonly MiactlanDbContext _context;

        public EntidadesController(MiactlanDbContext context)
        {
            _context = context;
        }

        // GET: api/Entidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entidad>>> GetEntidades()
        {
            return await _context.Entidades.ToListAsync();
        }

        // GET: api/Entidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entidad>> GetEntidad(int id)
        {
            var entidad = await _context.Entidades.FindAsync(id);

            if (entidad == null)
            {
                return NotFound();
            }

            return entidad;
        }

        // PUT: api/Entidades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidad(int id, Entidad entidad)
        {
            if (id != entidad.IdEntidad)
            {
                return BadRequest();
            }

            _context.Entry(entidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Entidades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entidad>> PostEntidad(Entidad entidad)
        {
            _context.Entidades.Add(entidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntidad", new { id = entidad.IdEntidad }, entidad);
        }

        // DELETE: api/Entidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entidad>> DeleteEntidad(int id)
        {
            var entidad = await _context.Entidades.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }

            _context.Entidades.Remove(entidad);
            await _context.SaveChangesAsync();

            return entidad;
        }

        private bool EntidadExists(int id)
        {
            return _context.Entidades.Any(e => e.IdEntidad == id);
        }
    }
}
