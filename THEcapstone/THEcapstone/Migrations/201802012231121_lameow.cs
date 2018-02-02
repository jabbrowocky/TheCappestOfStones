namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lameow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceRequests", "PetSitter_SitterId", "dbo.PetSitters");
            DropIndex("dbo.ServiceRequests", new[] { "PetSitter_SitterId" });
            AddColumn("dbo.Customers", "PetSitter_SitterId", c => c.Int());
            CreateIndex("dbo.Customers", "PetSitter_SitterId");
            AddForeignKey("dbo.Customers", "PetSitter_SitterId", "dbo.PetSitters", "SitterId");
            DropColumn("dbo.ServiceRequests", "PetSitter_SitterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceRequests", "PetSitter_SitterId", c => c.Int());
            DropForeignKey("dbo.Customers", "PetSitter_SitterId", "dbo.PetSitters");
            DropIndex("dbo.Customers", new[] { "PetSitter_SitterId" });
            DropColumn("dbo.Customers", "PetSitter_SitterId");
            CreateIndex("dbo.ServiceRequests", "PetSitter_SitterId");
            AddForeignKey("dbo.ServiceRequests", "PetSitter_SitterId", "dbo.PetSitters", "SitterId");
        }
    }
}
