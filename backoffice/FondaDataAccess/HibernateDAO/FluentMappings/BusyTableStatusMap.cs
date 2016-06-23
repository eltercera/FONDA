using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class BusyTableStatusMap : SubclassMap<com.ds201625.fonda.Domain.BusyTableStatus>
    {
        public BusyTableStatusMap()
        {
            DiscriminatorValue(@"BusyTableStatus");
        }
    }
}
