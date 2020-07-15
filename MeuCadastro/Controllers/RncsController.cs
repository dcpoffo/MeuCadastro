using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuCadastro.Contexto;
using MeuCadastro.Models;

namespace MeuCadastro.Controllers
{
    public class RncsController : Controller
    {
        private readonly CadastroContext _context;

        public RncsController(CadastroContext context)
        {
            _context = context;
        }

        // GET: Rncs
        public async Task<IActionResult> Index()
        {
            var cadastroContext = _context.Rnc.Include(r => r.Cliente).Include(r => r.Produto);
            return View(await cadastroContext.ToListAsync());
        }

        // GET: Rncs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rnc = await _context.Rnc
                .Include(r => r.Cliente)
                .Include(r => r.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rnc == null)
            {
                return NotFound();
            }

            return View(rnc);
        }

        // GET: Rncs/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "Descricao");
            return View();
        }

        // POST: Rncs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAbertura,IdProduto,IdCliente")] Rnc rnc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rnc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Nome", rnc.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "Descricao", rnc.IdProduto);
            return View(rnc);
        }

        // GET: Rncs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rnc = await _context.Rnc.FindAsync(id);
            if (rnc == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Nome", rnc.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "Descricao", rnc.IdProduto);
            return View(rnc);
        }

        // POST: Rncs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataAbertura,IdProduto,IdCliente")] Rnc rnc)
        {
            if (id != rnc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rnc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RncExists(rnc.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Nome", rnc.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "Id", "Descricao", rnc.IdProduto);
            return View(rnc);
        }

        // GET: Rncs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rnc = await _context.Rnc
                .Include(r => r.Cliente)
                .Include(r => r.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rnc == null)
            {
                return NotFound();
            }

            return View(rnc);
        }

        // POST: Rncs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rnc = await _context.Rnc.FindAsync(id);
            _context.Rnc.Remove(rnc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RncExists(int id)
        {
            return _context.Rnc.Any(e => e.Id == id);
        }
    }
}
