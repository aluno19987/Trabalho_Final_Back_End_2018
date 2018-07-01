using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinalBackEnd.Models;
using Trabalho_Final.Models;

namespace TrabalhoFinalBackEnd.Controllers
{
    [RoutePrefix("Categories")]
    public class CategoriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }
        

        public PartialViewResult PartialIndex()
        {
            return PartialView("~/Views/Shared/_CategoriasPartial.cshtml", db.Categorias.ToList().OrderBy(d=>d.Nome));
        }

        // GET: Categorias/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoria,Nome")] Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //se o model state não for valido
            //cria mensagem de erro
            TempData["Error"] = "Unexpected error";
            //redireciona para a view create categorias
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            //se o id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
                return RedirectToAction("Index", "Filmes", null);
            }
            Categorias categorias = db.Categorias.Find(id);
            //se a categoria nao existir
            if (categorias == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
                return RedirectToAction("Index", "Filmes", null);
            }
            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorias categorias = db.Categorias.Find(id);
            db.Categorias.Remove(categorias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
