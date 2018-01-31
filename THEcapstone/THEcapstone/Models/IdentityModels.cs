using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace THEcapstone.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string RoleToAdd {get;set;}
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<VetProfile> VetProfiles { get; set; }
        public DbSet<PetSitter> PetSitters { get; set; }
        public DbSet<DogWalker> DogWalkers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WalkerProfile> WalkerProfiles { get; set; }
        public DbSet<PetSitterProfile> SitterProfiles { get; set; }
    }
}