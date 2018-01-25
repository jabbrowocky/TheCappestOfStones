namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedyetanotherfieldtovetprofilemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VetProfiles", "ShowMap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VetProfiles", "ShowMap");
        }
    }
}
