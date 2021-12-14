using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_de_Projetos.Data;
using Gestao_de_Projetos.Models;

namespace Gestao_de_Projetos.Controllers
{
    public class MembroProjetosController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;


        public MembroProjetosController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: MembroProjetoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MembroProjeto.ToListAsync());
        }

        // GET: MembroProjetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto
                .FirstOrDefaultAsync(m => m.ID_MembroProjeto == id);
            if (membroProjeto == null)
            {
                return NotFound();
            }

            return View(membroProjeto);
        }

        // GET: MembroProjetoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembroProjetoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_MembroProjeto,ID_projeto,ID_membro,DataInicio,DataPrevistaFim,DataFim")] MembroProjeto membroProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membroProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membroProjeto);
        }

        // GET: MembroProjetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto.FindAsync(id);
            if (membroProjeto == null)
            {
                return NotFound();
            }
            return View(membroProjeto);
        }

        // POST: MembroProjetoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_MembroProjeto,ID_projeto,ID_membro,DataInicio,DataPrevistaFim,DataFim")] MembroProjeto membroProjeto)
        {
            if (id != membroProjeto.ID_MembroProjeto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membroProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroProjetoExists(membroProjeto.ID_MembroProjeto))
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
            return View(membroProjeto);
        }

        // GET: MembroProjetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto
                .FirstOrDefaultAsync(m => m.ID_MembroProjeto == id);
            if (membroProjeto == null)
            {
                return NotFound();
            }

            return View(membroProjeto);
        }

        // POST: MembroProjetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membroProjeto = await _context.MembroProjeto.FindAsync(id);
            _context.MembroProjeto.Remove(membroProjeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembroProjetoExists(int id)
        {
            return _context.MembroProjeto.Any(e => e.ID_MembroProjeto == id);
        }
    }
}
