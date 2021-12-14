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
    public class MembroTarefasController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public MembroTarefasController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: MembroTarefas
        public async Task<IActionResult> Index()
        {
            return View(await _context.MembroTarefa.ToListAsync());
        }

        // GET: MembroTarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroTarefa = await _context.MembroTarefa
                .FirstOrDefaultAsync(m => m.ID_MembroTarefa == id);
            if (membroTarefa == null)
            {
                return NotFound();
            }

            return View(membroTarefa);
        }

        // GET: MembroTarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembroTarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_MembroTarefa,IdTarefas,ID_membro,DataPrevistaInicio,DataEfetivaInicio,DataPrevistaFim,DataEfetivaFim")] MembroTarefa membroTarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membroTarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membroTarefa);
        }

        // GET: MembroTarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroTarefa = await _context.MembroTarefa.FindAsync(id);
            if (membroTarefa == null)
            {
                return NotFound();
            }
            return View(membroTarefa);
        }

        // POST: MembroTarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_MembroTarefa,IdTarefas,ID_membro,DataPrevistaInicio,DataEfetivaInicio,DataPrevistaFim,DataEfetivaFim")] MembroTarefa membroTarefa)
        {
            if (id != membroTarefa.ID_MembroTarefa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membroTarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroTarefaExists(membroTarefa.ID_MembroTarefa))
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
            return View(membroTarefa);
        }

        // GET: MembroTarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroTarefa = await _context.MembroTarefa
                .FirstOrDefaultAsync(m => m.ID_MembroTarefa == id);
            if (membroTarefa == null)
            {
                return NotFound();
            }

            return View(membroTarefa);
        }

        // POST: MembroTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membroTarefa = await _context.MembroTarefa.FindAsync(id);
            _context.MembroTarefa.Remove(membroTarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembroTarefaExists(int id)
        {
            return _context.MembroTarefa.Any(e => e.ID_MembroTarefa == id);
        }
    }
}
