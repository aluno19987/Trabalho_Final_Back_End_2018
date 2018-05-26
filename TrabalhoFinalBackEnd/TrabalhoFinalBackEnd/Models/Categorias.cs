using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Categorias
    {

        public Categorias()
        {
            ListaFilmes = new HashSet<Filmes>();
        }

        [Key]
        public int IdCategoria { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        [Display(Name = "Name")]
        [StringLength(40)]
        public string Nome { get; set; }

        public virtual ICollection<Filmes> ListaFilmes { get; set; }
        
    }
}