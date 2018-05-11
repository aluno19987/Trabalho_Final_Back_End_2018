using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Imagens
    {
        
        [Key]
        public int IdImg { get; set; }

        [StringLength(40)]
        public string Nome { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }

    }
}