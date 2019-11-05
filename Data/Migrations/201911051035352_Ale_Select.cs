namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ale_Select : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOffers", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropIndex("dbo.JobOffers", new[] { "idEntreprise_idEntreprise" });
            DropColumn("dbo.JobOffers", "MyidEntreprise");
            RenameColumn(table: "dbo.JobOffers", name: "idEntreprise_idEntreprise", newName: "MyidEntreprise");
            RenameColumn(table: "dbo.Users", name: "idEntreprise", newName: "MyidEntreprise");
            RenameIndex(table: "dbo.Users", name: "IX_idEntreprise", newName: "IX_MyidEntreprise");
            AlterColumn("dbo.JobOffers", "MyidEntreprise", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOffers", "MyidEntreprise");
            AddForeignKey("dbo.JobOffers", "MyidEntreprise", "dbo.Entreprises", "idEntreprise", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "MyidEntreprise", "dbo.Entreprises");
            DropIndex("dbo.JobOffers", new[] { "MyidEntreprise" });
            AlterColumn("dbo.JobOffers", "MyidEntreprise", c => c.Int());
            RenameIndex(table: "dbo.Users", name: "IX_MyidEntreprise", newName: "IX_idEntreprise");
            RenameColumn(table: "dbo.Users", name: "MyidEntreprise", newName: "idEntreprise");
            RenameColumn(table: "dbo.JobOffers", name: "MyidEntreprise", newName: "idEntreprise_idEntreprise");
            AddColumn("dbo.JobOffers", "MyidEntreprise", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOffers", "idEntreprise_idEntreprise");
            AddForeignKey("dbo.JobOffers", "idEntreprise_idEntreprise", "dbo.Entreprises", "idEntreprise");
        }
    }
}
