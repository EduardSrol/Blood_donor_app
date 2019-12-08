namespace BloodDonorApp.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Roles", c => c.String());
            AddColumn("dbo.CommonUsers", "Roles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommonUsers", "Roles");
            DropColumn("dbo.Admins", "Roles");
        }
    }
}
