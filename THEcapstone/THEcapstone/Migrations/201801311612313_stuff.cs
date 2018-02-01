namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VetProfiles", "DiscountToDisplay", c => c.String(nullable: false));
            AlterColumn("dbo.VetProfiles", "MapAddressCity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VetProfiles", "MapAddressCity", c => c.String());
            DropColumn("dbo.VetProfiles", "DiscountToDisplay");
        }
    }
}
