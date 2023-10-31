namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminImage", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminImage");
        }
    }
}
