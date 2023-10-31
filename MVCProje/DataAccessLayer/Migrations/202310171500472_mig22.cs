namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 200));
        }
    }
}
