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

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Imagem { get; set; }

        public virtual ICollection<Personagens> ListaPersonagens { get; set; }

        
}
}