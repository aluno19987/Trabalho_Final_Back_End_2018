using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class FilmesDb
    {

        public FilmesDb() : base("FilmesDbConnectionString")
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