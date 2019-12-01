namespace BloodDonorApp.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordHashAndSalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.String(maxLength: 100));
            AddColumn("dbo.Admins", "PasswordHash", c => c.String(maxLength: 100));
            AddColumn("dbo.CommonUsers", "PasswordSalt", c => c.String(maxLength: 100));
            AddColumn("dbo.CommonUsers", "PasswordHash", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommonUsers", "PasswordHash");
            DropColumn("dbo.CommonUsers", "PasswordSalt");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
        }
    }
}
