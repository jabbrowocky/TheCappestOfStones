namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GODFUCKINGDAMNIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientWalkerJunctions",
                c => new
                    {
                        WalkerId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Client_CustId = c.Int(),
                        Walker_WalkerId = c.Int(),
                    })
                .PrimaryKey(t => t.WalkerId)
                .ForeignKey("dbo.Customers", t => t.Client_CustId)
                .ForeignKey("dbo.DogWalkers", t => t.Walker_WalkerId)
                .Index(t => t.Client_CustId)
                .Index(t => t.Walker_WalkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientWalkerJunctions", "Walker_WalkerId", "dbo.DogWalkers");
            DropForeignKey("dbo.ClientWalkerJunctions", "Client_CustId", "dbo.Customers");
            DropIndex("dbo.ClientWalkerJunctions", new[] { "Walker_WalkerId" });
            DropIndex("dbo.ClientWalkerJunctions", new[] { "Client_CustId" });
            DropTable("dbo.ClientWalkerJunctions");
        }
    }
}
