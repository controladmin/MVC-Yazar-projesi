namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig24 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Headings", "HeadingUpdateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingUpdateDate", c => c.DateTime());
        }
    }
}
