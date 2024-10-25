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
    public class ProcedimentoController : Controller
    {
        private readonly Contexto _context;

        public ProcedimentoController(Contexto context)
        {
            _context = context;
        }
      
        // GET: Procedimento
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                var contexto = _context.Procedimento.Include(t => t.TipoProcedimento);
                return View(await contexto.ToListAsync());
            }
            else
            {
                var contexto = _context.Procedimento.Include(t => t.TipoProcedimento)
                    .Where(x => x.NomeProcedimento.Contains(pesquisa));
                return View(await contexto.ToListAsync());
            }

        }

        // GET: Procedimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedimento == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimento.Include(t=>t.TipoProcedimento)
                .FirstOrDefaultAsync(m => m.ProcedimentoId == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // GET: Procedimento/Create
        public IActionResult Create()
        {
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "TipoProcedimentoId", "NomeTipoProcedimento" );
            return View();
        }

        // POST: Procedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedimentoId,NomeProcedimento,ValorProcedimento, TipoProcedimentoId")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "TipoProcedimentoId", "NomeTipoProcedimento", procedimento.TipoProcedimentoId);
            return View(procedimento);
        }

        // GET: Procedimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedimento == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimento.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "TipoProcedimentoId", "NomeTipoProcedimento", procedimento.TipoProcedimentoId);
            return View(procedimento);
        }

        // POST: Procedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedimentoId,NomeProcedimento,ValorProcedimento, TipoProcedimentoId")] Procedimento procedimento)
        {
            if (id != procedimento.ProcedimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoExists(procedimento.ProcedimentoId))
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
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "TipoProcedimentId", "NomeTipoProcedimento", procedimento.TipoProcedimentoId);
            return View(procedimento);
        }

        // GET: Procedimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedimento == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimento.Include(t => t.TipoProcedimento)
                .FirstOrDefaultAsync(m => m.ProcedimentoId == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // POST: Procedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedimento == null)
            {
                return Problem("Entity set 'Contexto.Procedimento'  is null.");
            }
            var procedimento = await _context.Procedimento.FindAsync(id);
            if (procedimento != null)
            {
                _context.Procedimento.Remove(procedimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoExists(int id)
        {
          return (_context.Procedimento?.Any(e => e.ProcedimentoId == id)).GetValueOrDefault();
        }
    }
}
