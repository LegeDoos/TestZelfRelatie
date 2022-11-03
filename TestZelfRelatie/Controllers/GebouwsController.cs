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
    public class GebouwsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GebouwsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gebouws
        public async Task<IActionResult> Index()
        {
              return View(await _context.Gebouwen.ToListAsync());
        }

        // GET: Gebouws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gebouwen == null)
            {
                return NotFound();
            }

            var gebouw = await _context.Gebouwen
                .FirstOrDefaultAsync(m => m.GebouwId == id);
            if (gebouw == null)
            {
                return NotFound();
            }

            return View(gebouw);
        }

        // GET: Gebouws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebouws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GebouwId,Description")] Gebouw gebouw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gebouw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gebouw);
        }

        // GET: Gebouws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gebouwen == null)
            {
                return NotFound();
            }

            var gebouw = await _context.Gebouwen.FindAsync(id);
            if (gebouw == null)
            {
                return NotFound();
            }
            return View(gebouw);
        }

        // POST: Gebouws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GebouwId,Description")] Gebouw gebouw)
        {
            if (id != gebouw.GebouwId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebouw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebouwExists(gebouw.GebouwId))
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
            return View(gebouw);
        }

        // GET: Gebouws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gebouwen == null)
            {
                return NotFound();
            }

            var gebouw = await _context.Gebouwen
                .FirstOrDefaultAsync(m => m.GebouwId == id);
            if (gebouw == null)
            {
                return NotFound();
            }

            return View(gebouw);
        }

        // POST: Gebouws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gebouwen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gebouwen'  is null.");
            }
            var gebouw = await _context.Gebouwen.FindAsync(id);
            if (gebouw != null)
            {
                _context.Gebouwen.Remove(gebouw);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebouwExists(int id)
        {
          return _context.Gebouwen.Any(e => e.GebouwId == id);
        }
    }
}
