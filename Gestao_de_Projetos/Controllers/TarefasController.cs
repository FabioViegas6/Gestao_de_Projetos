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
    public class TarefasController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public TarefasController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index(string NomeTarefa, int page = 1)
        {
            var tarefaSearched = _context.Tarefas
                  .Where(b => NomeTarefa == null || b.Nome_Tarefa.Contains(NomeTarefa));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = tarefaSearched.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var Tarefa = await tarefaSearched
                            .Include(b => b.Project)
                            .Include(t => t.Estado)
                            .Include(b => b.Membros)
                            .OrderBy(b => b.Nome_Tarefa)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new TarefasListViewModel
                {
                    ListaTarefas = Tarefa,
                    PagingInfo = pagingInfo,
                    tarefasSearched = NomeTarefa
                }
            );
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Membros)
                .Include(t => t.Project)
                .Include(t => t.Estado)
               .SingleOrDefaultAsync(m => m.TarefasID == id);


            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }


        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Nome_membro");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado");
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarefasID,Nome_Tarefa,Descricao,DataPrevistaInicio,DataEfetivaInicio,DataPrevistaFim,DataEfetivaFim,ProjectID,MembrosID")] Tarefas tarefas)
        {
            if (tarefas.DataPrevistaFim < tarefas.DataEfetivaInicio || tarefas.DataPrevistaFim < tarefas.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }
            if (ModelState.IsValid)
            {
                if (tarefas.DataPrevistaInicio < tarefas.DataEfetivaInicio)
                {
                    tarefas.EstadoID = 1;
                }
                if (tarefas.DataPrevistaInicio >= tarefas.DataEfetivaInicio)
                {
                    tarefas.EstadoID = 2;
                }
                _context.Add(tarefas);
                await _context.SaveChangesAsync();


                ViewBag.Title = "Tarefa adicionada";
                ViewBag.Message = "Tarefa adicionada com sucesso.";
                return View("Success");
            }

           
            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Nome_membro", tarefas.MembrosID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", tarefas.EstadoID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto", tarefas.ProjectID);
            return View(tarefas);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }

            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Nome_membro", tarefas.MembrosID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", tarefas.EstadoID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto", tarefas.ProjectID);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarefasID,Nome_Tarefa,Descricao,DataPrevistaInicio,DataEfetivaInicio,DataPrevistaFim,DataEfetivaFim,ProjectID,MembrosID")] Tarefas tarefas)
        {
            if (id != tarefas.TarefasID)
            {
                return NotFound();
            }

            if (tarefas.DataPrevistaFim < tarefas.DataEfetivaInicio || tarefas.DataPrevistaFim < tarefas.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tarefas.DataPrevistaInicio < tarefas.DataEfetivaInicio)
                    {
                        tarefas.EstadoID = 1;
                    }
                    if (tarefas.DataPrevistaInicio >= tarefas.DataEfetivaInicio)
                    {
                        tarefas.EstadoID = 2;
                    }

                    if (tarefas.DataEfetivaFim != null && tarefas.DataEfetivaFim >= tarefas.DataEfetivaInicio)
                    {
                        tarefas.EstadoID = 3;
                    }
                    _context.Update(tarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasExists(tarefas.TarefasID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Title = "Tarefa Alterada";
                ViewBag.Message = "Tarefa alterada com sucesso!!!.";
                return View("Success");
            }

            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Nome_membro", tarefas.MembrosID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "NomeEstado", tarefas.EstadoID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto", tarefas.ProjectID);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tarefas = await _context.Tarefas
                .Include(t => t.Membros)
                .Include(t => t.Project)
                .Include(t => t.Estado)
                .FirstOrDefaultAsync(m => m.TarefasID == id);
                if (tarefas == null)
                {
                    return NotFound();
                }

                return View(tarefas);
            }
            catch (DbUpdateException /* ex */)
            {

                return View("MensagemErro");
            }
        }
        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tarefas = await _context.Tarefas.FindAsync(id);
                _context.Tarefas.Remove(tarefas);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                ViewBag.Title = "Tarefa Apagada";
                ViewBag.Message = "Tarefa apagada com sucesso!!!";
                return View("Success");
            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Esta tarefa não pode ser apagada.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }


        public IActionResult Success()
        {
            return View();
        }

        public IActionResult MensagemErro()
        {
            return View();
        }

        [Authorize(Roles = "Clientes")]
        public string Buy(int id)
        {
            var username = User.Identity.Name;

            //var customer = _context.Customer.SingleOrDefault(c => c.Email == username);
            //if (customer == null) return NotFound();

            // ...

            return "The option for customers to buy books will be added soon !!!";
        }

        private bool TarefasExists(int id)
        {
            return _context.Tarefas.Any(e => e.TarefasID == id);
        }
    }
}
