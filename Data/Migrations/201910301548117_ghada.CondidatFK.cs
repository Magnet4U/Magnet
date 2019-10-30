namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadaCondidatFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Certifications", name: "Condidat_idUser", newName: "MyCondidat_idUser");
            RenameIndex(table: "dbo.Certifications", name: "IX_Condidat_idUser", newName: "IX_MyCondidat_idUser");
            AddColumn("dbo.Certifications", "MyCondidatId", c => c.Int(nullable: false));
            AddColumn("dbo.Competences", "MyCondidatId", c => c.Int(nullable: false));
            AddColumn("dbo.Competences", "MyCondidat_idUser", c => c.Int());
            AddColumn("dbo.Diplomata", "MyCondidatId", c => c.Int(nullable: false));
            AddColumn("dbo.Diplomata", "MyCondidat_idUser", c => c.Int());
            CreateIndex("dbo.Competences", "MyCondidat_idUser");
            CreateIndex("dbo.Diplomata", "MyCondidat_idUser");
            AddForeignKey("dbo.Competences", "MyCondidat_idUser", "dbo.Condidat", "idUser");
            AddForeignKey("dbo.Diplomata", "MyCondidat_idUser", "dbo.Condidat", "idUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diplomata", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Competences", "MyCondidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Diplomata", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Competences", new[] { "MyCondidat_idUser" });
            DropColumn("dbo.Diplomata", "MyCondidat_idUser");
            DropColumn("dbo.Diplomata", "MyCondidatId");
            DropColumn("dbo.Competences", "MyCondidat_idUser");
            DropColumn("dbo.Competences", "MyCondidatId");
            DropColumn("dbo.Certifications", "MyCondidatId");
            RenameIndex(table: "dbo.Certifications", name: "IX_MyCondidat_idUser", newName: "IX_Condidat_idUser");
            RenameColumn(table: "dbo.Certifications", name: "MyCondidat_idUser", newName: "Condidat_idUser");
        }
    }
}
