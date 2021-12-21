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
    public class ProjectsController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public ProjectsController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index(string nome_projeto, int page = 1)
        {
            var pagingInfo = new PagingInfo
            {
                CurrentPage = 1,
                TotalItems = _context.Project.Count()
            };

            var projetos = await _context.Project
                            // .Include(b =>)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new ProjetosListViewModels
                {
                    ListaProjetos = projetos,
                    PagingInfo = pagingInfo
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
                .FirstOrDefaultAsync(m => m.ID_projeto == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_projeto,Nome_projeto,EstadoProjeto,DataInicio,DataPrevistaFim,DataEfetivaFim,ClientesId")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Projeto criado";
                ViewBag.Message = "Projeto sucessfully .";
                return View("Sucess");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido", project.ClientesId);
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
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido", project.ClientesId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_projeto,Nome_projeto,EstadoProjeto,DataInicio,DataPrevistaFim,DataEfetivaFim,ClientesId")] Project project)
        {
            if (id != project.ID_projeto)
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
                    if (!ProjectExists(project.ID_projeto))
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
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClientesId", "Apelido", project.ClientesId);
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
                .FirstOrDefaultAsync(m => m.ID_projeto == id);
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
            return _context.Project.Any(e => e.ID_projeto == id);
        }
    }
}
