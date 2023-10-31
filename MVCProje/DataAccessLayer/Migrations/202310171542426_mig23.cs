namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutImage", c => c.String());
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Abouts", "AboutImage1");
            DropColumn("dbo.Abouts", "AboutImage2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImage2", c => c.String());
            AddColumn("dbo.Abouts", "AboutImage1", c => c.String());
            DropColumn("dbo.Abouts", "Status");
            DropColumn("dbo.Abouts", "AboutImage");
        }
    }
}
