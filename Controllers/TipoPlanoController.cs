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
    public class TipoPlanoController : Controller
    {
        private readonly Contexto _context;

        public TipoPlanoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoPlano
        public async Task<IActionResult> Index()
        {
              return _context.TipoPlano != null ? 
                          View(await _context.TipoPlano.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoPlano'  is null.");
        }

        // GET: TipoPlano/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoPlano == null)
            {
                return NotFound();
            }

            var tipoPlano = await _context.TipoPlano
                .FirstOrDefaultAsync(m => m.TipoPlanoId == id);
            if (tipoPlano == null)
            {
                return NotFound();
            }

            return View(tipoPlano);
        }

        // GET: TipoPlano/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPlano/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoPlanoId,NomeTipoPlano")] TipoPlano tipoPlano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPlano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPlano);
        }

        // GET: TipoPlano/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoPlano == null)
            {
                return NotFound();
            }

            var tipoPlano = await _context.TipoPlano.FindAsync(id);
            if (tipoPlano == null)
            {
                return NotFound();
            }
            return View(tipoPlano);
        }

        // POST: TipoPlano/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPlanoId,NomeTipoPlano")] TipoPlano tipoPlano)
        {
            if (id != tipoPlano.TipoPlanoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPlano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPlanoExists(tipoPlano.TipoPlanoId))
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
            return View(tipoPlano);
        }

        // GET: TipoPlano/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoPlano == null)
            {
                return NotFound();
            }

            var tipoPlano = await _context.TipoPlano
                .FirstOrDefaultAsync(m => m.TipoPlanoId == id);
            if (tipoPlano == null)
            {
                return NotFound();
            }

            return View(tipoPlano);
        }

        // POST: TipoPlano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoPlano == null)
            {
                return Problem("Entity set 'Contexto.TipoPlano'  is null.");
            }
            var tipoPlano = await _context.TipoPlano.FindAsync(id);
            if (tipoPlano != null)
            {
                _context.TipoPlano.Remove(tipoPlano);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPlanoExists(int id)
        {
          return (_context.TipoPlano?.Any(e => e.TipoPlanoId == id)).GetValueOrDefault();
        }
    }
}
