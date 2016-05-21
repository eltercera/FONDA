using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ActiveReservationStatusMap : SubclassMap<com.ds201625.fonda.Domain.ActiveReservationStatus>
    {
        public ActiveReservationStatusMap()
        {
            DiscriminatorValue(@"ActiveReservationStatus");
        }
    }
}
