namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesajs",
                c => new
                    {
                        MesajId = c.Int(nullable: false, identity: true),
                        GondericiMail = c.String(maxLength: 50),
                        AliciMail = c.String(maxLength: 50),
                        Konu = c.String(maxLength: 100),
                        MesajKonusu = c.String(maxLength: 1000),
                        MesajTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MesajId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mesajs");
        }
    }
}
