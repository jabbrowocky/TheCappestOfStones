namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dostuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                        Customer_CustId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Customer_CustId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ServiceRequests", "Customer_CustId", "dbo.Customers");
            DropIndex("dbo.ServiceRequests", new[] { "Customer_CustId" });
            DropIndex("dbo.ServiceRequests", new[] { "UserId" });
            DropTable("dbo.ServiceRequests");
        }
    }
}
