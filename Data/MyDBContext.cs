using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

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
        public DbSet<Event> DBSetEvent { get; set; }
        public DbSet<ExperiencePro> DBSetExperiencePro { get; set; }
        public DbSet<Interview> DBSetInterview { get; set; }
        public DbSet<JobOffer> DBSetJobOffer { get; set; }
        public DbSet<JobOfferPM> DBSetJobOfferPM { get; set; }
        public DbSet<JobRequest> DBSetJobRequest { get; set; }
        public DbSet<Langue> DBSetLangue { get; set; }
        public DbSet<LicenseCertif> DBSetLicenseCertif { get; set; }
        public DbSet<Message> DBSetMessage { get; set; }
        public DbSet<Notification> DBSetNotification { get; set; }
        public DbSet<Payment> DBSetPayment { get; set; }
        public DbSet<PostEntreprise> DBSetPostEntreprise { get; set; }
        public DbSet<PostUser> DBSetPostUser { get; set; }
        public DbSet<Quiz> DBSetQuiz { get; set; }
        public DbSet<Subscribe> DBSetSubscribe { get; set; }
        public DbSet<User> DBSetUser { get; set; }
     

    }
}
