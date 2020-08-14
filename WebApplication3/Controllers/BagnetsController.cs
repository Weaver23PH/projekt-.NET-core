using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BagnetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BagnetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bagnets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bagnety.ToListAsync());
        }

        // GET: Bagnets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagnet = await _context.Bagnety
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bagnet == null)
            {
                return NotFound();
            }

            return View(bagnet);
        }

        // GET: Bagnets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bagnets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Typ")] Bagnet bagnet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bagnet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bagnet);
        }

        // GET: Bagnets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagnet = await _context.Bagnety.FindAsync(id);
            if (bagnet == null)
            {
                return NotFound();
            }
            return View(bagnet);
        }

        // POST: Bagnets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Typ")] Bagnet bagnet)
        {
            if (id != bagnet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bagnet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagnetExists(bagnet.Id))
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
            return View(bagnet);
        }

        // GET: Bagnets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagnet = await _context.Bagnety
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bagnet == null)
            {
                return NotFound();
            }

            return View(bagnet);
        }

        // POST: Bagnets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bagnet = await _context.Bagnety.FindAsync(id);
            _context.Bagnety.Remove(bagnet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BagnetExists(int id)
        {
            return _context.Bagnety.Any(e => e.Id == id);
        }
    }
}
