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
               .Where(b => nomeProjeto == null || b.Nome_projeto.Contains(nomeProjeto) || b.Estado.NomeEstado.Contains(nomeProjeto));

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
        [Authorize(Roles = "Gestor")]
        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado");
            return View();
        }
        [Authorize(Roles = "Gestor")]
        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,Nome_projeto,EstadoProjeto,DataInicio,DataPrevistaFim,DataEfetivaFim,ClientesId,EstadoID")] Project project)
        {
            if (project.DataPrevistaFim < project.DataPrevistaInicio || project.DataPrevistaFim < project.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }
            if (ModelState.IsValid)
            {
                if (project.DataPrevistaInicio < project.DataInicio)
                {
                    project.EstadoID = 1;
                }
                if (project.DataPrevistaInicio >= project.DataInicio)
                {
                    project.EstadoID = 2;
                }
         

                _context.Add(project);
                await _context.SaveChangesAsync();
                //   return RedirectToAction(nameof(Index));

                ViewBag.Title = "Projeto adicionado";
                ViewBag.Message = "Projeto adicionado com sucesso!!!";
                return View("Sucess");
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado");

            return View(project);
        }
        [Authorize(Roles = "Gestor,Membro")]
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
        [Authorize(Roles = "Gestor,Membro")]
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

            if (project.DataPrevistaFim < project.DataInicio || project.DataPrevistaFim < project.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (project.DataPrevistaInicio < project.DataInicio)
                    {
                        project.EstadoID = 1;
                    }
                    if (project.DataPrevistaInicio >= project.DataInicio)
                    {
                        project.EstadoID = 2;
                    }

                    if (project.DataEfetivaFim != null && project.DataEfetivaFim >= project.DataInicio)
                    {
                        project.EstadoID= 3;
                    }
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
                // return RedirectToAction(nameof(Index));

                ViewBag.Title = "Projeto alterado";
                ViewBag.Message = "projeto alterado com sucesso!!!.";
                return View("Sucess");
            
        }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Nome", project.ClientesId);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", project.EstadoID);
            return View(project);
        }
        [Authorize(Roles = "Gestor")]
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
        [Authorize(Roles = "Gestor")]
        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {

                var project = await _context.Project.FindAsync(id);
                var cliente = _context.Clientes.Where(c => c.ClientesId == project.ClientesId);
                if (cliente != null)
                {

                    ViewBag.Message = "Nao se pode apagar o projeto, pois o cliente ainda existe na base de dados!";
                    return View(project);
                    
                }
                _context.Project.Remove(project);
                await _context.SaveChangesAsync();
 
                ViewBag.Title = "Projeto Apagado";
                ViewBag.Message = "Projeto apagado com sucesso!!!";
                return View("Sucess");
            }

            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Este projeto não pode ser apagado.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }
        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectID == id);
        }
    }
}
