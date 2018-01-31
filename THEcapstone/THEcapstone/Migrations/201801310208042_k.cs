namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribed", c => c.Boolean(nullable: false));
            AddColumn("dbo.PetSitters", "ProfileId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PetSitters", "ProfileId");
            DropColumn("dbo.Customers", "IsSubscribed");
        }
    }
}
