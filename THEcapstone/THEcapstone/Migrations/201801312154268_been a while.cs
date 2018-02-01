namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beenawhile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Veterinarian_VetId", c => c.Int());
            CreateIndex("dbo.Customers", "Veterinarian_VetId");
            AddForeignKey("dbo.Customers", "Veterinarian_VetId", "dbo.Veterinarians", "VetId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Veterinarian_VetId", "dbo.Veterinarians");
            DropIndex("dbo.Customers", new[] { "Veterinarian_VetId" });
            DropColumn("dbo.Customers", "Veterinarian_VetId");
        }
    }
}
