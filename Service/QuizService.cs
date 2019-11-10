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
    public class QuizService : Service<Quiz>, IQuizService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public QuizService() : base(Uok)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quiz> GetQuizById(int id)
        {
            return null;
            //return GetMany(ch => ch.Category.Equals(nameCategory));
        }

    }
}
