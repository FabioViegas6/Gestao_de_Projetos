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
    public class MembrosController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public MembrosController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Membros
        public async Task<IActionResult> Index(string NomeMembro, int page = 1)
        {


            var MembroSearched = _context.Membros
                .Where(b => NomeMembro == null || b.Nome_membro.Contains(NomeMembro));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = MembroSearched.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var membros = await MembroSearched
                            .Include(b => b.Funcao)
                            .OrderBy(b => b.Nome_membro)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new MembroListViewModel
                {
                    ListaMembros = membros,
                    PagingInfo = pagingInfo,
                    membroSearched = NomeMembro
                }
            );
        }


        // GET: Membros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membros = await _context.Membros
                .FirstOrDefaultAsync(m => m.MembrosID == id);
            if (membros == null)
            {
                return NotFound();
            }
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
            return View(membros);
        }

        // GET: Membros/Create
        public IActionResult Create()
        {
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
            return View();
        }

        // POST: Membros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembrosID,Nome_membro,Telefone,NIF,Email,Password,FuncaoID")] Membros membros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membros);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Membro adicionado";
                ViewBag.Message = "Membro adicionado com sucesso.";
                return View("Success");
            }
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
            return View(membros);
        }

        // GET: Membros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membros = await _context.Membros.FindAsync(id);
            if (membros == null)
            {
                return NotFound();
            }
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
            return View(membros);
        }

        // POST: Membros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembrosID,Nome_membro,Sobrenome,Telefone,NIF,Email,Password,FuncaoID")] Membros membros)
        {
            if (id != membros.MembrosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembrosExists(membros.MembrosID))
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
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
            return View(membros);
        }

        // GET: Membros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membros = await _context.Membros
                .FirstOrDefaultAsync(m => m.MembrosID == id);
            if (membros == null)
            {
                return NotFound();
            }

            return View(membros);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membros = await _context.Membros.FindAsync(id);
            _context.Membros.Remove(membros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembrosExists(int id)
        {
            return _context.Membros.Any(e => e.MembrosID == id);
        }
    }
}
