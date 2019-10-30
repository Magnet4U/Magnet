namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadacareer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        idCAR = c.Int(nullable: false, identity: true),
                        Career_title = c.String(),
                        Carrer_description = c.String(),
                        Start_date = c.DateTime(),
                        End_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.idCAR);
            
            DropTable("dbo.ExperienceProes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExperienceProes",
                c => new
                    {
                        idEP = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEP);
            
            DropTable("dbo.Careers");
        }
    }
}
