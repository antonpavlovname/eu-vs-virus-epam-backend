using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImmunisationPass.Data;
using ImmunisationPass.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImmunisationPass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionTrackingsController : ControllerBase
    {
        private readonly HealthDatabaseContext _context;

        public InteractionTrackingsController(HealthDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/InteractionTrackings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteractionTracking>>> GetInteractionTracking()
        {
            return await _context.InteractionTracking.ToListAsync();
        }

        // GET: api/InteractionTrackings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InteractionTracking>> GetInteractionTracking(Guid id)
        {
            var interactionTracking = await _context.InteractionTracking.FindAsync(id);

            if (interactionTracking == null)
            {
                return NotFound();
            }

            return interactionTracking;
        }

        // PUT: api/InteractionTrackings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteractionTracking(Guid id, InteractionTracking interactionTracking)
        {
            if (id != interactionTracking.Id)
            {
                return BadRequest();
            }

            _context.Entry(interactionTracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteractionTrackingExists(id))
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

        // POST: api/InteractionTrackings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InteractionTracking>> PostInteractionTracking(InteractionTracking interactionTracking)
        {
            _context.InteractionTracking.Add(interactionTracking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInteractionTracking", new { id = interactionTracking.Id }, interactionTracking);
        }

        // DELETE: api/InteractionTrackings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InteractionTracking>> DeleteInteractionTracking(Guid id)
        {
            var interactionTracking = await _context.InteractionTracking.FindAsync(id);
            if (interactionTracking == null)
            {
                return NotFound();
            }

            _context.InteractionTracking.Remove(interactionTracking);
            await _context.SaveChangesAsync();

            return interactionTracking;
        }

        private bool InteractionTrackingExists(Guid id)
        {
            return _context.InteractionTracking.Any(e => e.Id == id);
        }
    }
}
