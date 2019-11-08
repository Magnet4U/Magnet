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
    public class QuestionService : Service<Question>, IQuestionService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public QuestionService() : base(Uok)
        {
        }



        
        public IEnumerable<Question> GetQuestionByQuiz(int quizId)
        {
            return null;
            //return GetMany(ch => ch.Category.Equals(nameCategory));
        }

    }
}
