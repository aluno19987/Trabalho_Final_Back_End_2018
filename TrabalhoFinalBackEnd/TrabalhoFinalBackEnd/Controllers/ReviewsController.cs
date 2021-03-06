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

namespace TrabalhoFinalBackEnd.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews/Create
        [HttpGet]
        public ActionResult Create(int FilmeFK)
        {
            ViewBag.Filme = db.Filmes.Find(FilmeFK); 
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReview,TituloReview,Review,NStars,FilmeFK")] Reviews reviews)
        {
            //procura os dados do utilizador
            var utilizador =db.Utilizadores.Where(un => un.UserName == User.Identity.Name).Single();
            //atribui o id do utilizador a review
            reviews.UtilizadorFK = utilizador.ID;
            if (ModelState.IsValid)
            {
                reviews.Data = DateTime.Now;
                db.Reviews.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Details", "Filmes" , new { id = reviews.FilmeFK });
            }
            //se o model state nao for valido
            //cria mensagem de erro
            TempData["Error"] = "Unexpected error";
            ViewBag.FilmeFK = new SelectList(db.Filmes, "IdFilme", "Nome", reviews.FilmeFK);
            //redireciona para a view
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            //se id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
                return RedirectToAction("Index", "Filmes", null);
            }
            ViewBag.Filme = db.Reviews.Find(id).Filme.Nome;
            Reviews reviews = db.Reviews.Find(id);
            //se a rev
            if (reviews == null || User.Identity.Name!=reviews.Utilizador.UserName)
            {
                if (!User.IsInRole("Admin") || reviews == null)
                {
                    //cria mensagem de erro
                    TempData["Error"] = "Unexpected error";
                    //redireciona para o index do filme
                    return RedirectToAction("index", "Filmes");
                }
            }
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReview,TituloReview,Review,NStars,FilmeFK,UtilizadorFK")] Reviews reviews)
        {

            if (ModelState.IsValid)
            {
                //atribui a data
                reviews.Data = DateTime.Now;
                db.Entry(reviews).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Details","Filmes", new { id = reviews.FilmeFK});
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null || User.Identity.Name != reviews.Utilizador.UserName)
            {
                if (!User.IsInRole("Admin"))
                {
                    //cria mensagem de erro
                    TempData["Error"] = "Unexpected error";
                    //redireciona para o index dos filmes
                    return RedirectToAction("Index", "Filmes");
                }
            }
            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reviews reviews = db.Reviews.Find(id);
            db.Reviews.Remove(reviews);
            db.SaveChanges();
            return RedirectToAction("Details", "Filmes", new { id = reviews.FilmeFK });
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
