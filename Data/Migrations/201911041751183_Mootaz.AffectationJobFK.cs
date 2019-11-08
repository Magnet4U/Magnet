namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazAffectationJobFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AffectationJobs", "candidat_idUser", c => c.Int());
            CreateIndex("dbo.AffectationJobs", "candidat_idUser");
            AddForeignKey("dbo.AffectationJobs", "candidat_idUser", "dbo.Condidat", "idUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AffectationJobs", "candidat_idUser", "dbo.Condidat");
            DropIndex("dbo.AffectationJobs", new[] { "candidat_idUser" });
            DropColumn("dbo.AffectationJobs", "candidat_idUser");
        }
    }
}
