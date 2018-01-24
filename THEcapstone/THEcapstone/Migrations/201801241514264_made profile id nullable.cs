namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeprofileidnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veterinarians", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Veterinarians", new[] { "ProfileId" });
            AlterColumn("dbo.Veterinarians", "ProfileId", c => c.Int());
            CreateIndex("dbo.Veterinarians", "ProfileId");
            AddForeignKey("dbo.Veterinarians", "ProfileId", "dbo.Profiles", "ProfileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veterinarians", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Veterinarians", new[] { "ProfileId" });
            AlterColumn("dbo.Veterinarians", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Veterinarians", "ProfileId");
            AddForeignKey("dbo.Veterinarians", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
        }
    }
}
