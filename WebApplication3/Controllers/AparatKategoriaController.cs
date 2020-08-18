using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class AparatKategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AparatKategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AparatKategoria
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Kategorie.Include(a => a.UpperCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AparatKategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(3);
            Response.Cookies.Append("currentPageCookie", id.ToString(), option);
            var aparatKategoria = await _context.Kategorie
                .Include(a => a.UpperCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aparatKategoria == null)
            {
                return NotFound();
            }

            return View(aparatKategoria);
        }

        // GET: AparatKategoria/Create
        public IActionResult Create()
        {
            ViewData["UpperCategoryId"] = new SelectList(_context.Kategorie, "Id", "Name");
            return View();
        }

        // POST: AparatKategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UpperCategoryId")] AparatKategoria aparatKategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aparatKategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UpperCategoryId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatKategoria.UpperCategoryId);
            return View(aparatKategoria);
        }

        // GET: AparatKategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparatKategoria = await _context.Kategorie.FindAsync(id);
            if (aparatKategoria == null)
            {
                return NotFound();
            }
            ViewData["UpperCategoryId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatKategoria.UpperCategoryId);
            return View(aparatKategoria);
        }

        // POST: AparatKategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UpperCategoryId")] AparatKategoria aparatKategoria)
        {
            if (id != aparatKategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aparatKategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AparatKategoriaExists(aparatKategoria.Id))
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
            ViewData["UpperCategoryId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatKategoria.UpperCategoryId);
            return View(aparatKategoria);
        }

        // GET: AparatKategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparatKategoria = await _context.Kategorie
                .Include(a => a.UpperCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aparatKategoria == null)
            {
                return NotFound();
            }

            return View(aparatKategoria);
        }

        // POST: AparatKategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aparatKategoria = await _context.Kategorie.FindAsync(id);
            _context.Kategorie.Remove(aparatKategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AparatKategoriaExists(int id)
        {
            return _context.Kategorie.Any(e => e.Id == id);
        }
        public IActionResult Menu(int? id)
        {
            AparatKategoria kategoria = null;
            int? katUpper = 0;
            int? x;


            List<AparatViewModel> ListaDisplAP = new List<AparatViewModel>();
            if (id == null)
            {
                id = 1;
            }
           

            if (Request.Cookies["currentPageCookie"] != null)
            {
                id = int.Parse(Request.Cookies["currentPageCookie"]);
            }

            kategoria = _context.Kategorie.Find(id);
            katUpper = _context.Kategorie.Find(id).UpperCategoryId;

            if (kategoria == null)
            {
                return NotFound();
            }
            if (Request.Cookies["currentPageCookie"] != null)
            {
                x = (int.Parse(Request.Cookies["currentPageCookie"]));
            }
            else
            {
                x = (int)id;
            }
            ViewBag.SubCategories = (from category in _context.Kategorie where category.UpperCategoryId == x select category).ToList();
            ViewBag.UpperCategory = _context.Kategorie.FirstOrDefault(x => (x.Id == kategoria.UpperCategoryId));
            List<AparatViewModel> ListaAP = (from aparat in _context.Aparaty select aparat).ToList();
            foreach (AparatViewModel ap in ListaAP)
            {
                int LocalCat = ap.AparatKategoriaId;
                if (LocalCat == x)
                {
                    ListaDisplAP.Add(ap);
                }
                else
                {
                    while (_context.Kategorie.Find(LocalCat).UpperCategoryId.HasValue)
                    {
                        LocalCat = (int)_context.Kategorie.Find(LocalCat).UpperCategoryId;
                        if (LocalCat == x)
                        {
                            ListaDisplAP.Add(ap);
                        }
                    }
                }

            }

            ViewBag.Aparaty = ListaDisplAP;
            // ViewBag.Aparaty = (from aparat in _context.Aparaty where aparat.AparatKategoriaId == x select aparat).ToList();


            return View(kategoria);
        }


    }
}

