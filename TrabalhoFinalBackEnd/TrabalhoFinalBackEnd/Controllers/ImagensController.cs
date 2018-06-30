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
    public class ImagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Imagens/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int FilmeFK)
        {
            ViewBag.filme = db.Filmes.Find(FilmeFK);
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdImg,Nome,FilmeFK")] Imagens imagens, HttpPostedFileBase fileUpload)
        {
            // determinar o ID da nova imagem
            int novoID = 0;
            // *****************************************
            // proteger a geração de um novo ID
            // *****************************************
            // determinar o nº de Filme na tabela
            if (db.Imagens.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Imagens.Max(a => a.IdImg) + 1;
            }
            // atribuir o ID ao novo Filme
            imagens.IdImg = novoID;
            
            string nomeFotografia = "img_" + imagens.IdImg + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/Imagens/"), nomeFotografia); // indica onde a imagem será guardada

            // guardar o nome da imagem na BD
            imagens.Nome = nomeFotografia;
            if (fileUpload == null)
            {
                // não há imagem...
                ModelState.AddModelError("", "Image not provided"); // gera MSG de erro
                return RedirectToAction("Create",new { FilmeFk = imagens.FilmeFK}); // reenvia os dados do 'Personagem' para a View
            }
            
            if (ModelState.IsValid)
            {
                db.Imagens.Add(imagens);
                db.SaveChanges();
                fileUpload.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Edit", "Filmes", new { id = imagens.FilmeFK });
            }

            ViewBag.FilmeFK = new SelectList(db.Filmes, "IdFilme", "Nome", imagens.FilmeFK);
            TempData["Error"] = "Unexpected error";
            return RedirectToAction("Edit", "Filmes", new { id = imagens.FilmeFK });
        }


        // GET: Imagens/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            Imagens imagens = db.Imagens.Find(id);
            ViewBag.filme = imagens.Filme;
            if (imagens == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            return View(imagens);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagens imagens = db.Imagens.Find(id);
            db.Imagens.Remove(imagens);
            db.SaveChanges();
            return RedirectToAction("Edit","Filmes", new { id = imagens.FilmeFK });
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
