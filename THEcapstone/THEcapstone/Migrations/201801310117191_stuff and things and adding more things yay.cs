namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffandthingsandaddingmorethingsyay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "PetSitter_SitterId", c => c.Int());
            AddColumn("dbo.WalkerProfiles", "CityName", c => c.String());
            CreateIndex("dbo.Messages", "PetSitter_SitterId");
            AddForeignKey("dbo.Messages", "PetSitter_SitterId", "dbo.PetSitters", "SitterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "PetSitter_SitterId", "dbo.PetSitters");
            DropIndex("dbo.Messages", new[] { "PetSitter_SitterId" });
            DropColumn("dbo.WalkerProfiles", "CityName");
            DropColumn("dbo.Messages", "PetSitter_SitterId");
        }
    }
}
