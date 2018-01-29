namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolfixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DogWalkers", "ProfileId", c => c.Int());
            CreateIndex("dbo.DogWalkers", "ProfileId");
            AddForeignKey("dbo.DogWalkers", "ProfileId", "dbo.WalkerProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DogWalkers", "ProfileId", "dbo.WalkerProfiles");
            DropIndex("dbo.DogWalkers", new[] { "ProfileId" });
            AlterColumn("dbo.DogWalkers", "ProfileId", c => c.Int(nullable: false));
        }
    }
}
