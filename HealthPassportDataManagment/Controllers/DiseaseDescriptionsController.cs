using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthPassportApi.Data;
using HealthPassportApi.DataModels;

namespace HealthPassportDataManagment.Controllers
{
    public class DiseaseDescriptionsController : Controller
    {
        private readonly HealthDatabaseContext _context;

        public DiseaseDescriptionsController(HealthDatabaseContext context)
        {
            _context = context;
        }

        // GET: DiseaseDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiseaseDescriptions.ToListAsync());
        }

        // GET: DiseaseDescriptions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseDescription = await _context.DiseaseDescriptions
                .FirstOrDefaultAsync(m => m.Name == id);
            if (diseaseDescription == null)
            {
                return NotFound();
            }

            return View(diseaseDescription);
        }

        // GET: DiseaseDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiseaseDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Information,Symptoms,Treatment,Vaccination")] DiseaseDescription diseaseDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseaseDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diseaseDescription);
        }

        // GET: DiseaseDescriptions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseDescription = await _context.DiseaseDescriptions.FindAsync(id);
            if (diseaseDescription == null)
            {
                return NotFound();
            }
            return View(diseaseDescription);
        }

        // POST: DiseaseDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Information,Symptoms,Treatment,Vaccination")] DiseaseDescription diseaseDescription)
        {
            if (id != diseaseDescription.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseaseDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseDescriptionExists(diseaseDescription.Name))
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
            return View(diseaseDescription);
        }

        // GET: DiseaseDescriptions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseDescription = await _context.DiseaseDescriptions
                .FirstOrDefaultAsync(m => m.Name == id);
            if (diseaseDescription == null)
            {
                return NotFound();
            }

            return View(diseaseDescription);
        }

        // POST: DiseaseDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diseaseDescription = await _context.DiseaseDescriptions.FindAsync(id);
            _context.DiseaseDescriptions.Remove(diseaseDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseDescriptionExists(string id)
        {
            return _context.DiseaseDescriptions.Any(e => e.Name == id);
        }
    }
}
