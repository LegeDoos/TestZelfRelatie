using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestZelfRelatie.Data;
using TestZelfRelatie.Models;

namespace TestZelfRelatie.Controllers
{
    public class LokaalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LokaalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lokaals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lokaal.Include(l => l.Gebouw);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lokaals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lokaal == null)
            {
                return NotFound();
            }

            var lokaal = await _context.Lokaal
                .Include(l => l.Gebouw)
                .FirstOrDefaultAsync(m => m.LokaalId == id);
            if (lokaal == null)
            {
                return NotFound();
            }

            return View(lokaal);
        }

        // GET: Lokaals/Create
        public IActionResult Create()
        {
            ViewData["GebouwId"] = new SelectList(_context.Gebouwen, "GebouwId", "Description");
            return View();
        }

        // POST: Lokaals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LokaalId,Description,GebouwId")] Lokaal lokaal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokaal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebouwId"] = new SelectList(_context.Gebouwen, "GebouwId", "GebouwId", lokaal.GebouwId);
            return View(lokaal);
        }

        // GET: Lokaals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lokaal == null)
            {
                return NotFound();
            }

            var lokaal = await _context.Lokaal.FindAsync(id);
            if (lokaal == null)
            {
                return NotFound();
            }
            ViewData["GebouwId"] = new SelectList(_context.Gebouwen, "GebouwId", "GebouwId", lokaal.GebouwId);
            return View(lokaal);
        }

        // POST: Lokaals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LokaalId,Description,GebouwId")] Lokaal lokaal)
        {
            if (id != lokaal.LokaalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokaal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokaalExists(lokaal.LokaalId))
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
            ViewData["GebouwId"] = new SelectList(_context.Gebouwen, "GebouwId", "GebouwId", lokaal.GebouwId);
            return View(lokaal);
        }

        // GET: Lokaals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lokaal == null)
            {
                return NotFound();
            }

            var lokaal = await _context.Lokaal
                .Include(l => l.Gebouw)
                .FirstOrDefaultAsync(m => m.LokaalId == id);
            if (lokaal == null)
            {
                return NotFound();
            }

            return View(lokaal);
        }

        // POST: Lokaals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lokaal == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lokaal'  is null.");
            }
            var lokaal = await _context.Lokaal.FindAsync(id);
            if (lokaal != null)
            {
                _context.Lokaal.Remove(lokaal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokaalExists(int id)
        {
          return _context.Lokaal.Any(e => e.LokaalId == id);
        }
    }
}
