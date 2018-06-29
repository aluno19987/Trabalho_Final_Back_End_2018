using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrabalhoFinalBackEnd.Models;

[assembly: OwinStartupAttribute(typeof(TrabalhoFinalBackEnd.Startup))]
namespace TrabalhoFinalBackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            iniciaAplicacao();
        }


        private void iniciaAplicacao()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Admin'
            if (!roleManager.RoleExists("Admin"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            

            // criar um utilizador 'Admin'
            var user = new ApplicationUser();
            user.UserName = "admin@mail.pt";
            user.Email = "admin@mail.pt";
            string userPWD = "123_Asd";
            var chkUser = userManager.Create(user, userPWD);
            

            // criar um utilizador 'utilizador1'
            var user2 = new ApplicationUser();
            user2.UserName = "util1@mail.pt";
            user2.Email = "util1@mail.pt";
            string userPWD2 = "123_Asd";
            var chkUser2 = userManager.Create(user2, userPWD2);


            // criar um utilizador 'utilizador2'
            var user3 = new ApplicationUser();
            user3.UserName = "util2@mail.pt";
            user3.Email = "util2@mail.pt";
            string userPWD3 = "123_Asd";
            var chkUser3 = userManager.Create(user3, userPWD3);
            
            // criar um utilizador 'utilizador3'
            var user4 = new ApplicationUser();
            user4.UserName = "util3@mail.pt";
            user4.Email = "util3@mail.pt";
            string userPWD4 = "123_Asd";
            var chkUser4 = userManager.Create(user4, userPWD4);
           
            // criar um utilizador 'utilizador4'
            var user5 = new ApplicationUser();
            user5.UserName = "util4@mail.pt";
            user5.Email = "util4@mail.pt";
            string userPWD5 = "123_Asd";
            var chkUser5 = userManager.Create(user5, userPWD5);
           
            // criar um utilizador 'utilizador5'
            var user6 = new ApplicationUser();
            user6.UserName = "util5@mail.pt";
            user6.Email = "util5@mail.pt";
            string userPWD6 = "123_Asd";
            var chkUser6 = userManager.Create(user6, userPWD6);

            //Adicionar o Utilizador à respetiva Role-Admin
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Admin");
            }
        }

    }
}
