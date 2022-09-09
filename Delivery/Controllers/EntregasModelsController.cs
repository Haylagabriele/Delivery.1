using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery.Data;
using Delivery.Models;

namespace Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntregasModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntregasModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntregasModel>>> GetEntregas()
        {
          if (_context.Entregas == null)
          {
              return NotFound();
          }
            return await _context.Entregas.ToListAsync();
        }

        // GET: api/EntregasModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntregasModel>> GetEntregasModel(int id)
        {
          if (_context.Entregas == null)
          {
              return NotFound();
          }
            var entregasModel = await _context.Entregas.FindAsync(id);

            if (entregasModel == null)
            {
                return NotFound();
            }

            return entregasModel;
        }

        // PUT: api/EntregasModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntregasModel(int id, EntregasModel entregasModel)
        {
            if (id != entregasModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(entregasModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregasModelExists(id))
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

        // POST: api/EntregasModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntregasModel>> PostEntregasModel(EntregasModel entregasModel)
        {
          if (_context.Entregas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Entregas'  is null.");
          }
            _context.Entregas.Add(entregasModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntregasModel", new { id = entregasModel.Id }, entregasModel);
        }

        // DELETE: api/EntregasModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntregasModel(int id)
        {
            if (_context.Entregas == null)
            {
                return NotFound();
            }
            var entregasModel = await _context.Entregas.FindAsync(id);
            if (entregasModel == null)
            {
                return NotFound();
            }

            _context.Entregas.Remove(entregasModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntregasModelExists(int id)
        {
            return (_context.Entregas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
