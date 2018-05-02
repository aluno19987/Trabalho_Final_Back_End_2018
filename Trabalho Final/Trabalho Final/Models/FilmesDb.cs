using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class FilmesDb: DbContext
    {

        public FilmesDb() : base("FilmesDb")
        {

        }

        //identificar as tabelas da base de dados
        public virtual DbSet<Categorias> Categorias { get; set; }

        public virtual DbSet<Filmes> Filmes { get; set; }

        public virtual DbSet<Multimedia> Multimedia { get; set; }

        public virtual DbSet<Reviews> Reviews { get; set; }

        public virtual DbSet<Utilizadores> Agentes { get; set; }

    }
}