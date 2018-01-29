namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedratingcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DogWalkers", "FeedbackRating", c => c.String());
            AddColumn("dbo.PetSitters", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.PetSitters", "FeedbackRating", c => c.Int(nullable: false));
            AddColumn("dbo.Veterinarians", "FeedbackRating", c => c.Int(nullable: false));
            CreateIndex("dbo.PetSitters", "UserId");
            AddForeignKey("dbo.PetSitters", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetSitters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PetSitters", new[] { "UserId" });
            DropColumn("dbo.Veterinarians", "FeedbackRating");
            DropColumn("dbo.PetSitters", "FeedbackRating");
            DropColumn("dbo.PetSitters", "UserId");
            DropColumn("dbo.DogWalkers", "FeedbackRating");
        }
    }
}
