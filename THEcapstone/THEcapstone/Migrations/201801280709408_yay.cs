namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yay : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "Sender_Id", newName: "TargetId");
            RenameIndex(table: "dbo.Messages", name: "IX_Sender_Id", newName: "IX_TargetId");
            AddColumn("dbo.Messages", "AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "SendToId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SendToId", c => c.String());
            DropColumn("dbo.Messages", "AuthorId");
            RenameIndex(table: "dbo.Messages", name: "IX_TargetId", newName: "IX_Sender_Id");
            RenameColumn(table: "dbo.Messages", name: "TargetId", newName: "Sender_Id");
        }
    }
}
