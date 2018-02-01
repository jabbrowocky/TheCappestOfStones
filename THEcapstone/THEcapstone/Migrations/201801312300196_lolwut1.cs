namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolwut1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "PetSitter_SitterId", c => c.Int());
            CreateIndex("dbo.ServiceRequests", "PetSitter_SitterId");
            AddForeignKey("dbo.ServiceRequests", "PetSitter_SitterId", "dbo.PetSitters", "SitterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRequests", "PetSitter_SitterId", "dbo.PetSitters");
            DropIndex("dbo.ServiceRequests", new[] { "PetSitter_SitterId" });
            DropColumn("dbo.ServiceRequests", "PetSitter_SitterId");
        }
    }
}
