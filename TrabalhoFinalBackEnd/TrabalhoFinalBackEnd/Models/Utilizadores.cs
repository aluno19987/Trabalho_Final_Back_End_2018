using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Trabalho_Final.Models;


namespace TrabalhoFinalBackEnd.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaReviews = new HashSet<Reviews>();
        }


        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("[A-Za-záéíóúãõàèìòùâêîôûäëïöüñç'. 0-9-]+", ErrorMessage = "The {0} is not acceptable")]
        [Display(Name = "Name")]
        public string Nome { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<Reviews> ListaReviews { get; set; }

    }
}
