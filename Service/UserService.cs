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
   public class UserService : Service<User>, IUserService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public UserService() : base(Uok)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return GetMany();
        }

    }
}
