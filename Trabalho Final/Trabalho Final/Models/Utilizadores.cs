using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Final.Models
{
    public class Utilizadores
    {

        public Utilizadores()
        {
            Lista_Reviews = new HashSet<Reviews>();
        }

        [Key]
        public int Id_utilizador { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Mail { get; set; }

        public virtual ICollection<Reviews> Lista_Reviews { get; set; }

    }
}