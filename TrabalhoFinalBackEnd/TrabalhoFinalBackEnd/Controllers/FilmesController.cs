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
using System.Collections;

namespace TrabalhoFinalBackEnd.Controllers
{
    [RoutePrefix("movies")]
    public class FilmesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Filmes
        public ActionResult Index()
        {
            return View(db.Filmes.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return RedirectToAction("Index");
            }
            return View(filmes);
        }



        // GET: Filmes/Create
        public ActionResult Create()
        {
            ViewBag.listaDeCategorias = db.Categorias.ToList();
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFilme,Nome,DataLancamento,Realizador,Companhia,Duracao,Resumo,Trailer,Cartaz")] Filmes filme, HttpPostedFileBase fileUploadCartaz, int[] idCategorias)
        {
            // determinar o ID do novo Filme
            int novoID = 0;
            // *****************************************
            // proteger a geração de um novo ID
            // *****************************************
            // determinar o nº de Filme na tabela
            if (db.Filmes.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Filmes.Max(a => a.IdFilme) + 1;
            }
            // atribuir o ID ao novo Filme
            filme.IdFilme = novoID;

            foreach (int categ in idCategorias)
            {
                filme.ListaCategorias.Add(db.Categorias.Find(idCategorias));
            }

            filme.Trailer = filme.Trailer.Substring(32);
            string nomeFotografia = "img_cartaz_" + filme.IdFilme + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/imagens/"), nomeFotografia); // indica onde a imagem será guardada
            
            // guardar o nome da imagem na BD
            filme.Cartaz = nomeFotografia;
            if (fileUploadCartaz == null)
            {
                // não há imagem...
                ModelState.AddModelError("", "Image not provided"); // gera MSG de erro
                return View(filme); // reenvia os dados do 'Agente' para a View
            }

            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                fileUploadCartaz.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.listaDeCategorias = db.Categorias.ToList();
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            filmes.Trailer = "https://www.youtube.com/watch?v=" + filmes.Trailer;

            if (filmes == null)
            {
                return RedirectToAction("Index");
            }
            return View(filmes);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFilme,Nome,DataLancamento,Realizador,Companhia,Duracao,Resumo,Trailer,Cartaz")] Filmes filme, HttpPostedFileBase fileUploadCartaz, int[] idCategorias)
        {
            var filmeBU = db.Filmes.Include(f => f.ListaCategorias).Where(f => f.IdFilme == filme.IdFilme).SingleOrDefault();
            string nomeCartaz = "img_cartaz_" + filme.IdFilme + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensCartaz/"), nomeCartaz); // indica onde a imagem será guardada
            filme.Trailer = filme.Trailer.Substring(32);
            if (ModelState.IsValid)
            {
                filmeBU.Trailer = filme.Trailer;
                filmeBU.Cartaz = nomeCartaz;
                filmeBU.Nome = filme.Nome;
                filmeBU.Realizador = filme.Realizador;
                filmeBU.Companhia = filme.Companhia;
                filmeBU.Resumo = filme.Resumo;
                filmeBU.Duracao = filme.Duracao;
                filmeBU.DataLancamento = filme.DataLancamento;

            }
            else
            {
                return View(filme);
            }

            var categorias = db.Categorias.ToList();

            if(idCategorias != null)
            {
                foreach( var cat in categorias)
                {
                    if (idCategorias.Contains(cat.IdCategoria))
                    {
                        if (!filmeBU.ListaCategorias.Contains(cat))
                        {
                            filmeBU.ListaCategorias.Add(cat);
                        }
                    }
                    else
                    {
                        filmeBU.ListaCategorias.Remove(cat);                     
                    }
                }
            }
            else
            {
                foreach (var cat in categorias)
                {
                    if (filmeBU.ListaCategorias.Contains(cat))
                    {
                        filmeBU.ListaCategorias.Remove(cat);
                    }
                }
            }

            //tentar fazer update
            if (TryUpdateModel(filmeBU, "", new string[] {nameof(filmeBU.Cartaz), nameof(filmeBU.Duracao),nameof(filmeBU.DataLancamento), nameof(filmeBU.ListaCategorias),nameof(filmeBU.Realizador),nameof(filmeBU.Resumo) }))
            {
                // guardar as alterações
                db.SaveChanges();
                
                //se existir imagem guarda-la na base de dados
                if (fileUploadCartaz != null)
                {
                    fileUploadCartaz.SaveAs(caminhoParaFotografia);
                }

                // devolver controlo à View
                return RedirectToAction("Index");
            }

            // se cheguei aqui, é pq alguma coisa correu mal
            ModelState.AddModelError("", "Something went wrong...");
            
            // visualizar View...
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return RedirectToAction("Index");
            }
            return View(filmes);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filmes filmes = db.Filmes.Find(id);
            db.Filmes.Remove(filmes);
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
