namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolwut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Id_Id", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "Id_Id" });
            DropColumn("dbo.Addresses", "StateId");
            RenameColumn(table: "dbo.Addresses", name: "Id_Id", newName: "StateId");
            AlterColumn("dbo.Addresses", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "StateId");
            AddForeignKey("dbo.Addresses", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateId" });
            AlterColumn("dbo.Addresses", "StateId", c => c.Int());
            RenameColumn(table: "dbo.Addresses", name: "StateId", newName: "Id_Id");
            AddColumn("dbo.Addresses", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "Id_Id");
            AddForeignKey("dbo.Addresses", "Id_Id", "dbo.States", "Id");
        }
    }
}
