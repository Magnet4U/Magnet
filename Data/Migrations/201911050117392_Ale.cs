namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropIndex("dbo.Users", new[] { "idEntreprise_idEntreprise" });
            RenameColumn(table: "dbo.Users", name: "idEntreprise_idEntreprise", newName: "idEntreprise");
            AlterColumn("dbo.Users", "idEntreprise", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "idEntreprise");
            AddForeignKey("dbo.Users", "idEntreprise", "dbo.Entreprises", "idEntreprise", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "idEntreprise", "dbo.Entreprises");
            DropIndex("dbo.Users", new[] { "idEntreprise" });
            AlterColumn("dbo.Users", "idEntreprise", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "idEntreprise", newName: "idEntreprise_idEntreprise");
            CreateIndex("dbo.Users", "idEntreprise_idEntreprise");
            AddForeignKey("dbo.Users", "idEntreprise_idEntreprise", "dbo.Entreprises", "idEntreprise");
        }
    }
}
