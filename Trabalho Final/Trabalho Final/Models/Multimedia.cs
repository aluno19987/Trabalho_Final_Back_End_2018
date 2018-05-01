using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Multimedia
    {

        public Multimedia()
        {
            Lista_Filmes = new HashSet<Filmes>();
        }

        [Key]
        public int Id_mult { get; set; }

        [StringLength(40)]
        public string Nome { get; set; }

        public string Tipo { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }

        public virtual ICollection<Filmes> Lista_Filmes { get; set; }

    }
}