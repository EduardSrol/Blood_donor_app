namespace BAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserType = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 20),
                        Updated = c.DateTime(nullable: false),
                        UpdatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BloodDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SampleVolume = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedById = c.Int(nullable: false),
                        Applicant_Id = c.Int(),
                        Donor_Id = c.Int(),
                        SampleStation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommonUsers", t => t.Applicant_Id)
                .ForeignKey("dbo.CommonUsers", t => t.Donor_Id)
                .ForeignKey("dbo.SampleStations", t => t.SampleStation_Id)
                .Index(t => t.Applicant_Id)
                .Index(t => t.Donor_Id)
                .Index(t => t.SampleStation_Id);
            
            CreateTable(
                "dbo.CommonUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        prefixBN = c.String(),
                        sufixBN = c.String(),
                        UserName = c.String(maxLength: 100),
                        BloodType = c.Int(nullable: false),
                        UserType = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        UUN = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 20),
                        Updated = c.DateTime(nullable: false),
                        UpdatedById = c.Int(nullable: false),
                        Hospital_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .Index(t => t.Hospital_Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        Name = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SampleStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WebLink = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Name = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BloodDonations", "SampleStation_Id", "dbo.SampleStations");
            DropForeignKey("dbo.BloodDonations", "Donor_Id", "dbo.CommonUsers");
            DropForeignKey("dbo.BloodDonations", "Applicant_Id", "dbo.CommonUsers");
            DropForeignKey("dbo.CommonUsers", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.CommonUsers", new[] { "Hospital_Id" });
            DropIndex("dbo.BloodDonations", new[] { "SampleStation_Id" });
            DropIndex("dbo.BloodDonations", new[] { "Donor_Id" });
            DropIndex("dbo.BloodDonations", new[] { "Applicant_Id" });
            DropTable("dbo.SampleStations");
            DropTable("dbo.Hospitals");
            DropTable("dbo.CommonUsers");
            DropTable("dbo.BloodDonations");
            DropTable("dbo.Admins");
        }
    }
}
