namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumntorequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "RequestStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "RequestStatus");
        }
    }
}
