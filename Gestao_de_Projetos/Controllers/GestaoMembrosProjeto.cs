using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Controllers
{
    public class GestaoMembrosProjetoController : Controller
    {
        // GET: GestaoMembrosProjetoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GestaoMembrosProjetoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GestaoMembrosProjetoController/Create
        [ActionName("projeto_adiciconar_men")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GestaoMembrosProjetoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestaoMembrosProjetoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GestaoMembrosProjetoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestaoMembrosProjetoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestaoMembrosProjetoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
