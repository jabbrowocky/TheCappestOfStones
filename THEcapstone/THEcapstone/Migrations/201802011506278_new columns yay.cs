namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnsyay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "SenderName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "SenderName");
        }
    }
}
