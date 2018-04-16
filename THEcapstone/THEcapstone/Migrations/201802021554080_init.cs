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
                "dbo.SitterClientJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Client_CustId = c.Int(),
                        Sitter_SitterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Client_CustId)
                .ForeignKey("dbo.PetSitters", t => t.Sitter_SitterId)
                .Index(t => t.Client_CustId)
                .Index(t => t.Sitter_SitterId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustFirstName = c.String(),
                        CustLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        IsSubscribed = c.Boolean(nullable: false),
                        HasWalker = c.Boolean(nullable: false),
                        HasSitter = c.Boolean(nullable: false),
                        PetSitter_SitterId = c.Int(),
                        DogWalker_WalkerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.PetSitters", t => t.PetSitter_SitterId)
                .ForeignKey("dbo.DogWalkers", t => t.DogWalker_WalkerId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId)
                .Index(t => t.PetSitter_SitterId)
                .Index(t => t.DogWalker_WalkerId);
            
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
                        PetSitter_SitterId = c.Int(),
                        DogWalker_WalkerId = c.Int(),
                        Veterinarian_VetId = c.Int(),
                    })
                .PrimaryKey(t => t.MsgId)
                .ForeignKey("dbo.AspNetUsers", t => t.TargetId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustId)
                .ForeignKey("dbo.PetSitters", t => t.PetSitter_SitterId)
                .ForeignKey("dbo.DogWalkers", t => t.DogWalker_WalkerId)
                .ForeignKey("dbo.Veterinarians", t => t.Veterinarian_VetId)
                .Index(t => t.TargetId)
                .Index(t => t.Customer_CustId)
                .Index(t => t.PetSitter_SitterId)
                .Index(t => t.DogWalker_WalkerId)
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
                "dbo.PetSitters",
                c => new
                    {
                        SitterId = c.Int(nullable: false, identity: true),
                        SitterFirstName = c.String(),
                        SitterLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ProfileId = c.Int(),
                        FeedbackRating = c.Int(nullable: false),
                        FeedbackCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SitterId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.PetSitterProfiles", t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.PetSitterProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SitterFirstName = c.String(),
                        SitterLastName = c.String(),
                        CityName = c.String(),
                        BriefDescription = c.String(),
                        ExperienceDescription = c.String(),
                        RatePerHour = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientWalkerJunctions",
                c => new
                    {
                        WalkerId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Client_CustId = c.Int(),
                        Walker_WalkerId = c.Int(),
                    })
                .PrimaryKey(t => t.WalkerId)
                .ForeignKey("dbo.Customers", t => t.Client_CustId)
                .ForeignKey("dbo.DogWalkers", t => t.Walker_WalkerId)
                .Index(t => t.Client_CustId)
                .Index(t => t.Walker_WalkerId);
            
            CreateTable(
                "dbo.DogWalkers",
                c => new
                    {
                        WalkerId = c.Int(nullable: false, identity: true),
                        WalkerFirstName = c.String(),
                        WalkerLastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ProfileId = c.Int(),
                        FeedbackRating = c.Int(nullable: false),
                        FeedbackCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WalkerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.WalkerProfiles", t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.WalkerProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WalkerFirstName = c.String(),
                        WalkerLastName = c.String(),
                        UserDiscription = c.String(),
                        DogTypePreference = c.String(),
                        CityName = c.String(),
                        RatePerHour = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.ServiceRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SenderName = c.String(),
                        CustomerId = c.Int(nullable: false),
                        RequestStatus = c.String(),
                        Customer_CustId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Customer_CustId);
            
            CreateTable(
                "dbo.Veterinarians",
                c => new
                    {
                        VetId = c.Int(nullable: false, identity: true),
                        VetName = c.String(),
                        AddressId = c.Int(nullable: false),
                        ProfileId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        FeedbackRating = c.Int(nullable: false),
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
                        DiscountToDisplay = c.String(nullable: false),
                        MapAddressCity = c.String(nullable: false),
                        ShowMap = c.Boolean(nullable: false),
                        MapAddressStreet = c.String(),
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
            DropForeignKey("dbo.ServiceRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ServiceRequests", "Customer_CustId", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ClientWalkerJunctions", "Walker_WalkerId", "dbo.DogWalkers");
            DropForeignKey("dbo.DogWalkers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DogWalkers", "ProfileId", "dbo.WalkerProfiles");
            DropForeignKey("dbo.Messages", "DogWalker_WalkerId", "dbo.DogWalkers");
            DropForeignKey("dbo.Customers", "DogWalker_WalkerId", "dbo.DogWalkers");
            DropForeignKey("dbo.DogWalkers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ClientWalkerJunctions", "Client_CustId", "dbo.Customers");
            DropForeignKey("dbo.SitterClientJunctions", "Sitter_SitterId", "dbo.PetSitters");
            DropForeignKey("dbo.PetSitters", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PetSitters", "ProfileId", "dbo.PetSitterProfiles");
            DropForeignKey("dbo.Messages", "PetSitter_SitterId", "dbo.PetSitters");
            DropForeignKey("dbo.Customers", "PetSitter_SitterId", "dbo.PetSitters");
            DropForeignKey("dbo.PetSitters", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.SitterClientJunctions", "Client_CustId", "dbo.Customers");
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
            DropIndex("dbo.ServiceRequests", new[] { "Customer_CustId" });
            DropIndex("dbo.ServiceRequests", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DogWalkers", new[] { "ProfileId" });
            DropIndex("dbo.DogWalkers", new[] { "UserId" });
            DropIndex("dbo.DogWalkers", new[] { "AddressId" });
            DropIndex("dbo.ClientWalkerJunctions", new[] { "Walker_WalkerId" });
            DropIndex("dbo.ClientWalkerJunctions", new[] { "Client_CustId" });
            DropIndex("dbo.PetSitters", new[] { "ProfileId" });
            DropIndex("dbo.PetSitters", new[] { "UserId" });
            DropIndex("dbo.PetSitters", new[] { "AddressId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Messages", new[] { "Veterinarian_VetId" });
            DropIndex("dbo.Messages", new[] { "DogWalker_WalkerId" });
            DropIndex("dbo.Messages", new[] { "PetSitter_SitterId" });
            DropIndex("dbo.Messages", new[] { "Customer_CustId" });
            DropIndex("dbo.Messages", new[] { "TargetId" });
            DropIndex("dbo.Customers", new[] { "DogWalker_WalkerId" });
            DropIndex("dbo.Customers", new[] { "PetSitter_SitterId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.SitterClientJunctions", new[] { "Sitter_SitterId" });
            DropIndex("dbo.SitterClientJunctions", new[] { "Client_CustId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropTable("dbo.VetProfiles");
            DropTable("dbo.Veterinarians");
            DropTable("dbo.ServiceRequests");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.WalkerProfiles");
            DropTable("dbo.DogWalkers");
            DropTable("dbo.ClientWalkerJunctions");
            DropTable("dbo.PetSitterProfiles");
            DropTable("dbo.PetSitters");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Customers");
            DropTable("dbo.SitterClientJunctions");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
        }
    }
}
