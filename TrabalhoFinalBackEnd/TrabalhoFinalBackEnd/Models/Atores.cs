using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Atores
    {
        public Atores()
        {
            ListaPersonagens = new HashSet<Personagens>();
        }

        [Key]
        public int IdAtor { get; set; }

        
        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("[A-Za-záéíóúãõàèìòùâêîôûäëïöüñç'. 0-9-]+", ErrorMessage = "The {0} is not acceptable")]
        [Display(Name = "Name")]
        public string Nome { get; set; }

        
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        
        [Display(Name = "Image")]
        public string Imagem { get; set; }

        public virtual ICollection<Personagens> ListaPersonagens { get; set; }

        
}
}