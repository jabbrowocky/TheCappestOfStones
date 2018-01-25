
namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedproptoprofilemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "MapAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "MapAddress");
        }
    }
}
