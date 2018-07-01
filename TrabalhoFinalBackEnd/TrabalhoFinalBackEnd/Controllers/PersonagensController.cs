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
            //se id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
                return RedirectToAction("Index", "Filmes", null);
            }
            Personagens personagens = db.Personagens.Find(id);
            //se a personagem nao existir
            if (personagens == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
                return RedirectToAction("Index", "Filmes", null);
            }
            return View(personagens);
        }

        // GET: Personagens/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int? FilmeFK)
        {
            //se o filmeFK for null
            if (FilmeFK == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos fimes
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
            // determinar o nº de imagens na tabela
            if (db.Imagens.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Imagens.Max(a => a.IdImg) + 1;
            }
            // atribuir o Id a nova imagem
            personagens.IdPersonagem = novoID;

            //cria o nome para a imagem
            string nomeFotografia = "img_pers_" + personagens.IdPersonagem + ".jpg";
            //cria o caminho para a imagem
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensPersonagens/"), nomeFotografia); // indica onde a imagem será guardada

            // guardar o nome da imagem na BD
            personagens.Imagem = nomeFotografia;
            //se nao existir imagem
            if (fileUpload == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error"; 
                //redireciona para a view
                return RedirectToAction("Create", new { FilmeFk = personagens.FilmeFK }); 
            }


            if (ModelState.IsValid)
            {
                db.Personagens.Add(personagens);
                db.SaveChanges();
                //guarda a imagem
                fileUpload.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Edit", "Filmes", new { id = personagens.FilmeFK });
            }
            //se o model state nao for valido
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.filme =db.Filmes.Find(personagens.FilmeFK);
            //cria mensagem de erro
            TempData["Error"] = "Unexpected error";
            //redireciona para a view 
            return RedirectToAction("Create", "Personagens", new { FilmeFK = personagens.FilmeFK });
        }

        // GET: Personagens/Edit/5
        [Authorize(Roles = "Admin")]
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
            Personagens personagens = db.Personagens.Find(id);
            //se a personagem nao existir
            if (personagens == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
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
            //cria o nome para a imagem
            string nomeFotografia = "img_pers_" + personagens.IdPersonagem + ".jpg";
            //cria o caminho para a imagem
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensPersonagens/"), nomeFotografia); 
            //atribui o nome a imagem
            personagens.Imagem = nomeFotografia;

            if (ModelState.IsValid)
            {
                db.Entry(personagens).State = EntityState.Modified;
                db.SaveChanges();
                //se a imagem for alterada
                if (fileUploadPersonagem!=null)
                {
                    //guarda na base de dados a imagem
                    fileUploadPersonagem.SaveAs(caminhoParaFotografia);
                }

                return RedirectToAction("Edit","Filmes", new { id = personagens.FilmeFK });
            }
            //se o model state for null
            //cria mensagem de erro
            TempData["Error"] = "Unexpected error";
            ViewBag.AtorFK = new SelectList(db.Atores, "IdAtor", "Nome", personagens.AtorFK);
            ViewBag.filme = personagens.Filme;
            //redireciona para a view
            return View(personagens);
        }

        // GET: Personagens/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            //se id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filme
                return RedirectToAction("Index", "Filmes");
            }
            Personagens personagens = db.Personagens.Find(id);
            //se a personagem nao existir
            if (personagens == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index dos filmes
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
