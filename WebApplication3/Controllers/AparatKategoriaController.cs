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
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Category-Manager")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Kategorie.Include(a => a.UpperCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AparatKategoria/Details/5
        [Authorize(Roles = "Category-Manager")]
        public async Task<IActionResult> Details(int? id)
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

        // GET: AparatKategoria/Create
        [Authorize(Roles = "Category-Manager")]
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
        [Authorize(Roles = "Category-Manager")]
        public async Task<IActionResult> Create([Bind("Id,Name,UpperCategoryId")] AparatKategoria aparatKategoria)
        {
            if (ModelState.IsValid)
            {
                if (!KategoriaNameExists(aparatKategoria.Name))
                {
                    _context.Add(aparatKategoria);
                    await _context.SaveChangesAsync();
                    ViewBag.DuplicateMessage = "";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.DuplicateMessage = "This already exists";
                }
            }
            ViewData["UpperCategoryId"] = new SelectList(_context.Kategorie, "Id", "Name", aparatKategoria.UpperCategoryId);
            return View(aparatKategoria);
        }

        // GET: AparatKategoria/Edit/5
        [Authorize(Roles = "Category-Manager")]
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
        [Authorize(Roles = "Category-Manager")]
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
        [Authorize(Roles = "Category-Manager")]
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
        [Authorize(Roles = "Category-Manager")]
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
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(3);
            AparatKategoria kategoria = null;
            int? katUpper = 0;
            int? x;
            List<AparatViewModel> ListaDisplAP = new List<AparatViewModel>();


            if (id == null)
            {
                id = 1;
            }

            Response.Cookies.Append("currentPageCookie", id.ToString(), option);

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
            if ((Request.Cookies["currentPageCookie"] != null)  && ((int.Parse(Request.Cookies["currentPageCookie"])) != (int)id))
            {
                x = (int)id;
                Response.Cookies.Append("currentPageCookie", id.ToString(), option);
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



            return View(kategoria);
        }
        private bool KategoriaNameExists(string checkedName)
        {
            List<string> existingCategoryNames = new List<string>();
            List<AparatKategoria> existingCategory = (from category in _context.Kategorie select category).ToList();
            foreach (AparatKategoria category in existingCategory)
            {
                existingCategoryNames.Add(category.Name);
            }
            return existingCategoryNames.Contains(checkedName);
        }

    }
}

