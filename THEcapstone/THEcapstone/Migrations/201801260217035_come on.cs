namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comeon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VetProfiles", "MapAddressStreet", c => c.String());
            AddColumn("dbo.VetProfiles", "MapAddressCity", c => c.String());
            AddColumn("dbo.VetProfiles", "MapAddressState", c => c.String());
            DropColumn("dbo.VetProfiles", "MapAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VetProfiles", "MapAddress", c => c.String());
            DropColumn("dbo.VetProfiles", "MapAddressState");
            DropColumn("dbo.VetProfiles", "MapAddressCity");
            DropColumn("dbo.VetProfiles", "MapAddressStreet");
        }
    }
}
