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
    public class CwiczeniaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CwiczeniaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cwiczenia.Include(c => c.SesjaTreningowa).Include(c => c.TypCwiczenia);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cwiczenia == null)
            {
                return NotFound();
            }

            var cwiczenie = await _context.Cwiczenia
                .Include(c => c.SesjaTreningowa)
                .Include(c => c.TypCwiczenia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cwiczenie == null)
            {
                return NotFound();
            }

            return View(cwiczenie);
        }
      
        public IActionResult Create()
        {
            ViewData["SesjaTreningowaId"] = new SelectList(_context.SesjeTreningowe, "Id", "Nazwa");
            ViewData["TypCwiczeniaId"] = new SelectList(_context.TypyCwiczen, "Id", "Nazwa");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LiczbaSerii,Obciazenie,TypCwiczeniaId,SesjaTreningowaId")] Cwiczenie cwiczenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cwiczenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SesjaTreningowaId"] = new SelectList(_context.SesjeTreningowe, "Id", "Nazwa", cwiczenie.SesjaTreningowaId);
            ViewData["TypCwiczeniaId"] = new SelectList(_context.TypyCwiczen, "Id", "Nazwa", cwiczenie.TypCwiczeniaId);
            return View(cwiczenie);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cwiczenia == null)
            {
                return NotFound();
            }

            var cwiczenie = await _context.Cwiczenia.FindAsync(id);
            if (cwiczenie == null)
            {
                return NotFound();
            }
            ViewData["SesjaTreningowaId"] = new SelectList(_context.SesjeTreningowe, "Id", "Nazwa", cwiczenie.SesjaTreningowaId);
            ViewData["TypCwiczeniaId"] = new SelectList(_context.TypyCwiczen, "Id", "Nazwa", cwiczenie.TypCwiczeniaId);
            return View(cwiczenie);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LiczbaSerii,Obciazenie,TypCwiczeniaId,SesjaTreningowaId")] Cwiczenie cwiczenie)
        {
            if (id != cwiczenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cwiczenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CwiczenieExists(cwiczenie.Id))
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
            ViewData["SesjaTreningowaId"] = new SelectList(_context.SesjeTreningowe, "Id", "Nazwa", cwiczenie.SesjaTreningowaId);
            ViewData["TypCwiczeniaId"] = new SelectList(_context.TypyCwiczen, "Id", "Nazwa", cwiczenie.TypCwiczeniaId);
            return View(cwiczenie);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cwiczenia == null)
            {
                return NotFound();
            }

            var cwiczenie = await _context.Cwiczenia
                .Include(c => c.SesjaTreningowa)
                .Include(c => c.TypCwiczenia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cwiczenie == null)
            {
                return NotFound();
            }

            return View(cwiczenie);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cwiczenia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cwiczenia'  is null.");
            }
            var cwiczenie = await _context.Cwiczenia.FindAsync(id);
            if (cwiczenie != null)
            {
                _context.Cwiczenia.Remove(cwiczenie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CwiczenieExists(int id)
        {
          return (_context.Cwiczenia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
