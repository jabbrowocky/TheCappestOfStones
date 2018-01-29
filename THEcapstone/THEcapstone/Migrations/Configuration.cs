namespace THEcapstone.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<THEcapstone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(THEcapstone.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.States.AddOrUpdate(
                s => s.StateName,
                new States { StateName = "Alabama"},
                new States { StateName = "Alaska"},
                new States { StateName = "Arizona"},
                new States { StateName = "Arkansas" },
                new States { StateName = "California" },
                new States { StateName = "Colorado" },
                new States { StateName = "Connecticut" },
                new States { StateName = "Delaware" },
                new States { StateName = "Florida" },
                new States { StateName = "Georgia" },
                new States { StateName = "Hawaii" },
                new States { StateName = "Idaho" },
                new States { StateName = "Illinois" },
                new States { StateName = "Indiana" },
                new States { StateName = "Iowa" },
                new States { StateName = "Kansas" },
                new States { StateName = "Kentucky" },
                new States { StateName = "Louisiana" },
                new States { StateName = "Maine" },
                new States { StateName = "Maryland" },
                new States { StateName = "Massachusetts" },
                new States { StateName = "Michigan" },
                new States { StateName = "Minnesota" },
                new States { StateName = "Mississippi" },
                new States { StateName = "Missouri" },
                new States { StateName = "Montana" },
                new States { StateName = "Nebraska" },
                new States { StateName = "Nevada" },
                new States { StateName = "New Hampshire" },
                new States { StateName = "New Jersey" },
                new States { StateName = "New Mexico" },
                new States { StateName = "New York" },
                new States { StateName = "North Carolina" },
                new States { StateName = "North Dakota" },
                new States { StateName = "Ohio" },
                new States { StateName = "Oklahoma" },
                new States { StateName = "Oregon" },
                new States { StateName = "Pennsylvania" },
                new States { StateName = "Rhode Island" },
                new States { StateName = "South Carolina" },
                new States { StateName = "South Dakota" },
                new States { StateName = "Tennessee" },
                new States { StateName = "Texas" },
                new States { StateName = "Utah" },
                new States { StateName = "Vermont" },
                new States { StateName = "Virginia" },
                new States { StateName = "Washington" },
                new States { StateName = "West Virginia" },
                new States { StateName = "Wisconsin" },
                new States { StateName = "Wyoming" }
                );


            context.Messages.Add(new Message { MsgText = "Hello Lori", SentOn = DateTime.Today, Opened = false, Deleted = false, TargetId = "13b11038-bbed-4a6e-8775-7770c22582d4"});
            
        }
    }
}
