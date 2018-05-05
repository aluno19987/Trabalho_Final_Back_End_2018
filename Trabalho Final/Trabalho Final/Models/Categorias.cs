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
            Lista_Filmes = new HashSet<Filmes>();
        }

        [Key]
        public int Id_categoria { get; set; }

        [StringLength(40)]
        public string Nome { get; set; }

        public virtual ICollection<Filmes> Lista_Filmes { get; set; }
        
    }
}