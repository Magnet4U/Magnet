namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadaFKcareerconfig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Careers", "MyCondidatId", c => c.Int(nullable: false));
            AddColumn("dbo.Certifications", "Condidat_idUser", c => c.Int());
            CreateIndex("dbo.Certifications", "Condidat_idUser");
            AddForeignKey("dbo.Certifications", "Condidat_idUser", "dbo.Condidat", "idUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certifications", "Condidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Certifications", new[] { "Condidat_idUser" });
            DropColumn("dbo.Certifications", "Condidat_idUser");
            DropColumn("dbo.Careers", "MyCondidatId");
        }
    }
}
