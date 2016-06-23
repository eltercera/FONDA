using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class FreeTableStatusMap : SubclassMap<com.ds201625.fonda.Domain.FreeTableStatus>
    {
        public FreeTableStatusMap()
        {
            DiscriminatorValue(@"FreeTableStatus");
        }

    }
}
