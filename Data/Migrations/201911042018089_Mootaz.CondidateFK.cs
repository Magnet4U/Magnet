namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazCondidateFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interviews", "Condidat_idUser", c => c.Int());
            CreateIndex("dbo.Interviews", "Condidat_idUser");
            AddForeignKey("dbo.Interviews", "Condidat_idUser", "dbo.Condidat", "idUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interviews", "Condidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Interviews", new[] { "Condidat_idUser" });
            DropColumn("dbo.Interviews", "Condidat_idUser");
        }
    }
}
