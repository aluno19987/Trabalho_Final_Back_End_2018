﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinalBackEnd.Models;
using Trabalho_Final.Models;
using System.IO;

namespace TrabalhoFinalBackEnd.Controllers
{
    public class PersonagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personagens
        public ActionResult Index()
        {
            var personagens = db.Personagens.Include(p => p.Ator).Include(p => p.Filme);
            return View(personagens.ToList());
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
        }

        // GET: Personagens/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int FilmeFK)
        {
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome");
            ViewBag.filme = db.Filmes.Find(FilmeFK);
            return View();
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersonagem,Nome,Imagem,FilmeFK,AtorFK")] Personagens personagens, HttpPostedFileBase fileUploadCartaz)
        {
            // determinar o ID do novo Filme
            int novoID = 0;
            // *****************************************
            // proteger a geração de um novo ID
            // *****************************************
            // determinar o nº de Filme na tabela
            if (db.Personagens.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Personagens.Max(a => a.IdPersonagem) + 1;
            }
            // atribuir o ID ao novo Filme
            personagens.IdPersonagem = novoID;

            string nomeFotografia = "img_pers_" + personagens.IdPersonagem + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensCartaz/"), nomeFotografia); // indica onde a imagem será guardada

            // guardar o nome da imagem na BD
            personagens.Imagem = nomeFotografia;
            if (fileUploadCartaz == null)
            {
                // não há imagem...
                ModelState.AddModelError("", "Image not provided"); // gera MSG de erro
                return View(personagens); // reenvia os dados do 'Agente' para a View
            }



            if (ModelState.IsValid)
            {
                db.Personagens.Add(personagens);
                db.SaveChanges();
                fileUploadCartaz.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Edit", "Filmes", new { id = personagens.FilmeFK });
            }

            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.filme =db.Filmes.Find(personagens.FilmeFK);
            return RedirectToAction("Create", "Personagens", new { FilmeFK = personagens.FilmeFK });
        }

        // GET: Personagens/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.FilmeFK = new SelectList(db.Filmes, "IdFilme", "Nome", personagens.FilmeFK);
            return View(personagens);
        }

        // POST: Personagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersonagem,Nome,Imagem,FilmeFK,AtorFK")] Personagens personagens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.FilmeFK = new SelectList(db.Filmes, "IdFilme", "Nome", personagens.FilmeFK);
            return View(personagens);
        }

        // GET: Personagens/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagens personagens = db.Personagens.Find(id);
            db.Personagens.Remove(personagens);
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