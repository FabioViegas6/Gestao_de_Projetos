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
    public class FuncaosController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public FuncaosController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Funcaos
        public async Task<IActionResult> Index(string NomeFuncao, int page = 1)
        {
            var FuncaosSearch = _context.Funcao
                  .Where(b => NomeFuncao == null || b.NomeFuncao.Contains(NomeFuncao));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = FuncaosSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var funcaos = await FuncaosSearch
                            //.Include(b => b.Author)
                            .OrderBy(b => b.NomeFuncao)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new FuncaoListViewModel
                {
                    ListFuncao = funcaos,
                    PagingInfo = pagingInfo,
                    FuncaoSearched = NomeFuncao
                }
            );
        }
    

        // GET: Funcaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .FirstOrDefaultAsync(m => m.FuncaoID == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // GET: Funcaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncaoID,NomeFuncao")] Funcao funcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcao);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Funcão adicionada";
                ViewBag.Message = "Funcão adicionada com sucesso.";
                return View("Success");
            }
            return View(funcao);
        }

        // GET: Funcaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }
            return View(funcao);
        }

        // POST: Funcaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncaoID,NomeFuncao")] Funcao funcao)
        {
            if (id != funcao.FuncaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncaoExists(funcao.FuncaoID))
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
            return View(funcao);
        }

        // GET: Funcaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .FirstOrDefaultAsync(m => m.FuncaoID == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // POST: Funcaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);
            _context.Funcao.Remove(funcao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcao.Any(e => e.FuncaoID == id);
        }
    }
}
