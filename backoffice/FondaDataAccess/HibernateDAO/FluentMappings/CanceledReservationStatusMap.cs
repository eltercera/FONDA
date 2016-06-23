using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class CancelReservationStatusMap : SubclassMap<com.ds201625.fonda.Domain.CanceledReservationStatus>
    {
        public CancelReservationStatusMap()
        {
            DiscriminatorValue(@"CanceledReservationStatus");
        }
    }
}
