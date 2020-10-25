using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronic_Collection.Data;
using Electronic_Collection.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Electronic_Collection.Controllers
{
    [Authorize(Roles = "Collector")]
    public class CollectorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public readonly UserManager<Collector> _userManager{ get; set; }

        public CollectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collectors
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var collector = _context.Collector.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();

            if (collector == null)
            {

                return RedirectToAction("Create");

            }
            return View("Details", collector);
        }

        // GET: Collectors/Details/5
        public async Task<IActionResult> Details(Collector collector)
        {
            if (collector == null)
            {
                return NotFound();
            }
            return View(collector);
        }

        // GET: Collectors/Create
        public IActionResult Create()
        {
            Collector collector = new Collector();

            return View(collector);
        }

        // POST: Collectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Collector collector)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                collector.IdentityUserId = userId;
                _context.Add(collector);
                _context.SaveChanges();
                return RedirectToAction("Create");

            }


            return RedirectToAction("Details");
        }

        // GET: Collectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var collector = _context.Collector.SingleOrDefault(c => c.CollectorId == id);
            if (id == null)
            {
                return NotFound();
            }


            if (collector == null)
            {
                return NotFound();
            }

            return View(collector);
        }

        // POST: Collectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Collector collector)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var collectorFromDb = _context.Collector.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                collectorFromDb.Name = collector.Name;
                collectorFromDb.Console = collector.Console;
                collectorFromDb.Game = collector.Game;
                collectorFromDb.Genre = collector.Genre;
                collectorFromDb.GamingMoment = collector.GamingMoment;

                _context.Update(collectorFromDb);
                _context.SaveChanges();
                return RedirectToAction("Details", collectorFromDb);

            }
            catch 
            {

                return RedirectToAction("Index");
            }
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
