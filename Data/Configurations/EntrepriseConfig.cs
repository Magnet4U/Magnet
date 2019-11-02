using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Data.Configurations
{
    public class EntrepriseConfig : EntityTypeConfiguration<Entreprise>
    {
        public EntrepriseConfig()
        {
            HasMany(c => c.joboffers).WithRequired(e => e.idEntreprise).HasForeignKey(e => e.MyidEntreprise);
        }
    }
}
