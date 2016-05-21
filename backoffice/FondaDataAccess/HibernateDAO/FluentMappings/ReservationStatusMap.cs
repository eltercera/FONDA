using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ReservationStatusMap : SubclassMap<com.ds201625.fonda.Domain.ReservationStatus>
    {
        public ReservationStatusMap()
        {
            DiscriminatorValue(@"ReservationStatus");
        }
    }
}
