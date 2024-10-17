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
    public class PagamentoAgendamentoController : Controller
    {
        private readonly Contexto _context;

        public PagamentoAgendamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: PagamentoAgendamento
        public async Task<IActionResult> Index()
        {
            var contexto = _context.PagamentoAgendamento.Include(p => p.Agendamento).Include(p => p.FormaPagamento);
            return View(await contexto.ToListAsync());
        }

        // GET: PagamentoAgendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PagamentoAgendamento == null)
            {
                return NotFound();
            }

            var pagamentoAgendamento = await _context.PagamentoAgendamento
                .Include(p => p.Agendamento)
                .Include(p => p.FormaPagamento)
                .FirstOrDefaultAsync(m => m.PagamentoAgendamentoId == id);
            if (pagamentoAgendamento == null)
            {
                return NotFound();
            }

            return View(pagamentoAgendamento);
        }

        // GET: PagamentoAgendamento/Create
        public IActionResult Create()
        {
            ViewData["AgendamentoId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId");
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "NomeFormaPagamento");
            return View();
        }

        // POST: PagamentoAgendamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoAgendamentoId,AgendamentoId,FormaPagamentoId")] PagamentoAgendamento pagamentoAgendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoAgendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgendamentoId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId", pagamentoAgendamento.AgendamentoId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "NomeFormaPagamento", pagamentoAgendamento.FormaPagamentoId);
            return View(pagamentoAgendamento);
        }

        // GET: PagamentoAgendamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PagamentoAgendamento == null)
            {
                return NotFound();
            }

            var pagamentoAgendamento = await _context.PagamentoAgendamento.FindAsync(id);
            if (pagamentoAgendamento == null)
            {
                return NotFound();
            }
            ViewData["AgendamentoId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId", pagamentoAgendamento.AgendamentoId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "NomeFormaPagamento", pagamentoAgendamento.FormaPagamentoId);
            return View(pagamentoAgendamento);
        }

        // POST: PagamentoAgendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoAgendamentoId,AgendamentoId,FormaPagamentoId")] PagamentoAgendamento pagamentoAgendamento)
        {
            if (id != pagamentoAgendamento.PagamentoAgendamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoAgendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoAgendamentoExists(pagamentoAgendamento.PagamentoAgendamentoId))
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
            ViewData["AgendamentoId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId", pagamentoAgendamento.AgendamentoId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "FormaPagamentoId", "NomeFormaPagamento", pagamentoAgendamento.FormaPagamentoId);
            return View(pagamentoAgendamento);
        }

        // GET: PagamentoAgendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PagamentoAgendamento == null)
            {
                return NotFound();
            }

            var pagamentoAgendamento = await _context.PagamentoAgendamento
                .Include(p => p.Agendamento)
                .Include(p => p.FormaPagamento)
                .FirstOrDefaultAsync(m => m.PagamentoAgendamentoId == id);
            if (pagamentoAgendamento == null)
            {
                return NotFound();
            }

            return View(pagamentoAgendamento);
        }

        // POST: PagamentoAgendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PagamentoAgendamento == null)
            {
                return Problem("Entity set 'Contexto.PagamentoAgendamento'  is null.");
            }
            var pagamentoAgendamento = await _context.PagamentoAgendamento.FindAsync(id);
            if (pagamentoAgendamento != null)
            {
                _context.PagamentoAgendamento.Remove(pagamentoAgendamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoAgendamentoExists(int id)
        {
          return (_context.PagamentoAgendamento?.Any(e => e.PagamentoAgendamentoId == id)).GetValueOrDefault();
        }
    }
}
