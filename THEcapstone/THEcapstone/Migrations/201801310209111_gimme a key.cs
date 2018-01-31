namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gimmeakey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetSitterProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SitterFirstName = c.String(),
                        SitterLastName = c.String(),
                        CityName = c.String(),
                        BriefDescription = c.String(),
                        ExperienceDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PetSitters", "ProfileId");
            AddForeignKey("dbo.PetSitters", "ProfileId", "dbo.PetSitterProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetSitters", "ProfileId", "dbo.PetSitterProfiles");
            DropIndex("dbo.PetSitters", new[] { "ProfileId" });
            DropTable("dbo.PetSitterProfiles");
        }
    }
}
