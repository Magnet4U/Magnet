namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazAddQuestionNiveau : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quizs", "idUser_idUser", "dbo.Users");
            DropIndex("dbo.Quizs", new[] { "idUser_idUser" });
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        idNiveau = c.Int(nullable: false, identity: true),
                        score = c.Single(nullable: false),
                        idQuestion = c.Int(nullable: false),
                        Quiz_idQuiz = c.Int(),
                    })
                .PrimaryKey(t => t.idNiveau)
                .ForeignKey("dbo.Questions", t => t.idQuestion, cascadeDelete: true)
                .ForeignKey("dbo.Quizs", t => t.Quiz_idQuiz)
                .Index(t => t.idQuestion)
                .Index(t => t.Quiz_idQuiz);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        idQuestion = c.Int(nullable: false, identity: true),
                        GroupingId = c.Int(nullable: false),
                        description = c.String(),
                        rep1 = c.String(),
                        rep2 = c.String(),
                        rep3 = c.String(),
                        correctAnswer = c.String(),
                    })
                .PrimaryKey(t => t.idQuestion);
            
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
            DropForeignKey("dbo.Niveaux", "Quiz_idQuiz", "dbo.Quizs");
            DropForeignKey("dbo.Niveaux", "idQuestion", "dbo.Questions");
            DropForeignKey("dbo.Quizs", "idCandidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Niveaux", new[] { "Quiz_idQuiz" });
            DropIndex("dbo.Niveaux", new[] { "idQuestion" });
            DropIndex("dbo.Quizs", new[] { "idCandidat_idUser" });
            DropColumn("dbo.Quizs", "idCandidat_idUser");
            DropColumn("dbo.Quizs", "libelleQuiz");
            DropTable("dbo.Questions");
            DropTable("dbo.Niveaux");
            CreateIndex("dbo.Quizs", "idUser_idUser");
            AddForeignKey("dbo.Quizs", "idUser_idUser", "dbo.Users", "idUser");
        }
    }
}
