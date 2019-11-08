namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazUpdateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategorieQuestions",
                c => new
                    {
                        idCategorie = c.Int(nullable: false, identity: true),
                        libelleCategorie = c.String(),
                        idQuiz_idQuiz = c.Int(),
                    })
                .PrimaryKey(t => t.idCategorie)
                .ForeignKey("dbo.Quizs", t => t.idQuiz_idQuiz)
                .Index(t => t.idQuiz_idQuiz);
            
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        idNiveau = c.Int(nullable: false, identity: true),
                        score = c.Single(nullable: false),
                        idQuestion_idQuestion = c.Int(),
                    })
                .PrimaryKey(t => t.idNiveau)
                .ForeignKey("dbo.Questions", t => t.idQuestion_idQuestion)
                .Index(t => t.idQuestion_idQuestion);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        idQuestion = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        rep1 = c.String(),
                        rep2 = c.String(),
                        rep3 = c.String(),
                        correctAnswer = c.String(),
                    })
                .PrimaryKey(t => t.idQuestion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Niveaux", "idQuestion_idQuestion", "dbo.Questions");
            DropForeignKey("dbo.CategorieQuestions", "idQuiz_idQuiz", "dbo.Quizs");
            DropIndex("dbo.Niveaux", new[] { "idQuestion_idQuestion" });
            DropIndex("dbo.CategorieQuestions", new[] { "idQuiz_idQuiz" });
            DropTable("dbo.Questions");
            DropTable("dbo.Niveaux");
            DropTable("dbo.CategorieQuestions");
        }
    }
}
