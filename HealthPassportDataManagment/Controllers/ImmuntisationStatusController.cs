using System;
using System.Linq;
using System.Threading.Tasks;
using ImmunisationPass.Data;
using ImmunisationPass.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImmunisationPassDataManagment.Controllers
{
    public class ImmuntisationStatusController : Controller
    {
        private readonly HealthDatabaseContext _context;

        public ImmuntisationStatusController(HealthDatabaseContext context)
        {
            _context = context;
        }

        // GET: ImmuntisationStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImmuntisationStatus.ToListAsync());
        }

        // GET: ImmuntisationStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var immuntisationStatus = await _context.ImmuntisationStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immuntisationStatus == null)
            {
                return NotFound();
            }

            return View(immuntisationStatus);
        }

        // GET: ImmuntisationStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImmuntisationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uuid,ImmuneType,Tested,CertBody,CertDate,CertExpiry")] ImmuntisationStatus immuntisationStatus)
        {
            if (ModelState.IsValid)
            {
                immuntisationStatus.Id = Guid.NewGuid();
                _context.Add(immuntisationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(immuntisationStatus);
        }

        // GET: ImmuntisationStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var immuntisationStatus = await _context.ImmuntisationStatus.FindAsync(id);
            if (immuntisationStatus == null)
            {
                return NotFound();
            }
            return View(immuntisationStatus);
        }

        // POST: ImmuntisationStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Uuid,ImmuneType,Tested,CertBody,CertDate,CertExpiry")] ImmuntisationStatus immuntisationStatus)
        {
            if (id != immuntisationStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(immuntisationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImmuntisationStatusExists(immuntisationStatus.Id))
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
            return View(immuntisationStatus);
        }

        // GET: ImmuntisationStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var immuntisationStatus = await _context.ImmuntisationStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immuntisationStatus == null)
            {
                return NotFound();
            }

            return View(immuntisationStatus);
        }

        // POST: ImmuntisationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var immuntisationStatus = await _context.ImmuntisationStatus.FindAsync(id);
            _context.ImmuntisationStatus.Remove(immuntisationStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImmuntisationStatusExists(Guid id)
        {
            return _context.ImmuntisationStatus.Any(e => e.Id == id);
        }
    }
}
