using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class FilmesDb : DbContext
    {

        public FilmesDb() : base("FilmesDbConnectionString")
        {

        }

        //identificar as tabelas da base de dados
        public virtual DbSet<Categorias> Categorias { get; set; }
        
        public virtual DbSet<Filmes> Filmes { get; set; }

        public virtual DbSet<Imagens> Imagens { get; set; }

        public virtual DbSet<Reviews> Reviews { get; set; }

    }
}