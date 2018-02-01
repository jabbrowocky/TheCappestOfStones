namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undided : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Veterinarian_VetId", "dbo.Veterinarians");
            DropIndex("dbo.Customers", new[] { "Veterinarian_VetId" });
            DropColumn("dbo.Customers", "Veterinarian_VetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Veterinarian_VetId", c => c.Int());
            CreateIndex("dbo.Customers", "Veterinarian_VetId");
            AddForeignKey("dbo.Customers", "Veterinarian_VetId", "dbo.Veterinarians", "VetId");
        }
    }
}
