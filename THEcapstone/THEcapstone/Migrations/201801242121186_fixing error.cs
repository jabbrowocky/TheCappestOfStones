namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingerror : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ProfileType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "ProfileType");
        }
    }
}
