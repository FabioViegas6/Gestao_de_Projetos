﻿using System;
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
        public IActionResult Create()
        {
            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Email");
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto");
            return View();
        }

        // POST: MembroProjeto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("membroProjeto,MembrosID,ProjectID,DataInicio,DataPrevistaFim,DataEfetivaFim")] MembroProjeto membroProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membroProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Email", membroProjeto.MembrosID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto", membroProjeto.ProjectID);
            return View(membroProjeto);
        }

        // GET: MembroProjeto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroProjeto = await _context.MembroProjeto.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("membroProjeto,MembrosID,ProjectID,DataInicio,DataPrevistaFim,DataEfetivaFim")] MembroProjeto membroProjeto)
        {
            if (id != membroProjeto.membroProjeto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membroProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroProjetoExists(membroProjeto.membroProjeto))
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
            ViewData["MembrosID"] = new SelectList(_context.Membros, "MembrosID", "Email", membroProjeto.MembrosID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Nome_projeto", membroProjeto.ProjectID);
            return View(membroProjeto);
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
            return RedirectToAction(nameof(Index));
        }

        private bool MembroProjetoExists(int id)
        {
            return _context.MembroProjeto.Any(e => e.membroProjeto == id);
        }
    }
}
