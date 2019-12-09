namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
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
                        MyidEntreprise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_JobOffer)
                .ForeignKey("dbo.Entreprises", t => t.MyidEntreprise, cascadeDelete: true)
                .Index(t => t.MyidEntreprise);
            
            CreateTable(
                "dbo.Entreprises",
                c => new
                    {
                        idEntreprise = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        Password = c.String(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        telephone = c.Int(nullable: false),
                        introduction = c.String(nullable: false),
                        nbEmployee = c.Int(nullable: false),
                        image = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.idEntreprise);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        ConfirmPassword = c.String(),
                        firstname = c.String(nullable: false),
                        lastname = c.String(nullable: false),
                        DateofBirth = c.DateTime(),
                        cin = c.Int(nullable: false),
                        telephone = c.Int(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(),
                        role = c.String(),
                        image = c.String(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        MyidEntreprise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Entreprises", t => t.MyidEntreprise, cascadeDelete: true)
                .Index(t => t.MyidEntreprise);
            
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
                "dbo.Competences",
                c => new
                    {
                        idComp = c.Int(nullable: false, identity: true),
                        descriptionCompetence = c.String(),
                        MyCondidatId = c.Int(nullable: false),
                        idCandidate_idUser = c.Int(),
                        MyCondidat_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idComp)
                .ForeignKey("dbo.Users", t => t.idCandidate_idUser)
                .ForeignKey("dbo.Condidat", t => t.MyCondidat_idUser)
                .Index(t => t.idCandidate_idUser)
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
                        date = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        entreprise_idEntreprise = c.Int(),
                        idUser_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idClaim)
                .ForeignKey("dbo.Entreprises", t => t.entreprise_idEntreprise)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .Index(t => t.entreprise_idEntreprise)
                .Index(t => t.idUser_idUser);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        IdResponse = c.Int(nullable: false, identity: true),
                        ResponseDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        user_idUser = c.Int(),
                        Claim_idClaim = c.Int(),
                    })
                .PrimaryKey(t => t.IdResponse)
                .ForeignKey("dbo.Users", t => t.user_idUser)
                .ForeignKey("dbo.Claims", t => t.Claim_idClaim)
                .Index(t => t.user_idUser)
                .Index(t => t.Claim_idClaim);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        idComment = c.Int(nullable: false, identity: true),
                        contenuComment = c.String(),
                        date_publication = c.DateTime(nullable: false),
                        idPostUser_idPostU = c.Int(),
                    })
                .PrimaryKey(t => t.idComment)
                .ForeignKey("dbo.PostUsers", t => t.idPostUser_idPostU)
                .Index(t => t.idPostUser_idPostU);
            
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
                "dbo.EntrepriseLogins",
                c => new
                    {
                        idEntrepriseLogin = c.String(nullable: false, maxLength: 128),
                        EmailID = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RemeberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idEntrepriseLogin);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        idEva = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.idEva);
            
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
                "dbo.PackOffes",
                c => new
                    {
                        IdPackOffer = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Single(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.IdPackOffer);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        idPayment = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        Mode = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        ExpiratioDate = c.DateTime(nullable: false),
                        Reduction = c.Single(nullable: false),
                        status = c.String(),
                        entreprise_idEntreprise = c.Int(),
                        idUser_idUser = c.Int(),
                        packOffe_IdPackOffer = c.Int(),
                    })
                .PrimaryKey(t => t.idPayment)
                .ForeignKey("dbo.Entreprises", t => t.entreprise_idEntreprise)
                .ForeignKey("dbo.Users", t => t.idUser_idUser)
                .ForeignKey("dbo.PackOffes", t => t.packOffe_IdPackOffer)
                .Index(t => t.entreprise_idEntreprise)
                .Index(t => t.idUser_idUser)
                .Index(t => t.packOffe_IdPackOffer);
            
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
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        idUserLogin = c.String(nullable: false, maxLength: 128),
                        EmailID = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RemeberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idUserLogin);
            
            CreateTable(
                "dbo.Condidat",
                c => new
                    {
                        idUser = c.Int(nullable: false),
                        Condidat_firstname = c.String(),
                        Condidat_lastname = c.String(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Condidat", "idUser", "dbo.Users");
            DropForeignKey("dbo.Quizs", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Payments", "packOffe_IdPackOffer", "dbo.PackOffes");
            DropForeignKey("dbo.Payments", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Payments", "entreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Notifications", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Messages", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.JobRequests", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.JobOfferPMs", "idEntreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Interviews", "idUSer_idUser", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Comments", "idPostUser_idPostU", "dbo.PostUsers");
            DropForeignKey("dbo.Responses", "Claim_idClaim", "dbo.Claims");
            DropForeignKey("dbo.Responses", "user_idUser", "dbo.Users");
            DropForeignKey("dbo.Claims", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.Claims", "entreprise_idEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.ApplyJobs", "idUser_idUser", "dbo.Users");
            DropForeignKey("dbo.ApplyJobs", "id_JobOffer_id_JobOffer", "dbo.JobOffers");
            DropForeignKey("dbo.AffectationJobs", "idCandidate_idUser", "dbo.Users");
            DropForeignKey("dbo.AffectationJobs", "id_JobOffer_id_JobOffer", "dbo.JobOffers");
            DropForeignKey("dbo.Users", "MyidEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Diplomata", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Competences", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Competences", "idCandidate_idUser", "dbo.Users");
            DropForeignKey("dbo.Certifications", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.Careers", "MyCondidat_idUser", "dbo.Condidat");
            DropForeignKey("dbo.JobOffers", "MyidEntreprise", "dbo.Entreprises");
            DropIndex("dbo.Condidat", new[] { "idUser" });
            DropIndex("dbo.Quizs", new[] { "idUser_idUser" });
            DropIndex("dbo.Payments", new[] { "packOffe_IdPackOffer" });
            DropIndex("dbo.Payments", new[] { "idUser_idUser" });
            DropIndex("dbo.Payments", new[] { "entreprise_idEntreprise" });
            DropIndex("dbo.Notifications", new[] { "idUser_idUser" });
            DropIndex("dbo.Messages", new[] { "idUser_idUser" });
            DropIndex("dbo.JobRequests", new[] { "idUser_idUser" });
            DropIndex("dbo.JobOfferPMs", new[] { "idEntreprise_idEntreprise" });
            DropIndex("dbo.Interviews", new[] { "idUSer_idUser" });
            DropIndex("dbo.PostUsers", new[] { "idUser_idUser" });
            DropIndex("dbo.Comments", new[] { "idPostUser_idPostU" });
            DropIndex("dbo.Responses", new[] { "Claim_idClaim" });
            DropIndex("dbo.Responses", new[] { "user_idUser" });
            DropIndex("dbo.Claims", new[] { "idUser_idUser" });
            DropIndex("dbo.Claims", new[] { "entreprise_idEntreprise" });
            DropIndex("dbo.ApplyJobs", new[] { "idUser_idUser" });
            DropIndex("dbo.ApplyJobs", new[] { "id_JobOffer_id_JobOffer" });
            DropIndex("dbo.Diplomata", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Competences", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Competences", new[] { "idCandidate_idUser" });
            DropIndex("dbo.Certifications", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Careers", new[] { "MyCondidat_idUser" });
            DropIndex("dbo.Users", new[] { "MyidEntreprise" });
            DropIndex("dbo.JobOffers", new[] { "MyidEntreprise" });
            DropIndex("dbo.AffectationJobs", new[] { "idCandidate_idUser" });
            DropIndex("dbo.AffectationJobs", new[] { "id_JobOffer_id_JobOffer" });
            DropTable("dbo.Condidat");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Subscribes");
            DropTable("dbo.Quizs");
            DropTable("dbo.Payments");
            DropTable("dbo.PackOffes");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.JobRequests");
            DropTable("dbo.JobOfferPMs");
            DropTable("dbo.Interviews");
            DropTable("dbo.Evaluations");
            DropTable("dbo.EntrepriseLogins");
            DropTable("dbo.PostUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Responses");
            DropTable("dbo.Claims");
            DropTable("dbo.ApplyJobs");
            DropTable("dbo.Diplomata");
            DropTable("dbo.Competences");
            DropTable("dbo.Certifications");
            DropTable("dbo.Careers");
            DropTable("dbo.Users");
            DropTable("dbo.Entreprises");
            DropTable("dbo.JobOffers");
            DropTable("dbo.AffectationJobs");
        }
    }
}
