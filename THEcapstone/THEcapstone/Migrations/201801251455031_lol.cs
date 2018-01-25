namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VetProfiles", "UserDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VetProfiles", "UserDescription", c => c.String());
        }
    }
}
