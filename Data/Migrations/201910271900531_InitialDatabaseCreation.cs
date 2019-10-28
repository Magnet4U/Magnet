namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AffectationJobs",
                c => new
                    {
                        id_AJ = c.Int(nullable: false, identity: true),
                        id_JobOffer_id_JobOffer = c.Int(),
                        idCandidate_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.id_AJ)
                .ForeignKey("dbo.JobOffers", t => t.id_JobOffer_id_JobOffer)
                .ForeignKey("dbo.Users", t => t.idCandidate_idUser)
                .Index(t => t.id_JobOffer_id_JobOffer)
                .Index(t => t.idCandidate_idUser);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        id_JobOffer = c.Int(nullable: false, identity: true),
                        Job_title = c.String(),
                        description = c.String(),
                        category = c.String(),
                        salary = c.Single(nullable: false),
                        hours = c.Int(nullable: false),
                        location = c.String(),
                        Date_publication = c.DateTime(nullable: false),
                        idEntreprise_idEntreprise = c.Int(),
                    })
                .PrimaryKey(t => t.id_JobOffer)
                .ForeignKey("dbo.Entreprises", t => t.idEntreprise_idEntreprise)
                .Index(t => t.idEntreprise_idEntreprise);
            
            CreateTable(
                "dbo.Entreprises",
                c => new
                    {
                        idEntreprise = c.Int(nullable: false, identity: true),
                        nbEmployee = c.Int(nullable: false),
                        introduction = c.String(),
                    })
                .PrimaryKey(t => t.idEntreprise);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        idEvent = c.Int(nullable: false, identity: true),
                        idEntreprise_idEntreprise = c.Int(),
                    })
                .PrimaryKey(t => t.idEvent)
                .ForeignKey("dbo.Entreprises", t => t.idEntreprise_idEntreprise)
                .Index(t => t.idEntreprise_idEntreprise);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        cin = c.Int(nullable: false),
                        username = c.String(),
                        password = c.String(),
                        firstname = c.String(),
                        lastname = c.String(),
                        telephone = c.Int(nullable: false),
                        email = c.String(),
                        role = c.String(),
                        experience_prof = c.String(),
                        formation = c.String(),
                        certification = c.String(),
                        liste_activite = c.String(),
                        idEntreprise_idEntreprise = c.Int(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Entreprises", t => t.idEntreprise_idEntreprise)
                .Index(t => t.idEntreprise_idEntreprise);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        idComp = c.Int(nullable: false, identity: true),
                        descriptionCompetence = c.String(),
                        idCandidate_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idComp)
                .ForeignKey("dbo.Users", t => t.idCandidate_idUser)
                .Index(t => t.idCandidate_idUser);
            
            CreateTable(
                "dbo.ApplyJobs",
                c => new
                    {
                        id_ApplyJob = c.Int(nullable: false, identity: true),
                        date_applu = c.DateTime(nullable: false),
                        id_JobOffer_id_JobOffer = c.Int(),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.id_ApplyJob)
                .ForeignKey("dbo.JobOffers", t => t.id_JobOffer_id_JobOffer)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.id_JobOffer_id_JobOffer)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        idClaim = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        body = c.String(),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idClaim)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        idComment = c.Int(nullable: false, identity: true),
                        contenuComment = c.String(),
                        date_publication = c.DateTime(nullable: false),
                        idPostEntreprise_idPostU = c.Int(),
                        idPostUser_idPostU = c.Int(),
                    })
                .PrimaryKey(t => t.idComment)
                .ForeignKey("dbo.PostEntreprises", t => t.idPostEntreprise_idPostU)
                .ForeignKey("dbo.PostUsers", t => t.idPostUser_idPostU)
                .Index(t => t.idPostEntreprise_idPostU)
                .Index(t => t.idPostUser_idPostU);
            
            CreateTable(
                "dbo.PostEntreprises",
                c => new
                    {
                        idPostU = c.Int(nullable: false, identity: true),
                        contenu = c.String(),
                        like = c.Int(nullable: false),
                        date_publication = c.DateTime(nullable: false),
                        idEntreprise_idEntreprise = c.Int(),
                    })
                .PrimaryKey(t => t.idPostU)
                .ForeignKey("dbo.Entreprises", t => t.idEntreprise_idEntreprise)
                .Index(t => t.idEntreprise_idEntreprise);
            
            CreateTable(
                "dbo.PostUsers",
                c => new
                    {
                        idPostU = c.Int(nullable: false, identity: true),
                        contenu = c.String(),
                        like = c.Int(nullable: false),
                        date_publication = c.DateTime(nullable: false),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idPostU)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        idEva = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.idEva);
            
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
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        idInterview = c.Int(nullable: false, identity: true),
                        DateInterview = c.DateTime(nullable: false),
                        lieu = c.String(),
                        idUSer_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idInterview)
                .ForeignKey("dbo.Users", t => t.idUSer_idUser)
                .Index(t => t.idUSer_idUser);
            
            CreateTable(
                "dbo.JobOfferPMs",
                c => new
                    {
                        id_JobOfferPM = c.Int(nullable: false, identity: true),
                        Job_title = c.String(),
                        description = c.String(),
                        category = c.String(),
                        hours = c.Int(nullable: false),
                        Date_publication = c.DateTime(nullable: false),
                        idEntreprise_idEntreprise = c.Int(),
                    })
                .PrimaryKey(t => t.id_JobOfferPM)
                .ForeignKey("dbo.Entreprises", t => t.idEntreprise_idEntreprise)
                .Index(t => t.idEntreprise_idEntreprise);
            
            CreateTable(
                "dbo.JobRequests",
                c => new
                    {
                        id_JobRequest = c.Int(nullable: false, identity: true),
                        Job_title = c.String(),
                        description = c.String(),
                        category = c.String(),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.id_JobRequest)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
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
                "dbo.LicenseCertifs",
                c => new
                    {
                        idLC = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLC);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        idMessage = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        body = c.String(),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idMessage)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        idNotif = c.Int(nullable: false, identity: true),
                        contenu = c.String(),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idNotif)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        idPayment = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idPayment)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        idQuiz = c.Int(nullable: false, identity: true),
                        score = c.Int(nullable: false),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idQuiz)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        numSub = c.Int(nullable: false, identity: true),
                        id_Subscriber = c.Int(nullable: false),
                        id_subscription = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.numSub);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizs", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Payments", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Notifications", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Messages", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.JobRequests", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.JobOfferPMs", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Interviews", "idUSer_idUser", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Comments", "idPostUser_idPostU", "dbo.PostUsers");
            DropForeignKey("dbo.PostEntreprises", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Comments", "idPostEntreprise_idPostU", "dbo.PostEntreprises");
            DropForeignKey("dbo.Claims", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.ApplyJobs", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.ApplyJobs", "id_JobOffer_id_JobOffer", "dbo.JobOffers");
            DropForeignKey("dbo.AffectationJobs", "idCandidate_idUser", "dbo.Users");
            DropForeignKey("dbo.Users", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Competences", "idCandidate_idUser", "dbo.Users");
            DropForeignKey("dbo.AffectationJobs", "id_JobOffer_id_JobOffer", "dbo.JobOffers");
            DropForeignKey("dbo.JobOffers", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Events", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropIndex("dbo.Quizs", new[] { "idUser_idUser" });
            DropIndex("dbo.Payments", new[] { "idUser_idUser" });
            DropIndex("dbo.Notifications", new[] { "idUser_idUser" });
            DropIndex("dbo.Messages", new[] { "idUser_idUser" });
            DropIndex("dbo.JobRequests", new[] { "idUser_idUser" });
            DropIndex("dbo.JobOfferPMs", new[] { "idEntreprise_idEntreprise" });
            DropIndex("dbo.Interviews", new[] { "idUSer_idUser" });
            DropIndex("dbo.PostUsers", new[] { "idUser_idUser" });
            DropIndex("dbo.PostEntreprises", new[] { "idEntreprise_idEntreprise" });
            DropIndex("dbo.Comments", new[] { "idPostUser_idPostU" });
            DropIndex("dbo.Comments", new[] { "idPostEntreprise_idPostU" });
            DropIndex("dbo.Claims", new[] { "idUser_idUser" });
            DropIndex("dbo.ApplyJobs", new[] { "idUser_idUser" });
            DropIndex("dbo.ApplyJobs", new[] { "id_JobOffer_id_JobOffer" });
            DropIndex("dbo.Competences", new[] { "idCandidate_idUser" });
            DropIndex("dbo.Users", new[] { "idEntreprise_idEntreprise" });
            DropIndex("dbo.Events", new[] { "idEntreprise_idEntreprise" });
            DropIndex("dbo.JobOffers", new[] { "idEntreprise_idEntreprise" });
            DropIndex("dbo.AffectationJobs", new[] { "idCandidate_idUser" });
            DropIndex("dbo.AffectationJobs", new[] { "id_JobOffer_id_JobOffer" });
            DropTable("dbo.Subscribes");
            DropTable("dbo.Quizs");
            DropTable("dbo.Payments");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.LicenseCertifs");
            DropTable("dbo.Langues");
            DropTable("dbo.JobRequests");
            DropTable("dbo.JobOfferPMs");
            DropTable("dbo.Interviews");
            DropTable("dbo.ExperienceProes");
            DropTable("dbo.Evaluations");
            DropTable("dbo.PostUsers");
            DropTable("dbo.PostEntreprises");
            DropTable("dbo.Comments");
            DropTable("dbo.Claims");
            DropTable("dbo.ApplyJobs");
            DropTable("dbo.Competences");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
            DropTable("dbo.Entreprises");
            DropTable("dbo.JobOffers");
            DropTable("dbo.AffectationJobs");
        }
    }
}
