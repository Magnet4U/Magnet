namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadadiploma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diplomata",
                c => new
                    {
                        idD = c.Int(nullable: false, identity: true),
                        ObtentionDate = c.DateTime(nullable: false),
                        DegreeTitle = c.String(),
                    })
                .PrimaryKey(t => t.idD);
            
            DropTable("dbo.Langues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Langues",
                c => new
                    {
                        idL = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        level = c.String(),
                    })
                .PrimaryKey(t => t.idL);
            
            DropTable("dbo.Diplomata");
        }
    }
}
