namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Malekentreprise : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOffers", "MyidEntreprise", "dbo.Entreprises");
            DropIndex("dbo.JobOffers", new[] { "MyidEntreprise" });
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        idCAR = c.Int(nullable: false, identity: true),
                        Career_title = c.String(),
                        Carrer_description = c.String(),
                        Start_date = c.DateTime(),
                        End_date = c.DateTime(),
                        MyCondidatId = c.Int(nullable: false),
                        MyCondidat_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idCAR)
                .ForeignKey("dbo.Condidat", t => t.MyCondidat_idUser)
                .Index(t => t.MyCondidat_idUser);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        idC = c.Int(nullable: false, identity: true),
                        ObtentionDateC = c.DateTime(),
                        ExpirationDateC = c.DateTime(),
                        MyCondidatId = c.Int(nullable: false),
                        MyCondidat_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idC)
                .ForeignKey("dbo.Condidat", t => t.MyCondidat_idUser)
                .Index(t => t.MyCondidat_idUser);
            
            CreateTable(
                "dbo.Diplomata",
                c => new
                    {
                        idD = c.Int(nullable: false, identity: true),
                        ObtentionDate = c.DateTime(nullable: false),
                        DegreeTitle = c.String(),
                        MyCondidatId = c.Int(nullable: false),
                        MyCondidat_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idD)
                .ForeignKey("dbo.Condidat", t => t.MyCondidat_idUser)
                .Index(t => t.MyCondidat_idUser);
            
            CreateTable(
                "dbo.Condidat",
                c => new
                    {
                        idUser = c.Int(nullable: false),
                        Condidat_firstname = c.String(),
                        Condidat_lastname = c.String(),
                        cin = c.Int(nullable: false),
                        telephone = c.Int(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser);
            
            AddColumn("dbo.JobOffers", "idEntreprise_idEntreprise", c => c.Int());
            AddColumn("dbo.Entreprises", "name", c => c.String());
            AddColumn("dbo.Entreprises", "telephone", c => c.Int(nullable: false));
            AddColumn("dbo.Competences", "MyCondidatId", c => c.Int(nullable: false));
            AddColumn("dbo.Competences", "MyCondidat_idUser", c => c.Int());
            AlterColumn("dbo.Interviews", "DateInterview", c => c.DateTime(nullable: false));
            CreateIndex("dbo.JobOffers", "idEntreprise_idEntreprise");
            CreateIndex("dbo.Competences", "MyCondidat_idUser");
            AddForeignKey("dbo.Competences", "MyCondidat_idUser", "dbo.Condidat", "idUser");
            AddForeignKey("dbo.JobOffers", "idEntreprise_idEntreprise", "dbo.Entreprises", "idEntreprise");
            DropColumn("dbo.Users", "cin");
            DropColumn("dbo.Users", "firstname");
            DropColumn("dbo.Users", "lastname");
            DropColumn("dbo.Users", "telephone");
            DropColumn("dbo.Users", "email");
            DropColumn("dbo.Users", "experience_prof");
            DropColumn("dbo.Users", "formation");
            DropColumn("dbo.Users", "certification");
            DropColumn("dbo.Users", "liste_activite");
            DropTable("dbo.ExperienceProes");
            DropTable("dbo.Langues");
            DropTable("dbo.LicenseCertifs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LicenseCertifs",
                c => new
                    {
                        idLC = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLC);
            
            CreateTable(
                "dbo.Langues",
                c => new
                    {
                        idL = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        level = c.String(),
                    })
                .PrimaryKey(t => t.idL);
            
            CreateTable(
                "dbo.ExperienceProes",
                c => new
                    {
                        idEP = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEP);
            
            AddColumn("dbo.Users", "liste_activite", c => c.String());
            AddColumn("dbo.Users", "certification", c => c.String());
            AddColumn("dbo.Users", "formation", c => c.String());
            AddColumn("dbo.Users", "experience_prof", c => c.String());
            AddColumn("dbo.Users", "email", c => c.String());
            AddColumn("dbo.Users", "telephone", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "lastname", c => c.String());
            AddColumn("dbo.Users", "firstname", c => c.String());
            AddColumn("dbo.Users", "cin", c => c.Int(nullable: false));
            DropForeignKey("dbo.JobOffers", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Condidat", "idUser", "dbo.Users");
            DropForeignKey("dbo.Diplomata", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Competences", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Certifications", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Careers", "MyCondidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Condidat", new[] { "idUser" });
            DropIndex("dbo.Diplomata", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Competences", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Certifications", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Careers", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.JobOffers", new[] { "idEntreprise_idEntreprise" });
            AlterColumn("dbo.Interviews", "DateInterview", c => c.DateTime());
            DropColumn("dbo.Competences", "MyCondidat_idUser");
            DropColumn("dbo.Competences", "MyCondidatId");
            DropColumn("dbo.Entreprises", "telephone");
            DropColumn("dbo.Entreprises", "name");
            DropColumn("dbo.JobOffers", "idEntreprise_idEntreprise");
            DropTable("dbo.Condidat");
            DropTable("dbo.Diplomata");
            DropTable("dbo.Certifications");
            DropTable("dbo.Careers");
            CreateIndex("dbo.JobOffers", "MyidEntreprise");
            AddForeignKey("dbo.JobOffers", "MyidEntreprise", "dbo.Entreprises", "idEntreprise", cascadeDelete: true);
        }
    }
}
