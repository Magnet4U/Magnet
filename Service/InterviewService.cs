using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InterviewService : Service<Interview>, IInterviewService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public InterviewService() : base(Uok)
        {
        }

        //récupérer les interview d'un utilisateur
        public IEnumerable<Interview> GetInterviewByUser(int userId)
        {
            return null;
            //return GetMany(ch => ch.Category.Equals(nameCategory));
        }

    }
}
