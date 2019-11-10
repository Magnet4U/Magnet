using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IQuestionService : IService<Question>
    {
        IEnumerable<Question> GetQuestionByQuiz(int quizId);
    }
}
