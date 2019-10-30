using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class CondidatConfig : EntityTypeConfiguration<Condidat>
    {
        public CondidatConfig()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Condidat");
            });

        }
       

    }

}
