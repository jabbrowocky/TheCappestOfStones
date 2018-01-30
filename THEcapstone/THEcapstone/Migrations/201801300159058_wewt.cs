namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wewt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DogWalker_WalkerId", c => c.Int());
            CreateIndex("dbo.Messages", "DogWalker_WalkerId");
            AddForeignKey("dbo.Messages", "DogWalker_WalkerId", "dbo.DogWalkers", "WalkerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "DogWalker_WalkerId", "dbo.DogWalkers");
            DropIndex("dbo.Messages", new[] { "DogWalker_WalkerId" });
            DropColumn("dbo.Messages", "DogWalker_WalkerId");
        }
    }
}
