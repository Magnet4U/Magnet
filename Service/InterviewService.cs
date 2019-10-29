using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InterviewService : Service<Interview>, IInterviewService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public InterviewService() : base(Uok)
        {
        }

        //récupérer les chambre d'un hotel
        public IEnumerable<Interview> GetInterviewByUser(int userId)
        {
            return null;
            //return GetMany(ch => ch.Category.Equals(nameCategory));
        }

    }
}
