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
    public class CollectionObjsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectionObjsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CollectionObjs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CollectorCollection.Include(c => c.Collector).Include(c => c.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CollectionObjs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionObj = await _context.CollectorCollection
                .Include(c => c.Collector)
                .Include(c => c.Item)
                .FirstOrDefaultAsync(m => m.CollectorId == id);
            if (collectionObj == null)
            {
                return NotFound();
            }

            return View(collectionObj);
        }

        // GET: CollectionObjs/Create
        public IActionResult Create()
        {
            ViewData["CollectorId"] = new SelectList(_context.Collector, "CollectorId", "CollectorId");
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId");
            return View();
        }

        // POST: CollectionObjs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectorId,ItemId")] CollectionObj collectionObj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectionObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollectorId"] = new SelectList(_context.Collector, "CollectorId", "CollectorId", collectionObj.CollectorId);
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", collectionObj.ItemId);
            return View(collectionObj);
        }

        // GET: CollectionObjs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionObj = await _context.CollectorCollection.FindAsync(id);
            if (collectionObj == null)
            {
                return NotFound();
            }
            ViewData["CollectorId"] = new SelectList(_context.Collector, "CollectorId", "CollectorId", collectionObj.CollectorId);
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", collectionObj.ItemId);
            return View(collectionObj);
        }

        // POST: CollectionObjs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectorId,ItemId")] CollectionObj collectionObj)
        {
            if (id != collectionObj.CollectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectionObj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionObjExists(collectionObj.CollectorId))
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
            ViewData["CollectorId"] = new SelectList(_context.Collector, "CollectorId", "CollectorId", collectionObj.CollectorId);
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", collectionObj.ItemId);
            return View(collectionObj);
        }

        // GET: CollectionObjs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionObj = await _context.CollectorCollection
                .Include(c => c.Collector)
                .Include(c => c.Item)
                .FirstOrDefaultAsync(m => m.CollectorId == id);
            if (collectionObj == null)
            {
                return NotFound();
            }

            return View(collectionObj);
        }

        // POST: CollectionObjs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collectionObj = await _context.CollectorCollection.FindAsync(id);
            _context.CollectorCollection.Remove(collectionObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionObjExists(int id)
        {
            return _context.CollectorCollection.Any(e => e.CollectorId == id);
        }
    }
}
