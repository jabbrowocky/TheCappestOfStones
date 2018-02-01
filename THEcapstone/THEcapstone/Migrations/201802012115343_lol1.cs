namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lol1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SitterClientJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Client_CustId = c.Int(),
                        Sitter_SitterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Client_CustId)
                .ForeignKey("dbo.PetSitters", t => t.Sitter_SitterId)
                .Index(t => t.Client_CustId)
                .Index(t => t.Sitter_SitterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SitterClientJunctions", "Sitter_SitterId", "dbo.PetSitters");
            DropForeignKey("dbo.SitterClientJunctions", "Client_CustId", "dbo.Customers");
            DropIndex("dbo.SitterClientJunctions", new[] { "Sitter_SitterId" });
            DropIndex("dbo.SitterClientJunctions", new[] { "Client_CustId" });
            DropTable("dbo.SitterClientJunctions");
        }
    }
}
