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
    public class PagamentoAssinaturaController : Controller
    {
        private readonly Contexto _context;

        public PagamentoAssinaturaController(Contexto context)
        {
            _context = context;
        }

        // GET: PagamentoAssinatura
        public async Task<IActionResult> Index()
        {
            var contexto = _context.PagamentoAssinatura.Include(p => p.AssinaturaClube).Include(p => p.FormaPagamento);
            return View(await contexto.ToListAsync());
        }

        // GET: PagamentoAssinatura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PagamentoAssinatura == null)
            {
                return NotFound();
            }

            var pagamentoAssinatura = await _context.PagamentoAssinatura
                .Include(p => p.AssinaturaClube)
                .Include(p => p.FormaPagamento)
                .FirstOrDefaultAsync(m => m.PagamentoAssinaturaId == id);
            if (pagamentoAssinatura == null)
            {
                return NotFound();
            }

            return View(pagamentoAssinatura);
        }

        // GET: PagamentoAssinatura/Create
        public IActionResult Create()
        {
            ViewData["AssinaturaClubeId"] = new SelectList(_context.AssinaturaClube, "AssinaturaClubeId", "AssinaturaClube");
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "FormaPagamento");
            return View();
        }

        // POST: PagamentoAssinatura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoAssinaturaId,AssinaturaClubeId,FormaPagamentoId")] PagamentoAssinatura pagamentoAssinatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoAssinatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssinaturaClubeId"] = new SelectList(_context.AssinaturaClube, "AssinaturaClubeId", "AssinaturaClube", pagamentoAssinatura.AssinaturaClubeId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "FormaPagamento", pagamentoAssinatura.FormaPagamentoId);
            return View(pagamentoAssinatura);
        }

        // GET: PagamentoAssinatura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PagamentoAssinatura == null)
            {
                return NotFound();
            }

            var pagamentoAssinatura = await _context.PagamentoAssinatura.FindAsync(id);
            if (pagamentoAssinatura == null)
            {
                return NotFound();
            }
            ViewData["AssinaturaClubeId"] = new SelectList(_context.AssinaturaClube, "AssinaturaClubeId", "AssinaturaClube", pagamentoAssinatura.AssinaturaClubeId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "FormaPagamento", pagamentoAssinatura.FormaPagamentoId);
            return View(pagamentoAssinatura);
        }

        // POST: PagamentoAssinatura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoAssinaturaId,AssinaturaClubeId,FormaPagamentoId")] PagamentoAssinatura pagamentoAssinatura)
        {
            if (id != pagamentoAssinatura.PagamentoAssinaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoAssinatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoAssinaturaExists(pagamentoAssinatura.PagamentoAssinaturaId))
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
            ViewData["AssinaturaClubeId"] = new SelectList(_context.AssinaturaClube, "AssinaturaClubeId", "AssinaturaClube", pagamentoAssinatura.AssinaturaClubeId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "FormaPagamento", pagamentoAssinatura.FormaPagamentoId);
            return View(pagamentoAssinatura);
        }

        // GET: PagamentoAssinatura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PagamentoAssinatura == null)
            {
                return NotFound();
            }

            var pagamentoAssinatura = await _context.PagamentoAssinatura
                .Include(p => p.AssinaturaClube)
                .Include(p => p.FormaPagamento)
                .FirstOrDefaultAsync(m => m.PagamentoAssinaturaId == id);
            if (pagamentoAssinatura == null)
            {
                return NotFound();
            }

            return View(pagamentoAssinatura);
        }

        // POST: PagamentoAssinatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PagamentoAssinatura == null)
            {
                return Problem("Entity set 'Contexto.PagamentoAssinatura'  is null.");
            }
            var pagamentoAssinatura = await _context.PagamentoAssinatura.FindAsync(id);
            if (pagamentoAssinatura != null)
            {
                _context.PagamentoAssinatura.Remove(pagamentoAssinatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoAssinaturaExists(int id)
        {
          return (_context.PagamentoAssinatura?.Any(e => e.PagamentoAssinaturaId == id)).GetValueOrDefault();
        }
    }
}
