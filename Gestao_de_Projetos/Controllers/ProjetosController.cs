using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_de_Projetos.Data;
using Gestao_de_Projetos.Models;
using Gestao_de_Projetos.ViewModels;

namespace Gestao_de_Projetos.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public ProjetosController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Projetos
        public async Task<IActionResult> Index(string nomeProjeto, int page = 1)
        {

            var gestao_de_ProjetosContext = _context.Projetos
              .Include(p => p.Clientes)
              .Include(p => p.Estado_Projeto)
              .Where(b => nomeProjeto == null || b.Nome_projeto.Contains(nomeProjeto));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = gestao_de_ProjetosContext.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var projetos = await gestao_de_ProjetosContext
                            .Include(b => b.Clientes)
                            .Include(b => b.Estado_Projeto)
                            .OrderBy(b => b.Nome_projeto)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();
            return View(
                new ProjetosListViewModels
                {
                    ListaProjetos = projetos,
                    PagingInfo = pagingInfo,
                    ProjetoSearched = nomeProjeto
                });

        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos
                .Include(p => p.Clientes)
                .Include(p => p.Estado_Projeto)
                .FirstOrDefaultAsync(m => m.ID_projeto == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido");
            ViewData["EstadoID"] = new SelectList(_context.Estado_Projeto, "ID_Estado", "Nome");
            return View();
        }

        // POST: Projetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_projeto,ClientesId,Nome_projeto,ID_Estado")] Projetos projetos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projetos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido", projetos.ClientesId);
            ViewData["EstadoID"] = new SelectList(_context.Estado_Projeto, "ID_Estado", "Nome", projetos.ID_Estado);
            return View(projetos);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos.FindAsync(id);
            if (projetos == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido", projetos.ClientesId);
            return View(projetos);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_projeto,ClientesId,Nome_projeto,ID_Estado")] Projetos projetos)
        {
            if (id != projetos.ID_projeto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projetos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetosExists(projetos.ID_projeto))
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
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido", projetos.ClientesId);
            return View(projetos);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos
                .Include(p => p.Clientes)
                .FirstOrDefaultAsync(m => m.ID_projeto == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetos = await _context.Projetos.FindAsync(id);
            _context.Projetos.Remove(projetos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetosExists(int id)
        {
            return _context.Projetos.Any(e => e.ID_projeto == id);
        }
    }
}
