using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Afrodite_Sistema.Models;

namespace Afrodite_Sistema.Controllers
{
    public class TipoProfissionalController : Controller
    {
        private readonly Contexto _context;

        public TipoProfissionalController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoProfissional
        public async Task<IActionResult> Index()
        {
              return _context.TipoProfissional != null ? 
                          View(await _context.TipoProfissional.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoProfissional'  is null.");
        }

        // GET: TipoProfissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoProfissional == null)
            {
                return NotFound();
            }

            var tipoProfissional = await _context.TipoProfissional
                .FirstOrDefaultAsync(m => m.TipoProfissionalId == id);
            if (tipoProfissional == null)
            {
                return NotFound();
            }

            return View(tipoProfissional);
        }

        // GET: TipoProfissional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProfissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoProfissionalId,NomeTipoProfissional")] TipoProfissional tipoProfissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProfissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProfissional);
        }

        // GET: TipoProfissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoProfissional == null)
            {
                return NotFound();
            }

            var tipoProfissional = await _context.TipoProfissional.FindAsync(id);
            if (tipoProfissional == null)
            {
                return NotFound();
            }
            return View(tipoProfissional);
        }

        // POST: TipoProfissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoProfissionalId,NomeTipoProfissional")] TipoProfissional tipoProfissional)
        {
            if (id != tipoProfissional.TipoProfissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProfissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProfissionalExists(tipoProfissional.TipoProfissionalId))
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
            return View(tipoProfissional);
        }

        // GET: TipoProfissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoProfissional == null)
            {
                return NotFound();
            }

            var tipoProfissional = await _context.TipoProfissional
                .FirstOrDefaultAsync(m => m.TipoProfissionalId == id);
            if (tipoProfissional == null)
            {
                return NotFound();
            }

            return View(tipoProfissional);
        }

        // POST: TipoProfissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoProfissional == null)
            {
                return Problem("Entity set 'Contexto.TipoProfissional'  is null.");
            }
            var tipoProfissional = await _context.TipoProfissional.FindAsync(id);
            if (tipoProfissional != null)
            {
                _context.TipoProfissional.Remove(tipoProfissional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProfissionalExists(int id)
        {
          return (_context.TipoProfissional?.Any(e => e.TipoProfissionalId == id)).GetValueOrDefault();
        }
    }
}
