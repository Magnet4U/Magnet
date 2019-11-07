using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using Data.Configurations;

namespace Data
{
    public class MyDBContext:DbContext
    {
        public DbSet<AffectationJob> DBSetAffectationJob { get; set; }
        public DbSet<ApplyJob> DBSetApplyJob { get; set; }
        public DbSet<Claim> DBSetClaim{ get; set; }
        public DbSet<Comment> DBSetComment { get; set; }
        public DbSet<Competence> DBSetCompetence { get; set; }
        public DbSet<Entreprise> DBSetEntreprise { get; set; }
        public DbSet<Evaluation> DBSetEvaluation { get; set; }
        public DbSet<Career> DBSetCareer { get; set; }
        public DbSet<Interview> DBSetInterview { get; set; }
        public DbSet<JobOffer> DBSetJobOffer { get; set; }
        public DbSet<JobOfferPM> DBSetJobOfferPM { get; set; }
        public DbSet<JobRequest> DBSetJobRequest { get; set; }
        public DbSet<Diploma> DBSetDiploma { get; set; }
        public DbSet<Certification> DBSetCertification { get; set; }
        public DbSet<Message> DBSetMessage { get; set; }
        public DbSet<Notification> DBSetNotification { get; set; }
        public DbSet<Payment> DBSetPayment { get; set; }
        public DbSet<PostUser> DBSetPostUser { get; set; }
        public DbSet<Quiz> DBSetQuiz { get; set; }
        public DbSet<Subscribe> DBSetSubscribe { get; set; }
        public DbSet<User> DBSetUser { get; set; }
        public DbSet<EntrepriseLogin> DBSetEntrepriseLogin { get; set; }
        public DbSet<UserLogin> DBSetUserLogin { get; set; }
        public DbSet<PackOffe> DBSetPackOffe { get; set; }
        public DbSet<Response> DBSetResponse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntrepriseConfig());
        }


    }
}
