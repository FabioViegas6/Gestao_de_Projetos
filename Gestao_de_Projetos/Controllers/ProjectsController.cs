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
using Microsoft.AspNetCore.Authorization;

namespace Gestao_de_Projetos.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    { public IActionResult Sucess()
        {
            return View();

        }
        private readonly Gestao_de_ProjetosContext _context;

        public ProjectsController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index(string nomeProjeto, int page = 1)
        {
            var ProjectSearch = _context.Project
               .Where(b => nomeProjeto == null || b.Nome_projeto.Contains(nomeProjeto));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = ProjectSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var projetos = await ProjectSearch
                            .Include(b => b.Clientes)
                            .Include(b => b.Estado)
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
                }
            );
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Clientes)
                 .Include(b => b.Estado)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,Nome_projeto,EstadoProjeto,DataInicio,DataPrevistaFim,DataEfetivaFim,ClientesId,EstadoID")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Projeto criado";
                ViewBag.Message = "Projeto adicionado com sucesso.";
                return View("Sucess");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome", project.ClientesId);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", project.EstadoID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome", project.ClientesId);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", project.EstadoID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,Nome_projeto,EstadoProjeto,DataInicio,DataPrevistaFim,DataEfetivaFim,ClientesId,EstadoID")] Project project)
        {
            if (id != project.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectID))
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
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome", project.ClientesId);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", project.EstadoID);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Clientes)
                 .Include(b => b.Estado)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectID == id);
        }
    }
}
