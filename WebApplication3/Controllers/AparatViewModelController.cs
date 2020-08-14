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
    public class AparatViewModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AparatViewModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AparatViewModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Aparaty.Include(a => a.Bagnet).Include(a => a.Kategoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AparatViewModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparatViewModel = await _context.Aparaty
                .Include(a => a.Bagnet)
                .Include(a => a.Kategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aparatViewModel == null)
            {
                return NotFound();
            }

            return View(aparatViewModel);
        }

        // GET: AparatViewModel/Create
        public IActionResult Create()
        {
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ");
            ViewData["AparatKategoriaId"] = new SelectList(_context.Kategorie, "Id", "Name");
            return View();
        }

        // POST: AparatViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producent,KrajPochodzenia,Model,RokProdukcji,Waga,Wycofany,BagnetId,AparatKategoriaId")] AparatViewModel aparatViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aparatViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ", aparatViewModel.BagnetId);
            ViewData["AparatKategoriaId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatViewModel.AparatKategoriaId);
            return View(aparatViewModel);
        }

        // GET: AparatViewModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparatViewModel = await _context.Aparaty.FindAsync(id);
            if (aparatViewModel == null)
            {
                return NotFound();
            }
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ", aparatViewModel.BagnetId);
            ViewData["AparatKategoriaId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatViewModel.AparatKategoriaId);
            return View(aparatViewModel);
        }

        // POST: AparatViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producent,KrajPochodzenia,Model,RokProdukcji,Waga,Wycofany,BagnetId,AparatKategoriaId")] AparatViewModel aparatViewModel)
        {
            if (id != aparatViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aparatViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AparatViewModelExists(aparatViewModel.Id))
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
            ViewData["BagnetId"] = new SelectList(_context.Bagnety, "Id", "Typ", aparatViewModel.BagnetId);
            ViewData["AparatKategoriaId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatViewModel.AparatKategoriaId);
            return View(aparatViewModel);
        }

        // GET: AparatViewModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparatViewModel = await _context.Aparaty
                .Include(a => a.Bagnet)
                .Include(a => a.Kategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aparatViewModel == null)
            {
                return NotFound();
            }

            return View(aparatViewModel);
        }

        // POST: AparatViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aparatViewModel = await _context.Aparaty.FindAsync(id);
            _context.Aparaty.Remove(aparatViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AparatViewModelExists(int id)
        {
            return _context.Aparaty.Any(e => e.Id == id);
        }
    }
}
