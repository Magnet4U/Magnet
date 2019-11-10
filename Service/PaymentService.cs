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
    public class PaymentService : Service<Payment>, IPaymentService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
        public PaymentService() : base(ut)
        {


        }
        public IEnumerable<Payment> GetPaymentByIdCandidat(int UserId)
        {
            return GetMany(c => c.idUser.idUser.Equals(UserId));
        }
    }
}
