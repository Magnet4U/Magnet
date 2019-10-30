namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadacertification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        idC = c.Int(nullable: false, identity: true),
                        ObtentionDateC = c.DateTime(),
                        DateC = c.DateTime(),
                    })
                .PrimaryKey(t => t.idC);
            
            DropTable("dbo.LicenseCertifs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LicenseCertifs",
                c => new
                    {
                        idLC = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLC);
            
            DropTable("dbo.Certifications");
        }
    }
}
