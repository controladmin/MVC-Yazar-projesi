namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headings", "HeadingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Headings", "HeadingDate", c => c.DateTime(nullable: false));
        }
    }
}
