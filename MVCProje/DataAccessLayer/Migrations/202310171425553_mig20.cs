namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headings", "HeadingUpdateDate", c => c.DateTime());
            AlterColumn("dbo.Contents", "ContentDate", c => c.DateTime());
            AlterColumn("dbo.Contacts", "ContactDate", c => c.DateTime());
            AlterColumn("dbo.Mesajs", "MesajTarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mesajs", "MesajTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contents", "ContentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Headings", "HeadingUpdateDate", c => c.DateTime(nullable: false));
        }
    }
}
