namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasework : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "AuthorId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "AuthorId");
        }
    }
}
