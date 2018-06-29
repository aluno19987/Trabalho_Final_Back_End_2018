using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrabalhoFinalBackEnd.Models;

namespace Trabalho_Final.Models
{
    public class Reviews
    {
        [Key]
        public int IdReview { get; set; }

        //[Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Title")]
        public string TituloReview { get; set; }

        //[Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Review")]
        public string Review { get; set; }

        //[Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Number of Stars")]
        public int NStars { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }

    }
}