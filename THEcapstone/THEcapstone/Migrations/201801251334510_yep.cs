namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ServicesDescription", c => c.String());
            AddColumn("dbo.Profiles", "StaffDescription", c => c.String());
            DropColumn("dbo.Profiles", "ProfileType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "ProfileType", c => c.String());
            DropColumn("dbo.Profiles", "StaffDescription");
            DropColumn("dbo.Profiles", "ServicesDescription");
        }
    }
}
