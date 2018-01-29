namespace THEcapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustFirstName = c.String(),
                        CustLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MsgId = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(),
                        TargetId = c.String(maxLength: 128),
                        MsgText = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        Opened = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Customer_CustId = c.Int(),
                        Veterinarian_VetId = c.Int(),
                    })
                .PrimaryKey(t => t.MsgId)
                .ForeignKey("dbo.AspNetUsers", t => t.TargetId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustId)
                .ForeignKey("dbo.Veterinarians", t => t.Veterinarian_VetId)
                .Index(t => t.TargetId)
                .Index(t => t.Customer_CustId)
                .Index(t => t.Veterinarian_VetId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RoleToAdd = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DogWalkers",
                c => new
                    {
                        WalkerId = c.Int(nullable: false, identity: true),
                        WalkerFirstName = c.String(),
                        WalkerLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.WalkerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PetSitters",
                c => new
                    {
                        SitterId = c.Int(nullable: false, identity: true),
                        SitterFirstName = c.String(),
                        SitterLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SitterId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Veterinarians",
                c => new
                    {
                        VetId = c.Int(nullable: false, identity: true),
                        VetName = c.String(),
                        AddressId = c.Int(nullable: false),
                        ProfileId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VetId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.VetProfiles", t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.ProfileId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VetProfiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserDescription = c.String(nullable: false),
                        ServicesDescription = c.String(),
                        StaffDescription = c.String(),
                        ShowMap = c.Boolean(nullable: false),
                        MapAddressStreet = c.String(),
                        MapAddressCity = c.String(),
                        MapAddressState = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veterinarians", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Veterinarians", "ProfileId", "dbo.VetProfiles");
            DropForeignKey("dbo.Messages", "Veterinarian_VetId", "dbo.Veterinarians");
            DropForeignKey("dbo.Veterinarians", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PetSitters", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.DogWalkers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DogWalkers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Customer_CustId", "dbo.Customers");
            DropForeignKey("dbo.Messages", "TargetId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.Veterinarians", new[] { "UserId" });
            DropIndex("dbo.Veterinarians", new[] { "ProfileId" });
            DropIndex("dbo.Veterinarians", new[] { "AddressId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PetSitters", new[] { "AddressId" });
            DropIndex("dbo.DogWalkers", new[] { "UserId" });
            DropIndex("dbo.DogWalkers", new[] { "AddressId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Messages", new[] { "Veterinarian_VetId" });
            DropIndex("dbo.Messages", new[] { "Customer_CustId" });
            DropIndex("dbo.Messages", new[] { "TargetId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropTable("dbo.VetProfiles");
            DropTable("dbo.Veterinarians");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PetSitters");
            DropTable("dbo.DogWalkers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Customers");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
        }
    }
}
