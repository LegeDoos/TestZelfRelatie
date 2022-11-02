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
    public class RoutePointsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutePointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoutePoints
        public async Task<IActionResult> Index()
        {
            // test relations v2 data, data vanuit routepoint ophalen
            var datatest = await _context.RoutePointsV2.Include(rel => rel.IncomingRelations).Include(rel => rel.OutgoingRelations).ToListAsync();

            // get original data
            var data = await _context.RoutePoints.Include(r => r.OutgoingRelation)
                  .Include(r => r.IncomingRelation).ToListAsync();
            return View(data);
        }

        
        public async Task<IActionResult> SetRelations()
        {
            //get all routepoints
            var routepoints = await _context.RoutePoints.ToListAsync();

            //set relations
            var a = routepoints.FirstOrDefault(r => r.Id == 1);
            var b = routepoints.FirstOrDefault(r => r.Id == 2);
            var c = routepoints.FirstOrDefault(r => r.Id == 3);
            var d = routepoints.FirstOrDefault(r => r.Id == 4);

            a.OutgoingRelation = new();
            b.OutgoingRelation = new();
            c.OutgoingRelation = new();
            d.OutgoingRelation = new();

            a.OutgoingRelation.Add(b);
            a.OutgoingRelation.Add(c);
            b.OutgoingRelation.Add(d);
            b.OutgoingRelation.Add(a);
            c.OutgoingRelation.Add(d);
            c.OutgoingRelation.Add(a);
            d.OutgoingRelation.Add(c);
            d.OutgoingRelation.Add(b);

            //save
            _context.SaveChanges();

            return View(await _context.RoutePoints.ToListAsync());
        }

        // GET: RoutePoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoutePoints == null)
            {
                return NotFound();
            }

            var routePoint = await _context.RoutePoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routePoint == null)
            {
                return NotFound();
            }

            return View(routePoint);
        }

        // GET: RoutePoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoutePoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RoutePoint routePoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routePoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routePoint);
        }

        // GET: RoutePoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoutePoints == null)
            {
                return NotFound();
            }

            var routePoint = await _context.RoutePoints.FindAsync(id);
            if (routePoint == null)
            {
                return NotFound();
            }
            return View(routePoint);
        }

        // POST: RoutePoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RoutePoint routePoint)
        {
            if (id != routePoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routePoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutePointExists(routePoint.Id))
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
            return View(routePoint);
        }

        // GET: RoutePoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoutePoints == null)
            {
                return NotFound();
            }

            var routePoint = await _context.RoutePoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routePoint == null)
            {
                return NotFound();
            }

            return View(routePoint);
        }

        // POST: RoutePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoutePoints == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RoutePoints'  is null.");
            }
            var routePoint = await _context.RoutePoints.FindAsync(id);
            if (routePoint != null)
            {
                _context.RoutePoints.Remove(routePoint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutePointExists(int id)
        {
          return _context.RoutePoints.Any(e => e.Id == id);
        }
    }
}
