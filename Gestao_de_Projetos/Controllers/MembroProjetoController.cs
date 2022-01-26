using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_de_Projetos.Data;
using Gestao_de_Projetos.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace Gestao_de_Projetos.Controllers
{
    [Authorize(Roles = "Gestor")]
    public class MembroProjetoController : Controller
    {
        private readonly Gestao_de_ProjetosContext _context;

        public MembroProjetoController(Gestao_de_ProjetosContext context)
        {
            _context = context;
        }

        // GET: MembroProjeto
        public async Task<IActionResult> Index()
        {
            var gestao_de_ProjetosContext = _context.MembroProjeto.Include(m => m.Membros).Include(m => m.Project);
            return View(await gestao_de_ProjetosContext.ToListAsync());
        }

        // GET: MembroProjeto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto
                .Include(m => m.Membros)
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.membroProjeto == id);
            if (membroProjeto == null)
            {
                return NotFound();
            }

            return View(membroProjeto);
        }

        // GET: MembroProjeto/Create
        [HttpGet]
        public async Task<IActionResult> Create(int? id, string erro)
        {
            List<MembroProjeto> membroProjetos = new List<MembroProjeto>();
            List<Membros> membros = new List<Membros>();
            List<Membros> membros_fora_projeto = new List<Membros>();

            membros = _context.Membros.Include(b => b.Funcao).ToList();

            foreach (var item in membros)
            {
                if (!_context.MembroProjeto.Any(mp => mp.MembrosID == item.MembrosID && mp.ProjectID == id))
                {
                    membros_fora_projeto.Add(item);
                }
            }
            

            ViewData["ProjectID"] = _context.Project.Where(p => p.ProjectID == id).ToList();
            ViewData["MembrosID"] = membros_fora_projeto;

            if (erro != null)
            {
                ViewBag.Message = erro;
            }
            return View();
        }
        // GET: MembroProjeto/ShowAllDelete
        [HttpGet]
        public IActionResult ShowAllDelete(int? id)
        {

            ViewData["ProjectID"] = _context.Project.Where(p => p.ProjectID == id).ToList();
            ViewData["MembroProjetoID"] = _context.MembroProjeto.Include(m => m.Membros).Include(m => m.Membros.Funcao).Include(m => m.Project).Where(mp => mp.ProjectID == id).ToList();

            return View();
        }

        // GET: MembroProjeto/ShowAll
        [HttpGet]
        public IActionResult ShowAll(int? id)
        {

            ViewData["ProjectID"] = _context.Project.Where(p => p.ProjectID == id).ToList();
            ViewData["MembroProjetoID"] = _context.MembroProjeto.Include(m => m.Membros).Include(m => m.Membros.Funcao).Include(m => m.Project).Where(mp => mp.ProjectID == id).ToList();

            return View();
        }

        // POST: MembroProjeto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembrosID,ProjectID,DataInicio,DataEfetivaFim")] MembroProjeto membroProjeto)
        {
            string Erro = "";

            if (membroProjeto.DataEfetivaFim < membroProjeto.DataInicio)
            {
                Erro = "Data Fim tem deve ser maior que a data inicio";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(membroProjeto);
                    await _context.SaveChangesAsync();
                }
            }
           
            return RedirectToAction("Create", "MembroProjeto", new { id = membroProjeto.ProjectID,erro= Erro });
        }

        // GET: MembroProjeto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto.Include(m => m.Membros).Include(m => m.Project).FirstOrDefaultAsync(h => h.membroProjeto==id);
                 
            if (membroProjeto == null)
            {
                return NotFound();
            }
            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Email", membroProjeto.MembrosID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto", membroProjeto.ProjectID);
            return View(membroProjeto);
        }

        // POST: MembroProjeto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("membroProjeto,MembrosID,ProjectID,DataInicio,DataEfetivaFim")] MembroProjeto Membropros)
        {
           

            if (id != Membropros.membroProjeto)
            {
                //membroProjeto,MembrosID,ProjectID,
                return NotFound();

            }

            
            //membroProjeto.membroProjeto = id;
            if (ModelState.IsValid)
            {
                try
                {
                   
                    _context.Update(Membropros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroProjetoExists(Membropros.membroProjeto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
          
            return RedirectToAction("ShowAll", new { id = Membropros.ProjectID });
        }

        // GET: MembroProjeto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto
                .Include(m => m.Membros)
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.membroProjeto == id);
            if (membroProjeto == null)
            {
                return NotFound();
            }

            return View(membroProjeto);
        }

        // POST: MembroProjeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membroProjeto = await _context.MembroProjeto.FindAsync(id);
            _context.MembroProjeto.Remove(membroProjeto);
            await _context.SaveChangesAsync();
            //  return RedirectToAction(nameof(Index));
            return RedirectToAction("ShowAllDelete", new { id = membroProjeto.ProjectID });
        }

        private bool MembroProjetoExists(int id)
        {
            return _context.MembroProjeto.Any(e => e.membroProjeto == id);
        }
    }
}
