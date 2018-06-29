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
        [Display(Name = "Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPersonagem { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("[A-Za-záéíóúãõàèìòùâêîôûäëïöüç.:() 0-9-]+", ErrorMessage = "The {0} is not acceptable")]
        [Display(Name = "Name")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Image")]
        public string Imagem { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }

        [ForeignKey("Ator")]
        public int AtorFK { get; set; }
        public virtual Atores Ator { get; set; }

        
    }
}