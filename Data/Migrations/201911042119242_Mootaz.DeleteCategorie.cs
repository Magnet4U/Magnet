namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MootazDeleteCategorie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategorieQuestions", "idQuiz_idQuiz", "dbo.Quizs");
            DropForeignKey("dbo.Niveaux", "idQuestion_idQuestion", "dbo.Questions");
            DropIndex("dbo.CategorieQuestions", new[] { "idQuiz_idQuiz" });
            DropIndex("dbo.Niveaux", new[] { "idQuestion_idQuestion" });
            RenameColumn(table: "dbo.Niveaux", name: "idQuestion_idQuestion", newName: "idQuestion");
            AddColumn("dbo.Niveaux", "Quiz_idQuiz", c => c.Int());
            AlterColumn("dbo.Niveaux", "idQuestion", c => c.Int(nullable: false));
            CreateIndex("dbo.Niveaux", "idQuestion");
            CreateIndex("dbo.Niveaux", "Quiz_idQuiz");
            AddForeignKey("dbo.Niveaux", "Quiz_idQuiz", "dbo.Quizs", "idQuiz");
            AddForeignKey("dbo.Niveaux", "idQuestion", "dbo.Questions", "idQuestion", cascadeDelete: true);
            DropTable("dbo.CategorieQuestions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategorieQuestions",
                c => new
                    {
                        idCategorie = c.Int(nullable: false, identity: true),
                        libelleCategorie = c.String(),
                        idQuiz_idQuiz = c.Int(),
                    })
                .PrimaryKey(t => t.idCategorie);
            
            DropForeignKey("dbo.Niveaux", "idQuestion", "dbo.Questions");
            DropForeignKey("dbo.Niveaux", "Quiz_idQuiz", "dbo.Quizs");
            DropIndex("dbo.Niveaux", new[] { "Quiz_idQuiz" });
            DropIndex("dbo.Niveaux", new[] { "idQuestion" });
            AlterColumn("dbo.Niveaux", "idQuestion", c => c.Int());
            DropColumn("dbo.Niveaux", "Quiz_idQuiz");
            RenameColumn(table: "dbo.Niveaux", name: "idQuestion", newName: "idQuestion_idQuestion");
            CreateIndex("dbo.Niveaux", "idQuestion_idQuestion");
            CreateIndex("dbo.CategorieQuestions", "idQuiz_idQuiz");
            AddForeignKey("dbo.Niveaux", "idQuestion_idQuestion", "dbo.Questions", "idQuestion");
            AddForeignKey("dbo.CategorieQuestions", "idQuiz_idQuiz", "dbo.Quizs", "idQuiz");
        }
    }
}
