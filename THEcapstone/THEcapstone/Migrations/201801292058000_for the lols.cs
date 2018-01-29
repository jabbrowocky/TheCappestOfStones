namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forthelols : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WalkerProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WalkerFirstName = c.String(),
                        WalkerLastName = c.String(),
                        UserDiscription = c.String(),
                        DogTypePreference = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WalkerProfiles");
        }
    }
}
