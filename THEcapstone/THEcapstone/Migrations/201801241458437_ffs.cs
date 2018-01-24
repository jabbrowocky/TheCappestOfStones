namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.Veterinarians",
                c => new
                    {
                        VetId = c.Int(nullable: false, identity: true),
                        VetName = c.String(),
                        AddressId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VetId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.ProfileId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veterinarians", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Veterinarians", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Veterinarians", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Veterinarians", new[] { "UserId" });
            DropIndex("dbo.Veterinarians", new[] { "ProfileId" });
            DropIndex("dbo.Veterinarians", new[] { "AddressId" });
            DropTable("dbo.Veterinarians");
            DropTable("dbo.Profiles");
        }
    }
}
