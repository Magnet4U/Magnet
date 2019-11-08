namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazAddQuizTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quizs", "idUser_idUser", "dbo.Users");
            DropIndex("dbo.Quizs", new[] { "idUser_idUser" });
            AddColumn("dbo.Quizs", "libelleQuiz", c => c.String());
            AddColumn("dbo.Quizs", "idCandidat_idUser", c => c.Int());
            CreateIndex("dbo.Quizs", "idCandidat_idUser");
            AddForeignKey("dbo.Quizs", "idCandidat_idUser", "dbo.Condidat", "idUser");
            DropColumn("dbo.Quizs", "score");
            DropColumn("dbo.Quizs", "idUser_idUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "idUser_idUser", c => c.Int());
            AddColumn("dbo.Quizs", "score", c => c.Int(nullable: false));
            DropForeignKey("dbo.Quizs", "idCandidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Quizs", new[] { "idCandidat_idUser" });
            DropColumn("dbo.Quizs", "idCandidat_idUser");
            DropColumn("dbo.Quizs", "libelleQuiz");
            CreateIndex("dbo.Quizs", "idUser_idUser");
            AddForeignKey("dbo.Quizs", "idUser_idUser", "dbo.Users", "idUser");
        }
    }
}
