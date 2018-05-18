using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Reviews
    {
        [Key]
        public int IdReview { get; set; }

        public string TituloReview { get; set; }
        
        public string Review { get; set; }

        public int NStars { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }
        
            
    }
}