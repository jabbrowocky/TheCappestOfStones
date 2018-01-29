namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class perturbedcurrently : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "AuthorId", c => c.Int(nullable: false));
        }
    }
}
