namespace BloodDonorApp.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpeningHoursAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hospitals", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Hospitals", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Hospitals", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SampleStations", "City", c => c.String(nullable: false));
            AlterColumn("dbo.SampleStations", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.SampleStations", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SampleStations", "Name", c => c.String());
            AlterColumn("dbo.SampleStations", "Street", c => c.String());
            AlterColumn("dbo.SampleStations", "City", c => c.String());
            AlterColumn("dbo.Hospitals", "Name", c => c.String());
            AlterColumn("dbo.Hospitals", "Street", c => c.String());
            AlterColumn("dbo.Hospitals", "City", c => c.String());
        }
    }
}
