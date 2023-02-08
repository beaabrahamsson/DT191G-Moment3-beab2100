using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDDirectory.Data;
using CDDirectory.Models;

namespace CDDirectory.Controllers
{
    public class CDController : Controller
    {
        private readonly CDContext _context;

        public CDController(CDContext context)
        {
            _context = context;
        }

// GET: CD
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.CD == null)
        {
            return Problem("Entity set 'CDContext.CD'  is null.");
        }

        var cds = from m in _context.CD
                    select m;
        cds = _context.CD.Include(c => c.Artist);

        if (!String.IsNullOrEmpty(searchString))
        {
            cds = cds
            .Include(c => c.Artist)
            .Where(s => s.Title!.Contains(searchString));
        }

        return View(await cds.ToListAsync());

            //
            //return View(await cDContext.ToListAsync());
        }

        // GET: CD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CD == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.CDId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // GET: CD/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: CD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDId,Title,Genre,ArtistId,UserId")] CD cD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cD.ArtistId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", cD.UserId);
            return View(cD);
        }

        // GET: CD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CD == null)
            {
                return NotFound();
            }

            var cD = await _context.CD.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cD.ArtistId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", cD.UserId);
            return View(cD);
        }

        // POST: CD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDId,Title,Genre,ArtistId,UserId")] CD cD)
        {
            if (id != cD.CDId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDExists(cD.CDId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cD.ArtistId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", cD.UserId);
            return View(cD);
        }

        // GET: CD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CD == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .Include(c => c.Artist)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CDId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // POST: CD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CD == null)
            {
                return Problem("Entity set 'CDContext.CD'  is null.");
            }
            var cD = await _context.CD.FindAsync(id);
            if (cD != null)
            {
                _context.CD.Remove(cD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDExists(int id)
        {
          return (_context.CD?.Any(e => e.CDId == id)).GetValueOrDefault();
        }
    }
}
