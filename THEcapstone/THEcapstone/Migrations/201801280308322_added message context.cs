namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmessagecontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MsgId = c.Int(nullable: false, identity: true),
                        MsgText = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Veterinarian_VetId = c.Int(),
                    })
                .PrimaryKey(t => t.MsgId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Veterinarians", t => t.Veterinarian_VetId)
                .Index(t => t.UserId)
                .Index(t => t.Veterinarian_VetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Veterinarian_VetId", "dbo.Veterinarians");
            DropForeignKey("dbo.Messages", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Veterinarian_VetId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropTable("dbo.Messages");
        }
    }
}
