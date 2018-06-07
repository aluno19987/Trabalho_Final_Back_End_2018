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
            ListaReviews = new HashSet<Reviews>();

            ListaCategorias = new HashSet<Categorias>();

            ListaImagens = new HashSet<Imagens>();

            ListaPersonagens = new HashSet<Personagens>();
        }

        [Key]
        public int IdFilme { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("[A-Za-záéíóúãõàèìòùâêîôûäëïöüç.: 0-9-]+", ErrorMessage = "The {0} is not acceptable")]
        [Display(Name = "Name")]
        public string Nome { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Launch Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Director")]
        [RegularExpression("[A-Za-záéíóúãõàèìòùâêîôûäëïöüç.: 0-9-]+", ErrorMessage = "The {0} is not acceptable")]
        public string Realizador { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Company")]
        [RegularExpression("[A-Za-záéíóúãõàèìòùâêîôûäëïöüç. 0-9-]+", ErrorMessage = "The {0} is not acceptable")]
        public string Companhia { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Duration")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Resume")]
        public string Resumo { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        public string Trailer { get; set; }
        
        [Display(Name = "Banner")]
        public string Cartaz { get; set; }

        public virtual ICollection<Reviews> ListaReviews { get; set; }

        [Display(Name = "Categories")]
        public virtual ICollection<Categorias> ListaCategorias { get; set; }

        public virtual ICollection<Imagens> ListaImagens { get; set; }

        public virtual ICollection<Personagens> ListaPersonagens { get; set; }

       
    }
}