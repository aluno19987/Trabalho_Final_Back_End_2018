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
    [RoutePrefix("actors")]
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atores atores = db.Atores.Find(id);
            if (atores == null)
            {
                return HttpNotFound();
            }
            return View(atores);
        }

        // GET: Atores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

            return View(atores);
        }

        // GET: Atores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atores atores = db.Atores.Find(id);
            if (atores == null)
            {
                return HttpNotFound();
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
            return View(atores);
        }

        // GET: Atores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atores atores = db.Atores.Find(id);
            if (atores == null)
            {
                return HttpNotFound();
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
