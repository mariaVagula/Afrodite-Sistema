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
    public class ProfissionalController : Controller
    {
        private readonly Contexto _context;

        public ProfissionalController(Contexto context)
        {
            _context = context;
        }

        // GET: Profissional
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Profissional.Include(p => p.TipoProfissional);
            return View(await contexto.ToListAsync());
        }

        // GET: Profissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profissional == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional
                .Include(p => p.TipoProfissional)
                .FirstOrDefaultAsync(m => m.ProfissionalId == id);
            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // GET: Profissional/Create
        public IActionResult Create()
        {
            ViewData["TipoProfissionalId"] = new SelectList(_context.TipoProfissional, "TipoProfissionalId", "TipoProfissionalId");
            return View();
        }

        // POST: Profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfissionalId,NomeProfissional,TipoProfissionalId")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProfissionalId"] = new SelectList(_context.TipoProfissional, "TipoProfissionalId", "TipoProfissionalId", profissional.TipoProfissionalId);
            return View(profissional);
        }

        // GET: Profissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profissional == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional.FindAsync(id);
            if (profissional == null)
            {
                return NotFound();
            }
            ViewData["TipoProfissionalId"] = new SelectList(_context.TipoProfissional, "TipoProfissionalId", "TipoProfissionalId", profissional.TipoProfissionalId);
            return View(profissional);
        }

        // POST: Profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfissionalId,NomeProfissional,TipoProfissionalId")] Profissional profissional)
        {
            if (id != profissional.ProfissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalExists(profissional.ProfissionalId))
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
            ViewData["TipoProfissionalId"] = new SelectList(_context.TipoProfissional, "TipoProfissionalId", "TipoProfissionalId", profissional.TipoProfissionalId);
            return View(profissional);
        }

        // GET: Profissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profissional == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional
                .Include(p => p.TipoProfissional)
                .FirstOrDefaultAsync(m => m.ProfissionalId == id);
            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // POST: Profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profissional == null)
            {
                return Problem("Entity set 'Contexto.Profissional'  is null.");
            }
            var profissional = await _context.Profissional.FindAsync(id);
            if (profissional != null)
            {
                _context.Profissional.Remove(profissional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalExists(int id)
        {
          return (_context.Profissional?.Any(e => e.ProfissionalId == id)).GetValueOrDefault();
        }
    }
}
