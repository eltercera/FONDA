using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class UsedReservationStatusMap : SubclassMap<com.ds201625.fonda.Domain.UsedReservationStatus>
    {
        public UsedReservationStatusMap()
        {
            DiscriminatorValue(@"UsedReservationStatus");
        }
    }
}
