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
    public class TipoClubeController : Controller
    {
        private readonly Contexto _context;

        public TipoClubeController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoClube
        public async Task<IActionResult> Index()
        {
              return _context.TipoClube != null ? 
                          View(await _context.TipoClube.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoClube'  is null.");
        }

        // GET: TipoClube/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoClube == null)
            {
                return NotFound();
            }

            var tipoClube = await _context.TipoClube
                .FirstOrDefaultAsync(m => m.TipoClubeId == id);
            if (tipoClube == null)
            {
                return NotFound();
            }

            return View(tipoClube);
        }

        // GET: TipoClube/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoClube/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoClubeId,NomeTipoClube")] TipoClube tipoClube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoClube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoClube);
        }

        // GET: TipoClube/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoClube == null)
            {
                return NotFound();
            }

            var tipoClube = await _context.TipoClube.FindAsync(id);
            if (tipoClube == null)
            {
                return NotFound();
            }
            return View(tipoClube);
        }

        // POST: TipoClube/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoClubeId,NomeTipoClube")] TipoClube tipoClube)
        {
            if (id != tipoClube.TipoClubeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoClube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoClubeExists(tipoClube.TipoClubeId))
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
            return View(tipoClube);
        }

        // GET: TipoClube/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoClube == null)
            {
                return NotFound();
            }

            var tipoClube = await _context.TipoClube
                .FirstOrDefaultAsync(m => m.TipoClubeId == id);
            if (tipoClube == null)
            {
                return NotFound();
            }

            return View(tipoClube);
        }

        // POST: TipoClube/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoClube == null)
            {
                return Problem("Entity set 'Contexto.TipoClube'  is null.");
            }
            var tipoClube = await _context.TipoClube.FindAsync(id);
            if (tipoClube != null)
            {
                _context.TipoClube.Remove(tipoClube);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoClubeExists(int id)
        {
          return (_context.TipoClube?.Any(e => e.TipoClubeId == id)).GetValueOrDefault();
        }
    }
}
