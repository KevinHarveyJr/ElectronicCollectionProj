using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronic_Collection.Data;
using Electronic_Collection.Models;

namespace Electronic_Collection.Controllers
{
    public class CollectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collectors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Collector.Include(c => c.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Collectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collector = await _context.Collector
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.CollectorId == id);
            if (collector == null)
            {
                return NotFound();
            }

            return View(collector);
        }

        // GET: Collectors/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Collectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectorId,Name,Console,Game,Genre,GamingMoment,PicturePath,IdentityUserId")] Collector collector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", collector.IdentityUserId);
            return View(collector);
        }

        // GET: Collectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collector = await _context.Collector.FindAsync(id);
            if (collector == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", collector.IdentityUserId);
            return View(collector);
        }

        // POST: Collectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectorId,Name,Console,Game,Genre,GamingMoment,PicturePath,IdentityUserId")] Collector collector)
        {
            if (id != collector.CollectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectorExists(collector.CollectorId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", collector.IdentityUserId);
            return View(collector);
        }

        // GET: Collectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collector = await _context.Collector
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.CollectorId == id);
            if (collector == null)
            {
                return NotFound();
            }

            return View(collector);
        }

        // POST: Collectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collector = await _context.Collector.FindAsync(id);
            _context.Collector.Remove(collector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectorExists(int id)
        {
            return _context.Collector.Any(e => e.CollectorId == id);
        }
    }
}
