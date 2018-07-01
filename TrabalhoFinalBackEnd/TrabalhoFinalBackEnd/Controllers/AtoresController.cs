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
    public class AtoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Atores
        public ActionResult Index()
        {
            return View(db.Atores.ToList());
        }
        
        // GET: Atores/Details/5
        public ActionResult Details(int? id)
        {
            //se id null
            if (id == null)
            {
                //gera mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            Atores atores = db.Atores.Find(id);
            //se o ator não existir
            if (atores == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            return View(atores);
        }

        //GET: Atores/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Atores/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAtor,Nome,DataNascimento,Imagem")] Atores atores)
        {
            if (ModelState.IsValid)
            {
                db.Atores.Add(atores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //se model state for invalido 
            //gera mensagem de erro
            TempData["Error"] = "Unexpected error";
            //retorna para view create atores
            return View(atores);
        }

        // GET: Atores/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            //se o id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            Atores atores = db.Atores.Find(id);
            //se o ator nao existir
            if (atores == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            return View(atores);
        }

        // POST: Atores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAtor,Nome,DataNascimento,Imagem")] Atores atores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //se o model state nao for valido
            //cria mensagem de erro
            TempData["Error"] = "Unexpected error";
            //retorna para a view edit ator
            return View(atores);
        }

        // GET: Atores/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            //se o id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //retorna para o index
                return RedirectToAction("Index");
            }
            Atores atores = db.Atores.Find(id);
            //se o ator não existir
            if (atores == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //retorna para o index
                return RedirectToAction("Index");
            }
            return View(atores);
        }

        // POST: Atores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atores atores = db.Atores.Find(id);
            db.Atores.Remove(atores);
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
