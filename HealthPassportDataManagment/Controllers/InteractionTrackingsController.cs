using System;
using System.Linq;
using System.Threading.Tasks;
using ImmunisationPass.Data;
using ImmunisationPass.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImmunisationPassDataManagment.Controllers
{
    public class InteractionTrackingsController : Controller
    {
        private readonly HealthDatabaseContext _context;

        public InteractionTrackingsController(HealthDatabaseContext context)
        {
            _context = context;
        }

        // GET: InteractionTrackings
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var query = _context.InteractionTracking.AsQueryable(); //OrderBy(it => it.UserId);

            if (Guid.TryParse(searchString, out var searchGuid))
            {
                query = query.Where(it => it.UserId == searchGuid);
            }
            return View(await _context.InteractionTracking.ToListAsync());
        }

        // GET: InteractionTrackings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactionTracking = await _context.InteractionTracking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interactionTracking == null)
            {
                return NotFound();
            }

            return View(interactionTracking);
        }

        // GET: InteractionTrackings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InteractionTrackings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,InteractionEntity,CheckInTime,CheckoutTime,CheckInType,LatLong")] InteractionTracking interactionTracking)
        {
            if (ModelState.IsValid)
            {
                interactionTracking.Id = Guid.NewGuid();
                _context.Add(interactionTracking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interactionTracking);
        }

        // GET: InteractionTrackings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactionTracking = await _context.InteractionTracking.FindAsync(id);
            if (interactionTracking == null)
            {
                return NotFound();
            }
            return View(interactionTracking);
        }

        // POST: InteractionTrackings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserId,InteractionEntity,CheckInTime,CheckoutTime,CheckInType,LatLong")] InteractionTracking interactionTracking)
        {
            if (id != interactionTracking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interactionTracking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteractionTrackingExists(interactionTracking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(interactionTracking);
        }

        // GET: InteractionTrackings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactionTracking = await _context.InteractionTracking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interactionTracking == null)
            {
                return NotFound();
            }

            return View(interactionTracking);
        }

        // POST: InteractionTrackings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var interactionTracking = await _context.InteractionTracking.FindAsync(id);
            _context.InteractionTracking.Remove(interactionTracking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InteractionTrackingExists(Guid id)
        {
            return _context.InteractionTracking.Any(e => e.Id == id);
        }
    }
}
