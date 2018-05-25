using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Personagens
    {
        [Key]
        public int IdPersonagem { get; set; }
         
        public string Nome { get; set; }

        public string Imagem { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }

        [ForeignKey("Ator")]
        public int AtorFK { get; set; }
        public virtual Atores Ator { get; set; }

        
    }
}