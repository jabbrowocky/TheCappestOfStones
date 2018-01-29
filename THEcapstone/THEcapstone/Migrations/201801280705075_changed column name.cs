namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcolumnname : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "Sender_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_UserId", newName: "IX_Sender_Id");
            AddColumn("dbo.Messages", "SendToId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "SendToId");
            RenameIndex(table: "dbo.Messages", name: "IX_Sender_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Messages", name: "Sender_Id", newName: "UserId");
        }
    }
}
