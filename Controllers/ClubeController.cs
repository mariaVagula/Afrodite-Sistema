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
    public class ClubeController : Controller
    {
        private readonly Contexto _context;

        public ClubeController(Contexto context)
        {
            _context = context;
        }

        // GET: Clube
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Clube.Include(c => c.TipoClube).Include(c => c.TipoPlano);
            return View(await contexto.ToListAsync());
        }

        // GET: Clube/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clube == null)
            {
                return NotFound();
            }

            var clube = await _context.Clube
                .Include(c => c.TipoClube)
                .Include(c => c.TipoPlano)
                .FirstOrDefaultAsync(m => m.ClubeId == id);
            if (clube == null)
            {
                return NotFound();
            }

            return View(clube);
        }

        // GET: Clube/Create
        public IActionResult Create()
        {
            ViewData["TipoClubeId"] = new SelectList(_context.TipoClube, "TipoClubeId", "NomeTipoClube");
            ViewData["TipoPlanoId"] = new SelectList(_context.TipoPlano, "TipoPlanoId", "NomeTipoPlano");
            return View();
        }

        // POST: Clube/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubeId,NomeClube,TipoClubeId,TipoPlanoId,DetalhesClube,ValorClube")] Clube clube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoClubeId"] = new SelectList(_context.TipoClube, "TipoClubeId", "NomeTipoClube", clube.TipoClubeId);
            ViewData["TipoPlanoId"] = new SelectList(_context.TipoPlano, "TipoPlanoId", "NomeTipoPlano", clube.TipoPlanoId);
            return View(clube);
        }

        // GET: Clube/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clube == null)
            {
                return NotFound();
            }

            var clube = await _context.Clube.FindAsync(id);
            if (clube == null)
            {
                return NotFound();
            }
            ViewData["TipoClubeId"] = new SelectList(_context.TipoClube, "TipoClubeId", "NomeTipoClube", clube.TipoClubeId);
            ViewData["TipoPlanoId"] = new SelectList(_context.TipoPlano, "TipoPlanoId", "NomeTipoPlano", clube.TipoPlanoId);
            return View(clube);
        }

        // POST: Clube/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubeId,NomeClube,TipoClubeId,TipoPlanoId,DetalhesClube,ValorClube")] Clube clube)
        {
            if (id != clube.ClubeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubeExists(clube.ClubeId))
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
            ViewData["TipoClubeId"] = new SelectList(_context.TipoClube, "TipoClubeId", "NomeTipoClube", clube.TipoClubeId);
            ViewData["TipoPlanoId"] = new SelectList(_context.TipoPlano, "TipoPlanoId", "NomeTipoPlano", clube.TipoPlanoId);
            return View(clube);
        }

        // GET: Clube/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clube == null)
            {
                return NotFound();
            }

            var clube = await _context.Clube
                .Include(c => c.TipoClube)
                .Include(c => c.TipoPlano)
                .FirstOrDefaultAsync(m => m.ClubeId == id);
            if (clube == null)
            {
                return NotFound();
            }

            return View(clube);
        }

        // POST: Clube/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clube == null)
            {
                return Problem("Entity set 'Contexto.Clube'  is null.");
            }
            var clube = await _context.Clube.FindAsync(id);
            if (clube != null)
            {
                _context.Clube.Remove(clube);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubeExists(int id)
        {
          return (_context.Clube?.Any(e => e.ClubeId == id)).GetValueOrDefault();
        }
    }
}
