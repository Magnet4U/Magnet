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
    public class ResponseService : Service<Response>, IResponseService
    {
        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ResponseService() : base(ut)
        {


        }
        
    }
}
