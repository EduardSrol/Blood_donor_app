namespace BloodDonorApp.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesUpdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Roles");
            DropColumn("dbo.CommonUsers", "Roles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommonUsers", "Roles", c => c.String());
            AddColumn("dbo.Admins", "Roles", c => c.String());
        }
    }
}
