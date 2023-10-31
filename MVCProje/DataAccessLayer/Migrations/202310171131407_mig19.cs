namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminImage", c => c.String());
            AlterColumn("dbo.Writers", "WriterImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 500));
            AlterColumn("dbo.Admins", "AdminImage", c => c.String(maxLength: 500));
        }
    }
}
