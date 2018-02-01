using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using THEcapstone.Models;
using Stripe;


[assembly: OwinStartupAttribute(typeof(THEcapstone.Startup))]
namespace THEcapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            KeyManager manager = new KeyManager();
            var key = manager.StripeKey;
            ConfigureAuth(app);
            createRolesandUsers();
            StripeConfiguration.SetApiKey(key);
            
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Jabbrowocky";
                user.Email = "mindbull3tz@gmail.com";
                string userPWD = "Sk@tin06";
                var createdUser = userManager.Create(user, userPWD);

                if (createdUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }
            if(!roleManager.RoleExists("Dog Walker"))
            {
                var role = new IdentityRole();
                role.Name = "Dog Walker";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Pet-Sitter"))
            {
                var role = new IdentityRole();
                role.Name = "Pet-Sitter";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Veterinarian"))
            {
                var role = new IdentityRole();
                role.Name = "Veterinarian";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
