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
        public ActionResult Index( int? idCategoria)
        {
            var model = db.Filmes.ToList();
            //se o id categoria nao for null e se existir essa categoria
            if (idCategoria != null && idCategoria <= db.Categorias.Count())
            {
                //ira buscar a base de dados a categoria
                var Categoria = db.Categorias.Find(idCategoria);
                //ira buscar lista de categorias
                var filmes = db.Filmes.ToList();
                //por cada filme na lista de categorias
                foreach (var filme in filmes)
                {
                    //se o filme não pertencer a categorias
                    if (!Categoria.ListaFilmes.Contains(filme))
                    {
                        //remove do model
                        model.Remove(filme);
                    }
                }
            }
            return View(model);
        }

        public ActionResult _Index2Partial()
        {
            //coloca na view bag o filme mais recente
            var listaFilme = db.Filmes.OrderBy(d => d.DataLancamento).ToList();
            var tam = db.Filmes.Count();
            ViewBag.recente = listaFilme[tam-1];

            //coloca na view bag o filme mais popular
            var filmeMostPopular = 0;
            var numeroReviews = 0;
            for(int i=0; i<listaFilme.Count();i++)
            {
                if (listaFilme[i].ListaReviews.Count() >= numeroReviews)
                {
                    filmeMostPopular = i;
                    numeroReviews = listaFilme[i].ListaReviews.Count();
                }
            }
            ViewBag.MostPopular = listaFilme[filmeMostPopular];

            //coloca na view bag o filme com melhor classificação
            var filmeBestRated = 0;
            var melhorPontuacao = 0;
            var pontuacao = 0;
            for (int i = 0; i < listaFilme.Count(); i++)
            {
                pontuacao = 0;
                int tamanho = listaFilme[i].ListaReviews.Count();
                foreach (var review in listaFilme[i].ListaReviews)
                {
                    pontuacao += review.NStars;
                }
                pontuacao = pontuacao / tamanho;
                if(pontuacao>= melhorPontuacao)
                {
                    melhorPontuacao = pontuacao;
                    filmeBestRated = i;
                }
            }
            ViewBag.BestRated = listaFilme[filmeBestRated];

            var model = db.Filmes.ToList();
            return PartialView(model);
        }


        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            //se id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            //se o filme nao existir
            if (filmes == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            //calculo da pontuação dos filmes
            var reviews = db.Reviews.Where(dd => dd.FilmeFK == filmes.IdFilme).ToList();
            var numReviews = db.Reviews.Where(dd => dd.FilmeFK == filmes.IdFilme).Count();
            var pontuacao=0;

            foreach (var review in reviews)
            {
                pontuacao += review.NStars;
            }
            pontuacao = pontuacao / numReviews;
            ViewBag.classificacao=pontuacao;
            
            return View(filmes);
        }



        // GET: Filmes/Create
        [Authorize(Roles = "Admin")]
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
        public ActionResult Create([Bind(Include = "IdFilme,Nome,DataLancamento,Realizador,Companhia,Duracao,Resumo,Trailer,Cartaz")] Filmes filme, HttpPostedFileBase fileUploadCartaz,HttpPostedFileBase[] files, int[] idCategorias)
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
            
            //se a lista de categorias selecionada for diferente de null adiciona a categoria ao filme
            if (idCategorias != null) { 
                var Categorias = db.Categorias.ToList();
            
                foreach (var cat in Categorias)
                {
                    if (idCategorias.Contains(cat.IdCategoria))
                    {
                        filme.ListaCategorias.Add(cat);
                    }
                }
            }
            //edita a string o trailer
            filme.Trailer = filme.Trailer.Substring(32);
            //cria o nome para a fotografia
            string nomeFotografia = "img_cartaz_" + filme.IdFilme + ".jpg";
            //cria o caminho para a foto
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/ImagensCartaz/"), nomeFotografia); // indica onde a imagem será guardada
            
            // guardar o nome da imagem na BD
            filme.Cartaz = nomeFotografia;
            //se nao existir imagem
            if (fileUploadCartaz == null)
            {
                //cria mensagem de erro
                ModelState.AddModelError("", "Image not provided"); 
                //redireciona para a view create 
                return View(filme); 
            }


            // determinar o ID das novas imagens
            int imgID = 0;
            // *****************************************
            // determinar o nº de imagens na tabela
            if (db.Imagens.Count() == 0)
            {
                imgID = 1;
            }
            else
            {
                imgID = db.Imagens.Max(a => a.IdImg) + 1;
            }

            //por cada imagem 
            for (var i = 0; i < files.Length;i++)
            {
                var img = files[i];
                var imagem = new Imagens();

                // atribuir o ID da nova imagem
                imagem.IdImg = novoID;
                imagem.FilmeFK = filme.IdFilme;

                //criar o nome da nova imagem 
                string nomeImg = "img_" + imagem.IdImg + ".jpg";
                //criar o caminho da nova imagem
                string pathFotografia = Path.Combine(Server.MapPath("~/imagens/"), nomeImg); // indica onde a imagem será guardada

                // guardar o nome da imagem na BD
                imagem.Nome = nomeImg;
                if (ModelState.IsValid)
                {
                    db.Imagens.Add(imagem);
                    img.SaveAs(pathFotografia);
                }
                novoID++;
            }

            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                fileUploadCartaz.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Edit","Filmes",new { id = filme.IdFilme});
            }

            TempData["Error"] = "Unexpected error";
            return View(filme);
        }

        // GET: Filmes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            ViewBag.listaDeCategorias = db.Categorias.ToList();
            //se o id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            //se nao existir o filme
            if (filmes == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }

            filmes.Trailer = "https://www.youtube.com/watch?v=" + filmes.Trailer;
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
            TempData["Error"] = "Unexpected error";

            // visualizar View...
            return View(filme);
        }

        // GET: Filmes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            //se id for null
            if (id == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            //se o filme não existir
            if (filmes == null)
            {
                //cria mensagem de erro
                TempData["Error"] = "Unexpected error";
                //redireciona para o index
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
