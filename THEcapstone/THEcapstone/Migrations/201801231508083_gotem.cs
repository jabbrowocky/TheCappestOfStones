namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gotem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustFirstName = c.String(),
                        CustLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(),
                        Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Id_Id)
                .Index(t => t.AddressId)
                .Index(t => t.Id_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Id_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "Id_Id" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropTable("dbo.Customers");
        }
    }
}
