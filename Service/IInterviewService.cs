using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IInterviewService :IService<Interview>
    {
        IEnumerable<Interview> GetInterviewByUser(int userId);
    }
}
