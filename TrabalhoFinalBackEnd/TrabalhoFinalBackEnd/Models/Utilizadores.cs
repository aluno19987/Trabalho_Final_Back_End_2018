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

        public string Nome { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<Reviews> ListaReviews { get; set; }

    }
}
