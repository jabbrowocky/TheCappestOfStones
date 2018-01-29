namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lol1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Opened", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Deleted");
            DropColumn("dbo.Messages", "Opened");
        }
    }
}
