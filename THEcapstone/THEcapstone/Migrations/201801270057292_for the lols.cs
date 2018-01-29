namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forthelols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DogWalkers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.DogWalkers", "UserId");
            AddForeignKey("dbo.DogWalkers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DogWalkers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DogWalkers", new[] { "UserId" });
            DropColumn("dbo.DogWalkers", "UserId");
        }
    }
}
