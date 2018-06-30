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
using System.IO;

namespace TrabalhoFinalBackEnd.Controllers
{
    public class PersonagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            return View(personagens);
        }

        // GET: Personagens/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int? FilmeFK)
        {
            if (FilmeFK == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome");
            ViewBag.filme = db.Filmes.Find(FilmeFK);
            return View();
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersonagem,Nome,Imagem,FilmeFK,AtorFK")] Personagens personagens, HttpPostedFileBase fileUpload)
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
            personagens.IdPersonagem = novoID;

            string nomeFotografia = "img_pers_" + personagens.IdPersonagem + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensPersonagens/"), nomeFotografia); // indica onde a imagem será guardada

            // guardar o nome da imagem na BD
            personagens.Imagem = nomeFotografia;
            if (fileUpload == null)
            {
                // não há imagem...
                TempData["Error"] = "Unexpected error"; // gera MSG de erro
                return RedirectToAction("Create", new { FilmeFk = personagens.FilmeFK }); // reenvia os dados do 'Personagem' para a View
            }


            if (ModelState.IsValid)
            {
                db.Personagens.Add(personagens);
                db.SaveChanges();
                fileUpload.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Edit", "Filmes", new { id = personagens.FilmeFK });
            }

            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.filme =db.Filmes.Find(personagens.FilmeFK);
            TempData["Error"] = "Unexpected error";
            return RedirectToAction("Create", "Personagens", new { FilmeFK = personagens.FilmeFK });
        }

        // GET: Personagens/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.filme = personagens.Filme;
            return View(personagens);
        }

        // POST: Personagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersonagem,Nome,Imagem,FilmeFK,AtorFK")] Personagens personagens, HttpPostedFileBase fileUploadPersonagem)
        {
            string nomeFotografia = "img_pers_" + personagens.IdPersonagem + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensPersonagens/"), nomeFotografia); // indica onde a imagem será guardada
            personagens.Imagem = nomeFotografia;

            if (ModelState.IsValid)
            {
                db.Entry(personagens).State = EntityState.Modified;
                db.SaveChanges();
                if (fileUploadPersonagem!=null)
                {
                    fileUploadPersonagem.SaveAs(caminhoParaFotografia);
                }

                return RedirectToAction("Edit","Filmes", new { id = personagens.FilmeFK });
            }
            TempData["Error"] = "Unexpected error";
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.filme = personagens.Filme;
            return View(personagens);
        }

        // GET: Personagens/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes");
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                TempData["Error"] = "Unexpected error";
                return RedirectToAction("Index", "Filmes", null);
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
            return RedirectToAction("Edit", "Filmes", new { id = personagens.FilmeFK });
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
