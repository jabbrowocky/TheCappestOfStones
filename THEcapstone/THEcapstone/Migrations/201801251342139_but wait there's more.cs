namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class butwaittheresmore : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Profiles", newName: "VetProfiles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.VetProfiles", newName: "Profiles");
        }
    }
}
