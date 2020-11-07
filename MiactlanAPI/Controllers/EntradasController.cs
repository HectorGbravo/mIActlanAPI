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
    public class EntradasController : ControllerBase
    {
        private readonly MiactlanDbContext _context;

        public EntradasController(MiactlanDbContext context)
        {
            _context = context;
        }

        // GET: api/Entradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntrada()
        {
            return await _context.Entradas.ToListAsync();
        }

        // GET: api/Entradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrada>> GetEntrada(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);

            if (entrada == null)
            {
                return NotFound();
            }

            return entrada;
        }

        // PUT: api/Entradas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrada(int id, Entrada entrada)
        {
            if (id != entrada.IdEntrada)
            {
                return BadRequest();
            }

            _context.Entry(entrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
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

        // POST: api/Entradas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entrada>> PostEntrada(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrada", new { id = entrada.IdEntrada }, entrada);
        }

        // DELETE: api/Entradas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entrada>> DeleteEntrada(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }

            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();

            return entrada;
        }

        private bool EntradaExists(int id)
        {
            return _context.Entradas.Any(e => e.IdEntrada == id);
        }
    }
}
