namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazUpdateInterview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interviews", "idUSer_idUser", "dbo.Users");
            DropIndex("dbo.Interviews", new[] { "idUSer_idUser" });
            AddColumn("dbo.Interviews", "Candidat_idUser", c => c.Int());
            AddColumn("dbo.Interviews", "idCandidat_idUser", c => c.Int());
            AddColumn("dbo.Interviews", "Condidat_idUser", c => c.Int());
            CreateIndex("dbo.Interviews", "Candidat_idUser");
            CreateIndex("dbo.Interviews", "idCandidat_idUser");
            CreateIndex("dbo.Interviews", "Condidat_idUser");
            AddForeignKey("dbo.Interviews", "Candidat_idUser", "dbo.Condidat", "idUser");
            AddForeignKey("dbo.Interviews", "idCandidat_idUser", "dbo.Condidat", "idUser");
            AddForeignKey("dbo.Interviews", "Condidat_idUser", "dbo.Condidat", "idUser");
            DropColumn("dbo.Interviews", "idUSer_idUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interviews", "idUSer_idUser", c => c.Int());
            DropForeignKey("dbo.Interviews", "Condidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Interviews", "idCandidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Interviews", "Candidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Interviews", new[] { "Condidat_idUser" });
            DropIndex("dbo.Interviews", new[] { "idCandidat_idUser" });
            DropIndex("dbo.Interviews", new[] { "Candidat_idUser" });
            DropColumn("dbo.Interviews", "Condidat_idUser");
            DropColumn("dbo.Interviews", "idCandidat_idUser");
            DropColumn("dbo.Interviews", "Candidat_idUser");
            CreateIndex("dbo.Interviews", "idUSer_idUser");
            AddForeignKey("dbo.Interviews", "idUSer_idUser", "dbo.Users", "idUser");
        }
    }
}
