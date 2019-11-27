namespace BloodDonorApp.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeletedCommonUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommonUsers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommonUsers", "IsDeleted");
        }
    }
}
