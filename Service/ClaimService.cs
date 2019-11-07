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
    public class ClaimService : Service<Claim>,IClaimService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ClaimService() : base(ut)
        {


        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Claim> GetClaimsByIdCandidat(int UserId)
        {
            return GetMany(c => c.idUser.idUser.Equals(UserId));
        }

        //public IEnumerable<Claim> GetClaimsByIdEntreprise(int UserId)
        //{

        //    return GetMany(c => c.Entreprise.idUser.Equals(UserId));
        //}
    }
}
