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
    public class AssinaturaClubeController : Controller
    {
        private readonly Contexto _context;

        public AssinaturaClubeController(Contexto context)
        {
            _context = context;
        }

        // GET: AssinaturaClube
        public async Task<IActionResult> Index()
        {
            var contexto = _context.AssinaturaClube.Include(a => a.Cliente).Include(a => a.Clube);
            return View(await contexto.ToListAsync());
        }

        // GET: AssinaturaClube/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssinaturaClube == null)
            {
                return NotFound();
            }

            var assinaturaClube = await _context.AssinaturaClube
                .Include(a => a.Cliente)
                .Include(a => a.Clube)
                .FirstOrDefaultAsync(m => m.AssinaturaClubeId == id);
            if (assinaturaClube == null)
            {
                return NotFound();
            }

            return View(assinaturaClube);
        }

        // GET: AssinaturaClube/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewData["ClubeId"] = new SelectList(_context.Clube, "ClubeId", "NomeClube");
            return View();
        }

        // POST: AssinaturaClube/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssinaturaClubeId,ClienteId,ClubeId")] AssinaturaClube assinaturaClube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assinaturaClube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", assinaturaClube.ClienteId);
            ViewData["ClubeId"] = new SelectList(_context.Clube, "ClubeId", "NomeClube", assinaturaClube.ClubeId);
            return View(assinaturaClube);
        }

        // GET: AssinaturaClube/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssinaturaClube == null)
            {
                return NotFound();
            }

            var assinaturaClube = await _context.AssinaturaClube.FindAsync(id);
            if (assinaturaClube == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", assinaturaClube.ClienteId);
            ViewData["ClubeId"] = new SelectList(_context.Clube, "ClubeId", "NomeClube", assinaturaClube.ClubeId);
            return View(assinaturaClube);
        }

        // POST: AssinaturaClube/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssinaturaClubeId,ClienteId,ClubeId")] AssinaturaClube assinaturaClube)
        {
            if (id != assinaturaClube.AssinaturaClubeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assinaturaClube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssinaturaClubeExists(assinaturaClube.AssinaturaClubeId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", assinaturaClube.ClienteId);
            ViewData["ClubeId"] = new SelectList(_context.Clube, "ClubeId", "NomeClube", assinaturaClube.ClubeId);
            return View(assinaturaClube);
        }

        // GET: AssinaturaClube/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssinaturaClube == null)
            {
                return NotFound();
            }

            var assinaturaClube = await _context.AssinaturaClube
                .Include(a => a.Cliente)
                .Include(a => a.Clube)
                .FirstOrDefaultAsync(m => m.AssinaturaClubeId == id);
            if (assinaturaClube == null)
            {
                return NotFound();
            }

            return View(assinaturaClube);
        }

        // POST: AssinaturaClube/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssinaturaClube == null)
            {
                return Problem("Entity set 'Contexto.AssinaturaClube'  is null.");
            }
            var assinaturaClube = await _context.AssinaturaClube.FindAsync(id);
            if (assinaturaClube != null)
            {
                _context.AssinaturaClube.Remove(assinaturaClube);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssinaturaClubeExists(int id)
        {
          return (_context.AssinaturaClube?.Any(e => e.AssinaturaClubeId == id)).GetValueOrDefault();
        }
    }
}
