namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DogWalker_WalkerId", c => c.Int());
            CreateIndex("dbo.Customers", "DogWalker_WalkerId");
            AddForeignKey("dbo.Customers", "DogWalker_WalkerId", "dbo.DogWalkers", "WalkerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "DogWalker_WalkerId", "dbo.DogWalkers");
            DropIndex("dbo.Customers", new[] { "DogWalker_WalkerId" });
            DropColumn("dbo.Customers", "DogWalker_WalkerId");
        }
    }
}
