using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Trabalho_Final.Models;

namespace TrabalhoFinalBackEnd.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    { 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //identificar as tabelas da base de dados
        public virtual DbSet<Categorias> Categorias { get; set; }

        public virtual DbSet<Filmes> Filmes { get; set; }

        public virtual DbSet<Imagens> Imagens { get; set; }

        public virtual DbSet<Reviews> Reviews { get; set; }

        public virtual DbSet<Atores> Atores { get; set; }

        public virtual DbSet<Personagens> Personagens { get; set; }

        public virtual DbSet<Utilizadores> Utilizadores { get; set; }

    }
}