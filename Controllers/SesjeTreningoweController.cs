using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Web.Data;
using BeFit.Web.Models;

namespace BeFit.Web.Controllers
{
    public class SesjeTreningoweController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesjeTreningoweController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SesjeTreningowe
        public async Task<IActionResult> Index()
        {
              return _context.SesjeTreningowe != null ? 
                          View(await _context.SesjeTreningowe.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SesjeTreningowe'  is null.");
        }

        // GET: SesjeTreningowe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SesjeTreningowe == null)
            {
                return NotFound();
            }

            var sesjaTreningowa = await _context.SesjeTreningowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesjaTreningowa == null)
            {
                return NotFound();
            }

            return View(sesjaTreningowa);
        }

        // GET: SesjeTreningowe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SesjeTreningowe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,CzasRozpoczecia,CzasZakonczenia,UzytkownikId")] SesjaTreningowa sesjaTreningowa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesjaTreningowa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sesjaTreningowa);
        }

        // GET: SesjeTreningowe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SesjeTreningowe == null)
            {
                return NotFound();
            }

            var sesjaTreningowa = await _context.SesjeTreningowe.FindAsync(id);
            if (sesjaTreningowa == null)
            {
                return NotFound();
            }
            return View(sesjaTreningowa);
        }

        // POST: SesjeTreningowe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,CzasRozpoczecia,CzasZakonczenia,UzytkownikId")] SesjaTreningowa sesjaTreningowa)
        {
            if (id != sesjaTreningowa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesjaTreningowa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesjaTreningowaExists(sesjaTreningowa.Id))
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
            return View(sesjaTreningowa);
        }

        // GET: SesjeTreningowe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SesjeTreningowe == null)
            {
                return NotFound();
            }

            var sesjaTreningowa = await _context.SesjeTreningowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesjaTreningowa == null)
            {
                return NotFound();
            }

            return View(sesjaTreningowa);
        }

        // POST: SesjeTreningowe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SesjeTreningowe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SesjeTreningowe'  is null.");
            }
            var sesjaTreningowa = await _context.SesjeTreningowe.FindAsync(id);
            if (sesjaTreningowa != null)
            {
                _context.SesjeTreningowe.Remove(sesjaTreningowa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesjaTreningowaExists(int id)
        {
          return (_context.SesjeTreningowe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
