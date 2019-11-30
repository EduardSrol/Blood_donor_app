namespace BloodDonorApp.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordHashAndSalt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "PasswordSalt", c => c.String(maxLength: 100));
            AlterColumn("dbo.Admins", "PasswordHash", c => c.String(maxLength: 100));
            AlterColumn("dbo.CommonUsers", "PasswordSalt", c => c.String(maxLength: 100));
            AlterColumn("dbo.CommonUsers", "PasswordHash", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommonUsers", "PasswordHash", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CommonUsers", "PasswordSalt", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Admins", "PasswordHash", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Admins", "PasswordSalt", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
