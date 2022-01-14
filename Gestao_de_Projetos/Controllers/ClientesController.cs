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
    public class ClientesController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public ClientesController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string NomeCliente, int page = 1)
        {
            var ClientesSearch = _context.Clientes
                .Where(b => NomeCliente == null || b.Nome.Contains(NomeCliente));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = ClientesSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var cliente = await ClientesSearch
                            //.Include(b => b.Author)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new ClientesListViewModel
                {
                    ListaClientes = cliente,
                    PagingInfo = pagingInfo,
                    ClienteSearched = NomeCliente
                }
            );
        }
        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClientesId == id);
            if (clientes == null)
            {
                return NotFound();
            }
            //ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
            return View(clientes);
        }

        // GET: Membros/Create
        //public IActionResult Create()
        //{
        //    ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome_Funcao");
        //    return View();
        //}

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientesId,Nome,Apelido,Contacto,NIF,Email,Password")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Cliente adicionado";
                ViewBag.Message = "Cliente adicionado com sucesso.";
                return View("Success");
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientesId,Nome,Apelido,Contacto,NIF,Email,Password")] Clientes clientes)
        {
            if (id != clientes.ClientesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClientesId))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClientesId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClientesId == id);
        }
    }
}
