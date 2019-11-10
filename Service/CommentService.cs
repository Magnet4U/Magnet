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
    public class CommentsService : Service<Comment>, ICommentsService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public CommentsService() : base(Uok)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments()
        {
            return GetMany();
        }

    }
}
