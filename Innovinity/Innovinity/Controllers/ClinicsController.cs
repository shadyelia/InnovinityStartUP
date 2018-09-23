using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Innovinity.Data;
using Innovinity.Models;

namespace Innovinity
{
    public class ClinicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClinicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clinics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinics.ToListAsync());
        }

        // GET: Clinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinics = await _context.Clinics
                .SingleOrDefaultAsync(m => m.ClinicsID == id);
            if (clinics == null)
            {
                return NotFound();
            }

            return View(clinics);
        }

        // GET: Clinics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClinicsID,Name,Arabic_Name")] Clinics clinics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinics);
        }

        // GET: Clinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinics = await _context.Clinics.SingleOrDefaultAsync(m => m.ClinicsID == id);
            if (clinics == null)
            {
                return NotFound();
            }
            return View(clinics);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClinicsID,Name,Arabic_Name")] Clinics clinics)
        {
            if (id != clinics.ClinicsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicsExists(clinics.ClinicsID))
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
            return View(clinics);
        }

        // GET: Clinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinics = await _context.Clinics
                .SingleOrDefaultAsync(m => m.ClinicsID == id);
            if (clinics == null)
            {
                return NotFound();
            }

            return View(clinics);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinics = await _context.Clinics.SingleOrDefaultAsync(m => m.ClinicsID == id);
            _context.Clinics.Remove(clinics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicsExists(int id)
        {
            return _context.Clinics.Any(e => e.ClinicsID == id);
        }
    }
}
