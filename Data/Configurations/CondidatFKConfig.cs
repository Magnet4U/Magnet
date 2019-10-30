using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class CondidatFKConfig : EntityTypeConfiguration<Condidat>
    {
        public CondidatFKConfig()
        {
            HasMany(c => c.MyCareers)
                    .WithRequired(e => e.MyCondidat)
                    .HasForeignKey(e => e.MyCondidatId)
                    .WillCascadeOnDelete(true);
            HasMany(c => c.MyComp)
                   .WithRequired(e => e.MyCondidat)
                   .HasForeignKey(e => e.MyCondidatId)
                   .WillCascadeOnDelete(true);
            HasMany(c => c.MyCertif)
                   .WithRequired(e => e.MyCondidat)
                   .HasForeignKey(e => e.MyCondidatId)
                   .WillCascadeOnDelete(true);
            HasMany(c => c.MyDip)
                   .WithRequired(e => e.MyCondidat)
                   .HasForeignKey(e => e.MyCondidatId)
                   .WillCascadeOnDelete(true);
        }
    }
}
