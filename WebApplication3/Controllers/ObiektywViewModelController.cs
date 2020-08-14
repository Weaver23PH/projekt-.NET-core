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
    public class ObiektywViewModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObiektywViewModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ObiektywViewModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Obiektywy.Include(o => o.Bagnet);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ObiektywViewModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obiektywViewModel = await _context.Obiektywy
                .Include(o => o.Bagnet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obiektywViewModel == null)
            {
                return NotFound();
            }

            return View(obiektywViewModel);
        }

        // GET: ObiektywViewModel/Create
        public IActionResult Create()
        {
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ");
            return View();
        }

        // POST: ObiektywViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producent,KrajPochodzenia,Model,RokProdukcji,Waga,Staloogniskowy,OgniskowaMin,OgniskowaMax,PrzesłonaMax,PrzesłonaMin,BagnetId")] ObiektywViewModel obiektywViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obiektywViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ", obiektywViewModel.BagnetId);
            return View(obiektywViewModel);
        }

        // GET: ObiektywViewModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obiektywViewModel = await _context.Obiektywy.FindAsync(id);
            if (obiektywViewModel == null)
            {
                return NotFound();
            }
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ", obiektywViewModel.BagnetId);
            return View(obiektywViewModel);
        }

        // POST: ObiektywViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producent,KrajPochodzenia,Model,RokProdukcji,Waga,Staloogniskowy,OgniskowaMin,OgniskowaMax,PrzesłonaMax,PrzesłonaMin,BagnetId")] ObiektywViewModel obiektywViewModel)
        {
            if (id != obiektywViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obiektywViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObiektywViewModelExists(obiektywViewModel.Id))
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
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ", obiektywViewModel.BagnetId);
            return View(obiektywViewModel);
        }

        // GET: ObiektywViewModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obiektywViewModel = await _context.Obiektywy
                .Include(o => o.Bagnet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obiektywViewModel == null)
            {
                return NotFound();
            }

            return View(obiektywViewModel);
        }

        // POST: ObiektywViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obiektywViewModel = await _context.Obiektywy.FindAsync(id);
            _context.Obiektywy.Remove(obiektywViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObiektywViewModelExists(int id)
        {
            return _context.Obiektywy.Any(e => e.Id == id);
        }
    }
}
