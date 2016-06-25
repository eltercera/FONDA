using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class CanceledReservationStatusMap : SubclassMap<com.ds201625.fonda.Domain.CanceledReservationStatus>
    {
        public CanceledReservationStatusMap()
        {
            DiscriminatorValue(@"CanceledReservationStatus");
        }
    }
}
