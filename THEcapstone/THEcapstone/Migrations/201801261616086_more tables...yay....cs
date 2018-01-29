namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moretablesyay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DogWalkers",
                c => new
                    {
                        WalkerId = c.Int(nullable: false, identity: true),
                        WalkerFirstName = c.String(),
                        WalkerLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WalkerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.PetSitters",
                c => new
                    {
                        SitterId = c.Int(nullable: false, identity: true),
                        SitterFirstName = c.String(),
                        SitterLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SitterId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetSitters", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.DogWalkers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PetSitters", new[] { "AddressId" });
            DropIndex("dbo.DogWalkers", new[] { "AddressId" });
            DropTable("dbo.PetSitters");
            DropTable("dbo.DogWalkers");
        }
    }
}
