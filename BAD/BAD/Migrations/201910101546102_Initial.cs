namespace BAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        UserType = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 20),
                        Updated = c.DateTime(),
                        UpdatedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BloodDonations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DonorId = c.Guid(),
                        ApplicantId = c.Guid(),
                        SampleStationId = c.Guid(),
                        SampleVolume = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Updated = c.DateTime(),
                        UpdatedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommonUsers", t => t.ApplicantId)
                .ForeignKey("dbo.CommonUsers", t => t.DonorId)
                .ForeignKey("dbo.SampleStations", t => t.SampleStationId)
                .Index(t => t.DonorId)
                .Index(t => t.ApplicantId)
                .Index(t => t.SampleStationId);
            
            CreateTable(
                "dbo.CommonUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrefixBN = c.String(),
                        SufixBN = c.String(),
                        BloodType = c.Int(nullable: false),
                        HospitalId = c.Guid(),
                        Approved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        UUN = c.Int(nullable: false),
                        UserName = c.String(),
                        UserType = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 20),
                        Updated = c.DateTime(),
                        UpdatedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        Name = c.String(),
                        Updated = c.DateTime(),
                        UpdatedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SampleStations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WebLink = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Name = c.String(),
                        Updated = c.DateTime(),
                        UpdatedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BloodDonations", "SampleStationId", "dbo.SampleStations");
            DropForeignKey("dbo.BloodDonations", "DonorId", "dbo.CommonUsers");
            DropForeignKey("dbo.BloodDonations", "ApplicantId", "dbo.CommonUsers");
            DropForeignKey("dbo.CommonUsers", "HospitalId", "dbo.Hospitals");
            DropIndex("dbo.CommonUsers", new[] { "HospitalId" });
            DropIndex("dbo.BloodDonations", new[] { "SampleStationId" });
            DropIndex("dbo.BloodDonations", new[] { "ApplicantId" });
            DropIndex("dbo.BloodDonations", new[] { "DonorId" });
            DropTable("dbo.SampleStations");
            DropTable("dbo.Hospitals");
            DropTable("dbo.CommonUsers");
            DropTable("dbo.BloodDonations");
            DropTable("dbo.Admins");
        }
    }
}
