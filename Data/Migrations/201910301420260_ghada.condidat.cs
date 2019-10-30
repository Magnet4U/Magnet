namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadacondidat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condidat",
                c => new
                    {
                        idUser = c.Int(nullable: false),
                        Condidat_firstname = c.String(),
                        Condidat_lastname = c.String(),
                        cin = c.Int(nullable: false),
                        telephone = c.Int(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Condidat", "idUser", "dbo.Users");
            DropIndex("dbo.Condidat", new[] { "idUser" });
            DropTable("dbo.Condidat");
        }
    }
}
