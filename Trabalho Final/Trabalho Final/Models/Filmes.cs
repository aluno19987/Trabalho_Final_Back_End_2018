using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Filmes
    {

        public Filmes()
        {
            Lista_Reviews = new HashSet<Reviews>();

            Lista_Categorias = new HashSet<Categorias>();
        }

        [Key]
        public int Id_filme { get; set; }

        [StringLength(40)]
        public string Nome { get; set; }

        public string Data_lancamento { get; set; }

        public string Realizador { get; set; }

        public string Companhia { get; set; }

        public string Elenco { get; set; }

        public string Duracao { get; set; }

        public string Trailer { get; set; }

        public string Cartaz { get; set; }

        public virtual ICollection<Reviews> Lista_Reviews { get; set; }

        public virtual ICollection<Categorias> Lista_Categorias { get; set; }

        public virtual ICollection<Imagens> Lista_Imagens { get; set; }

       
    }
}